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

        var emailExist = await _unitOfWork.CoachRepository.VerifyEmail(signUpRequestViewModel.Email);
        if (emailExist)
            throw new APIException((int)HttpStatusCode.BadRequest, "Email already exists");

        var phoneExist = await _unitOfWork.CoachRepository.VerifyPhone(signUpRequestViewModel.Phone);
        if (phoneExist)
            throw new APIException((int)HttpStatusCode.BadRequest, "Phone already exists");

        coachToAdd.Password = BCrypt.Net.BCrypt.HashPassword(coachToAdd.Password);

        coachToAdd.CreatedAt = DateTimeOffset.Now.ToUnixTimeMilliseconds();

        if (signUpRequestViewModel.CoachTypesIds.Any())
        {
            coachToAdd.CoachesTypes.AddRange(MapCoachTypes(signUpRequestViewModel.CoachTypesIds));
        }

        var coachAdded = await _unitOfWork.CoachRepository.AddCoach(coachToAdd);

        return GenerateToken(coachAdded);
    }

    public async Task<SignUpResponseViewModel> Login(LoginRequestViewModel loginRequestViewModel)
    {
        var coach = await _unitOfWork.CoachRepository.GetCoachByEmail(loginRequestViewModel.Email);

        if (coach is null)
            throw new APIException((int)HttpStatusCode.BadRequest, "Invalid Email/Password");

        if (!BCrypt.Net.BCrypt.Verify(loginRequestViewModel.Password, coach.Password))
            throw new APIException((int)HttpStatusCode.BadRequest, "Invalid Email/Password");

        return GenerateToken(coach);
    }

    private SignUpResponseViewModel GenerateToken(Coach coach)
    {
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, coach.Id.ToString()),
            new Claim(ClaimTypes.Name, coach.FirstName + " " + coach.LastName),
            new Claim(ClaimTypes.Email, coach.Email),
            new Claim(ClaimTypes.MobilePhone, coach.Phone)
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

    private List<CoachesTypes> MapCoachTypes(List<int> coachTypesIds)
    {
        var coachesTypes = new List<CoachesTypes>();

        foreach (var coachTypeId in coachTypesIds)
        {
            coachesTypes.Add(new CoachesTypes()
            {
                CoachTypeId = coachTypeId
            });
        }

        return coachesTypes;
    }
}