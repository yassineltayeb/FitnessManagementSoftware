using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Interface;
using Service.Exceptions;
using Service.Interface;
using Service.ViewModels.Coach;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Service.Implementation;

public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UserService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<SignUpResponseViewModel> Login(LoginRequestViewModel loginRequestViewModel)
    {
        var user = await _unitOfWork.UserRepository.GetUserByEmail(loginRequestViewModel.Email, (int)loginRequestViewModel.UserType);

        if (user is null)
            throw new APIException((int)HttpStatusCode.BadRequest, "Invalid Email/Password");

        if (!BCrypt.Net.BCrypt.Verify(loginRequestViewModel.Password, user.Password))
            throw new APIException((int)HttpStatusCode.BadRequest, "Invalid Email/Password");

        return GenerateToken(user);
    }

    private SignUpResponseViewModel GenerateToken(User user)
    {
        var authClaims = new List<Claim>
        {
            new Claim("userId", user.Id.ToString()),
            new Claim("fullName", user.FirstName + " " + user.LastName),
            new Claim("email", user.Email),
            new Claim("phone", user.Phone),
            new Claim("userTypeId", user.UserTypeId.ToString())
        };

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _configuration["JWT:ValidIssuer"],
            audience: _configuration["JWT:ValidAudience"],
            expires: DateTime.Now.AddHours(3),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

        var signUpResponseViewModel = new SignUpResponseViewModel
        {
            Token = token,
            Expiration = jwtSecurityToken.ValidTo
        };

        return signUpResponseViewModel;
    }
}