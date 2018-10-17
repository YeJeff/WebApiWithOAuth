using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIAndOAuth.Infrastructure
{
    public class EnhancementUserValidator:UserValidator<AppUser>
    {
        public EnhancementUserValidator(AppUserManager userMgr) : base(userMgr) { }

        public override async Task<IdentityResult> ValidateAsync(AppUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);

            if (!user.Email.ToLower().EndsWith("@qq.com"))
            {
                List<string> errors = result.Errors.ToList();
                errors.Add("Only qq.com email address are allowed");
                result = new IdentityResult(errors);
            }

            return result;
        }
    }
}