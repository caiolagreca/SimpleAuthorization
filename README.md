# SimpleAuthorization

In this exercise To create a new product in a portal the user must satisfy the following conditions:
1. The user is an employee of the Organization. Carry an Employee claim.
2. The user is a VIP Customer. Carry an VIP Claim.
3. But, the user is not allowed to post if his account is disabled due to bad reviews. The disabled account carry Disabled claim.

This conditions represent a policy. We call it as canManageProduct policy.
So we have three handlers:
1. IsEmployeeHandler
2. IsVIPCustomerHandler
3. IsAccountNotDisabledHandler

We can create a single handler and test all of the above. That will serve our purpose for this tutorial. But in a real-world application, you need to look at reusing the handlers in another requirement. Hence it makes sense to split it up into smaller pieces.

In the above, if IsEmployeeHandler AND IsVIPCustomerHandler returns true, then the user can edit the Product. Hence these two falls under a single requirement.
But the IsAccountNotDisabledHandler is different. If the Account is disabled, then the user must not be allowed to create the Product. Hence it must return Fail.

- IsAllowedToEditProductRequirement:
IsEmployeeHandler returns sucess, else nothing
IsVIPCustomerHandler returns sucess, else nothing
IsAccountNotDisabledHandler returns fail, else nothing

Another way to build the requirement is by creating the two requirements.

- IsAllowedToEditProductRequirement:
IsEmployeeHandler returns sucess, else nothing
IsVIPCustomerHandler returns sucess, else nothing

- IsAccountEnabledRequirement:
IsAccountNotDisabledHandler returns true else nothing

In the second method, we can make use of IsAccountEnabledRequirement in another Policy.