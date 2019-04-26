using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Isa.Core.Repositories;
using Isa.Core.Repositories.EntityModels;
using Isa.Core.Services.Services;

namespace Isa.Infrastructures.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        

        public IEnumerable<Client> GetClients()
        {
            return _unitOfWork.ClientRepository.GetAll();
        }

      
    }
}