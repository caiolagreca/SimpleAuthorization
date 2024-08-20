using BasicAuthorization.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BasicAuthorization.Authorization
{
    public class DocumentAuthorizationHandler : AuthorizationHandler<SameAuthorRequirement, Products>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                      SameAuthorRequirement requirement,
                                                      Products resource)
        {
            if (context.User.HasClaim(ClaimTypes.NameIdentifier, resource.CreatedUserId))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
