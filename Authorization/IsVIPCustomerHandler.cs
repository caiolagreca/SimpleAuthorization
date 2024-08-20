using Microsoft.AspNetCore.Authorization;

namespace BasicAuthorization.Authorization
{
    public class IsVIPCustomerHandler : AuthorizationHandler<IsAllowedToEditProductRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       IsAllowedToEditProductRequirement requirement)
        {
            if (context.User.HasClaim(f => f.Type == "VIP"))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
