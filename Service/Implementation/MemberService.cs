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

public class MemberService : IMemberService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public MemberService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<SignUpResponseViewModel> SignUp(SignUpRequestViewModel signUpRequestViewModel)
    {
        var memberToAdd = _mapper.Map<Member>(signUpRequestViewModel);

        var emailExist = await _unitOfWork.MemberRepository.VerifyEmail(signUpRequestViewModel.Email);
        if (emailExist)
            throw new APIException((int)HttpStatusCode.BadRequest, "Email already exists");

        memberToAdd.Password = BCrypt.Net.BCrypt.HashPassword(memberToAdd.Password);

        memberToAdd.CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        var memberAdded = await _unitOfWork.MemberRepository.AddMember(memberToAdd);

        return GenerateToken(memberAdded);
    }

    public async Task<SignUpResponseViewModel> Login(LoginRequestViewModel loginRequestViewModel)
    {
        var member = await _unitOfWork.MemberRepository.GetMemberhByEmail(loginRequestViewModel.Email);

        if (member is null)
            throw new APIException((int)HttpStatusCode.BadRequest, "Invalid Email/Password");

        if (!BCrypt.Net.BCrypt.Verify(loginRequestViewModel.Password, member.Password))
            throw new APIException((int)HttpStatusCode.BadRequest, "Invalid Email/Password");

        return GenerateToken(member);
    }

    private SignUpResponseViewModel GenerateToken(Member member)
    {
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, member.Id.ToString()),
            new Claim(ClaimTypes.Name, member.FirstName + " " + member.LastName),
            new Claim(ClaimTypes.Email, member.Email),
            new Claim(ClaimTypes.MobilePhone, member.Phone)
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