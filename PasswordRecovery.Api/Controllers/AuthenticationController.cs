using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using PasswordRecovery.Contracts.Authentication;
using MediatR;
using PasswordRecovery.Application.Authentication.Commands.Register;
using PasswordRecovery.Application.Authentication.Common;
using PasswordRecovery.Application.Authentication.Queries.Login;
using MapsterMapper;
using PasswordRecovery.Application.Authentication.Commands.Verify;

namespace PasswordRecovery.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        ErrorOr<RegisterResult> authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => Ok(authResult),
            errors => Problem(errors)
        );
    }

    [HttpPost("verify")]
    public async Task<IActionResult> Verify(string verifyToken)
    {
        var command = new VerifyCommand(verifyToken);

        var verifyResult = await _mediator.Send(command);

        // Custom logic error response 
        if (verifyResult.IsError && verifyResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: verifyResult.FirstError.Description);
        }

        return verifyResult.Match(
            verifyResult => Ok(verifyResult),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var authResult = await _mediator.Send(query);

        // Custom logic error response 
        if (authResult.IsError && authResult.FirstError == Domain.Common.Errors.Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            errors => Problem(errors)
        );
    }

}


