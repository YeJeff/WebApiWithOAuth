using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace WebAPIAndOAuth.Infrastructure
{
    public class EnhancementPasswordValidator : PasswordValidator
    {
        private readonly int MaxContinualCharSize = 0;

        /// <summary>
        /// 初始化不允许连续字符的个数
        /// </summary>
        /// <param name="maxContinualCharSize">不允许连续字符的个数</param>
        public EnhancementPasswordValidator(int maxContinualCharSize)
        {
            MaxContinualCharSize = maxContinualCharSize;
        }
        public override async Task<IdentityResult> ValidateAsync(string pwd)
        {
            IdentityResult result = await base.ValidateAsync(pwd);

            if (pwd.Length < MaxContinualCharSize)
            {
                var errors = result.Errors.ToList();
                errors.Add("不允许连续字符的个数不能大于密码长度");
                result = new IdentityResult(errors);
            }

            if (!pwd.MaxContinualCharValidate(MaxContinualCharSize, true))
            {
                var errors = result.Errors.ToList();
                errors.Add($"密码中不能包含 {MaxContinualCharSize} 个及以上连续的字符或数字");
                result = new IdentityResult(errors);
            }


            return result;
        }
    }
}