using Microsoft.AspNetCore.Authorization;

namespace BasicAuthorization.Authorization
{
    public class IsAccountNotDisabledHandler : AuthorizationHandler<IsAccountEnabledRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       IsAccountEnabledRequirement requirement)
        {
            if (context.User.HasClaim(f => f.Type == "Disabled"))
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
