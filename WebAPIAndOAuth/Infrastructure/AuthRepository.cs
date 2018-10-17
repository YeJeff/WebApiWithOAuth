using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using WebAPIAndOAuth.Models;

namespace WebAPIAndOAuth.Infrastructure
{
    public class AuthRepository : IDisposable
    {
        private readonly AuthDbContext _db;
        private readonly AppUserManager _userMgr;

        public AuthRepository()
        {
            _db = new AuthDbContext();
            _userMgr = new AppUserManager(new UserStore<AppUser>(_db));
        }

        /// <summary>
        /// 添加RefreshToken
        /// </summary>
        /// <param name="token"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<bool> AddRefreshTokenAsync(AppRefreshToken token)
        {
            var existedToken = await _db.RefreshTokens
                .Where(t => t.Subject == token.Subject && t.ClientId == token.ClientId)
                .SingleOrDefaultAsync();
            if (!(existedToken is null))
            {
                var result = await RemoveRefreshTokenAsync(existedToken.Id);
            }
            _db.RefreshTokens.Add(token);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshTokenAsync(string tokenId)
        {
            var token = await _db.RefreshTokens.FindAsync(tokenId);
            if (!(token is null))
            {
                _db.RefreshTokens.Remove(token);
                return await _db.SaveChangesAsync() > 0;
            }
            return false;
        }

        public async Task<bool> RemoveRefreshTokenAsync(AppRefreshToken token)
        {
            _db.RefreshTokens.Remove(token);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<AppRefreshToken> FindSingleRefreshTokenAsync(string tokenId)
        {
            return await _db.RefreshTokens.FindAsync(tokenId);
        }

        public void Dispose()
        {
            _db.Dispose();
            _userMgr.Dispose();
        }
    }
}