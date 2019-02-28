using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;
using WebStore.Entities.Identity;
using WebStore.Interfaces.Services;

namespace WebStore.Clients.Services.Users
{
    public class UsersClient : BaseClient, IUsersClient
    {
        public UsersClient(IConfiguration configuration) : base(configuration) => ServiceAddress = "api/users";


        #region Implementation of IUserStore<User>

        public async Task<string> GetUserIdAsync(User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{ServiceAddress}/UserId", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel);
        }

        public async Task<string> GetUserNameAsync(User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{ServiceAddress}/UserName", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel);
        }

        public async Task SetUserNameAsync(User user, string name, CancellationToken cancel)
        {
            user.UserName = name;
            await PostAsync($"{ServiceAddress}/UserName/{name}", user, cancel);
        }

        public async Task<string> GetNormalizedUserNameAsync(User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{ServiceAddress}/NormalUserName/", user, cancel))
                .Content
                .ReadAsAsync<string>(cancel);
        }

        public async Task SetNormalizedUserNameAsync(User user, string name, CancellationToken cancel)
        {
            user.NormalizedUserName = name;
            await PostAsync($"{ServiceAddress}/NormalUserName/{name}", user, cancel);
        }

        public async Task<IdentityResult> CreateAsync(User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{ServiceAddress}/User", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel) 
                    ? IdentityResult.Success 
                    : IdentityResult.Failed();
        }

        public async Task<IdentityResult> UpdateAsync(User user, CancellationToken cancel)
        {
            return await (await PutAsync($"{ServiceAddress}/User", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();
        }

        public async Task<IdentityResult> DeleteAsync(User user, CancellationToken cancel)
        {
            return await (await PostAsync($"{ServiceAddress}/User/Delete", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel)
                ? IdentityResult.Success
                : IdentityResult.Failed();
        }

        public async Task<User> FindByIdAsync(string id, CancellationToken cancel) => 
            await GetAsync<User>($"{ServiceAddress}/User/FindById/{id}", cancel);

        public async Task<User> FindByNameAsync(string name, CancellationToken cancel) =>
            await GetAsync<User>($"{ServiceAddress}/User/Normal/{name}", cancel);

        #endregion

        #region Implementation of IUserRoleStore<User>

        public async Task AddToRoleAsync(User user, string role, CancellationToken cancel) => 
            await PostAsync($"{ServiceAddress}/Role/{role}", user, cancel);

        public async Task RemoveFromRoleAsync(User user, string role, CancellationToken cancel) =>
            await PostAsync($"{ServiceAddress}/Role/Delete/{role}", user, cancel);

        public async Task<IList<string>> GetRolesAsync(User user, CancellationToken cancel) =>
            await (await PostAsync($"{ServiceAddress}/roles", user, cancel))
                .Content
                .ReadAsAsync<IList<string>>(cancel);

        public async Task<bool> IsInRoleAsync(User user, string role, CancellationToken cancel) =>
            await (await PostAsync($"{ServiceAddress}/InRole/{role}", user, cancel))
                .Content
                .ReadAsAsync<bool>(cancel);

        public async Task<IList<User>> GetUsersInRoleAsync(string role, CancellationToken cancel) =>
            await GetAsync<List<User>>($"{ServiceAddress}/UsersInRole/{role}", cancel);

        #endregion

        #region Implementation of IUserPasswordStore<User>

        public async Task SetPasswordHashAsync(User user, string hash, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetPasswordHashAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> HasPasswordAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IUserEmailStore<User>

        public async Task SetEmailAsync(User user, string email, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetEmailAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetEmailConfirmedAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task SetEmailConfirmedAsync(User user, bool confirmed, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByEmailAsync(string email, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetNormalizedEmailAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task SetNormalizedEmailAsync(User user, string email, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IUserPhoneNumberStore<User>

        public async Task SetPhoneNumberAsync(User user, string phone, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetPhoneNumberAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetPhoneNumberConfirmedAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task SetPhoneNumberConfirmedAsync(User user, bool confirmed, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IUserLoginStore<User>

        public async Task AddLoginAsync(User user, UserLoginInfo login, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveLoginAsync(User user, string LoginProvider, string ProviderKey, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<User> FindByLoginAsync(string LoginProvider, string ProviderKey, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IUserLockoutStore<User>

        public async Task<DateTimeOffset?> GetLockoutEndDateAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task SetLockoutEndDateAsync(User user, DateTimeOffset? EndDate, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<int> IncrementAccessFailedCountAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task ResetAccessFailedCountAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetAccessFailedCountAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetLockoutEnabledAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task SetLockoutEnabledAsync(User user, bool enabled, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IUserTwoFactorStore<User>

        public async Task SetTwoFactorEnabledAsync(User user, bool enabled, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GetTwoFactorEnabledAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IUserClaimStore<User>

        public async Task<IList<Claim>> GetClaimsAsync(User user, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task AddClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task ReplaceClaimAsync(User user, Claim OldClaim, Claim NewClaim, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveClaimsAsync(User user, IEnumerable<Claim> claims, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<User>> GetUsersForClaimAsync(Claim claim, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IDisposable

        void IDisposable.Dispose() { }

        #endregion

    }
}
