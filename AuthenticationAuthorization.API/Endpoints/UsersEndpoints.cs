using AuthenticationAuthorization.API.Contracts;
using AuthenticationAuthorization.Services.Business;

namespace AuthenticationAuthorization.API
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);

            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(RegisterUserRequest registerUserRequest, AuthorizationService authorizationService)
        {
            var result = await authorizationService.Register(registerUserRequest.name, registerUserRequest.login, registerUserRequest.password, registerUserRequest.password);

            if (result)
                return Results.Ok();
            else
                return Results.BadRequest();
        }

        private static async Task<IResult> Login(LoginUserRequest loginUserRequest, AuthorizationService authorizationService)
        {
            var token = await authorizationService.Login(loginUserRequest.login, loginUserRequest.password);

            return Results.Ok(token);
        }
    }
}
