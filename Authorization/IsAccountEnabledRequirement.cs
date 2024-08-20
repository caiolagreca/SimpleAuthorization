using Microsoft.AspNetCore.Authorization;

namespace BasicAuthorization.Authorization
{
    //A Requirement class must implement IAuthorizationRequirement. It does not contain any methods or properties. Hence we do not need to implement anything.
    //If the Requirement needs any input, then you can add a public constructor with the input.
    public class IsAccountEnabledRequirement : IAuthorizationRequirement
    {
    }
}
