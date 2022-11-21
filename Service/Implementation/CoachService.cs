using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.Interface;
using Service.Interface;
using Service.ViewModels.Coach;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Implementation;

public class CoachService : ICoachService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public CoachService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _configuration = configuration;
    }

    public async Task<SignUpResponseViewModel> SignUp(SignUpRequestViewModel signUpRequestViewModel)
    {
        var coachToAdd = _mapper.Map<Coach>(signUpRequestViewModel);

        coachToAdd.Password = BCrypt.Net.BCrypt.HashPassword(coachToAdd.Password);

        var coachAdded = await _unitOfWork.CoachRepository.AddCoach(coachToAdd);

        return GenerateToken(coachAdded);
    }

    public async Task<SignUpResponseViewModel> Login(LoginRequestViewModel loginRequestViewModel)
    {
        var coach = await _unitOfWork.CoachRepository.GetCoachByEmail(loginRequestViewModel.Email);

        if (BCrypt.Net.BCrypt.Verify(loginRequestViewModel.Password, coach.Password))
            return GenerateToken(coach);

        return null;
    }

    private SignUpResponseViewModel GenerateToken(Coach coach)
    {
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, coach.Id.ToString()),
            new Claim(ClaimTypes.Name, coach.FirstName + " " + coach.LastName),
            new Claim(ClaimTypes.Email, coach.Email),
            new Claim(ClaimTypes.MobilePhone, coach.Phone),
            new Claim(ClaimTypes.DateOfBirth, coach.DateOfBirth.Value.ToShortDateString())
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