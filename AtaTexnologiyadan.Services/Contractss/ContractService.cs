using AtaTexnologiyadan.Entityes.Data;
using AtaTexnologiyadan.Interfaces.Core;
using AtaTexnologiyadan.Interfaces.ServiceBase.Contract;

namespace AtaTexnologiyadan.Services.Contractss
{
    public class ContractService : BaseService<Contract>, IContractService
    {
        public ContractService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}