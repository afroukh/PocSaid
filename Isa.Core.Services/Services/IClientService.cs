using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Isa.Core.Repositories.EntityModels;

namespace Isa.Core.Services.Services
{
    public interface IClientService
    {
        IEnumerable<Client> GetClients();
    }
}
