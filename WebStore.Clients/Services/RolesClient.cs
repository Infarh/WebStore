using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using WebStore.Clients.Base;

namespace WebStore.Clients.Services
{
    public class RolesClient : BaseClient
    {
        public RolesClient(IConfiguration configuration) : base(configuration) => ServiceAddress = "api/Roles";
    }
}
