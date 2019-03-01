using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;

namespace WebStore.Clients.Services
{
    public class RolesClient : BaseClient, IRoleStore<IdentityRole>
    {
        public RolesClient(IConfiguration configuration) : base(configuration) => ServiceAddress = "api/Roles";

        #region Implementation of IRoleStore<IdentityRole>

        public async Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task SetRoleNameAsync(IdentityRole role, string name, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task SetNormalizedRoleNameAsync(IdentityRole role, string name, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityRole> FindByIdAsync(string id, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityRole> FindByNameAsync(string name, CancellationToken cancel)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Implementation of IDisposable

        public void Dispose() => _Client.Dispose();

        #endregion
    }
}
