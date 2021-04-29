using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Txm.IdentityServer.Application.Shared;
using Txm.IdentityServer.Domain;

namespace Txm.IdentityServer.Application
{
    public class TxmUserService : ITxmUserService
    {
        private readonly IServiceScope _serviceScope;

        public TxmUserService(IServiceScope serviceScope)
        {
            _serviceScope = serviceScope;
        }

        public async Task<TxmUserDto> GetAsync(string id)
        {
           var userManager = _serviceScope.ServiceProvider.GetRequiredService<UserManager<TxmUser>>();

           var user = await userManager.FindByIdAsync(id);

           var fooDto = new Mapper(null).Map<TxmUserDto>(user);

           return fooDto;
        }

        public Task<IEnumerable<TxmUserDto>> GetListAsync()
        {
            throw new NotImplementedException();
        }
    }
}
