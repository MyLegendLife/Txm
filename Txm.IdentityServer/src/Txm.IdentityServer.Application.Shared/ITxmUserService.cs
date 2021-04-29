using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Txm.IdentityServer.Application.Shared
{
    public interface ITxmUserService
    {
        Task<TxmUserDto> GetAsync(string id);

        Task<IEnumerable<TxmUserDto>> GetListAsync();
    }
}
