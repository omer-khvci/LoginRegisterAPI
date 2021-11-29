using System.Security.Claims;
using System.Security.Principal;

namespace SayfamaHosgeldinAPI.Infrastructure
{
    public static class UserExtension
    {
        public static long GetUserId(this IIdentity claims)
        {
            return Convert.ToInt64((claims as ClaimsIdentity).Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid.ToString())?.Value);
        }
    }
}
