﻿
using Microsoft.AspNetCore.Authorization;

namespace CookingBook.Application.Authorization;

public enum ResourceOperation
{
    Create,
    Read,
    Update,
    Delete
}


public class ResourceOperationRequirement  : IAuthorizationRequirement
{
    public ResourceOperation ResourceOperation { get; set; }
    
    public ResourceOperationRequirement(ResourceOperation resourceOperation)
    {
        ResourceOperation = resourceOperation;
    }
    
}