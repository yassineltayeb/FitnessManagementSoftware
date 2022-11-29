using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.ViewModels.Coach;

namespace FitnessManagementSoftware.Controller;

[Route("api/members")]
[Authorize]
[ApiController]
public class MembersController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MembersController(IMemberService memberService)
    {
        _memberService = memberService;
    }

    [AllowAnonymous]
    [HttpPost("signup")]
    public async Task<SignUpResponseViewModel> MemberSignUp([FromBody] SignUpRequestViewModel signUpRequestViewModel)
    {
        return await _memberService.SignUp(signUpRequestViewModel);
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<SignUpResponseViewModel> MemberLogin([FromBody] LoginRequestViewModel loginRequestViewModel)
    {
        return await _memberService.Login(loginRequestViewModel);
    }
}
