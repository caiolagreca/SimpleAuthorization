using Microsoft.AspNetCore.Authorization;

namespace BasicAuthorization.Authorization
{
    //The handlers must inherit from the AuthorizationHandler. It has one method HandleRequirementAsync.
    public class IsEmployeeHandler : AuthorizationHandler<IsAllowedToEditProductRequirement>
    {
        //The signature of the HandleRequirementAsync: We get the context and the requirement that is being checked as the parameter. The context class has User(ClaimPrincipal) object. We use that to check whether the user has any claim.
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       IsAllowedToEditProductRequirement requirement)
        {
            if (context.User.HasClaim(f => f.Type == "Employee"))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
