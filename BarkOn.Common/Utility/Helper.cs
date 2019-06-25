using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace BarkOn.Common.Utility
{
    public static class Helper
    {
        public static string GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            return httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
