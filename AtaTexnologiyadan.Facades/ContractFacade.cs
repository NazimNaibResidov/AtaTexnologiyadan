using AtaTexnologiyadan.Entityes.Data;
using AtaTexnologiyadan.Entityes.Models;
using AtaTexnologiyadan.Interfaces.Core;
using AtaTexnologiyadan.Interfaces.FacadeBase;
using AtaTexnologiyadan.Interfaces.ServiceBase.Contract;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Facades
{
    public class ContractFacade : IContractFacade
    {
        private readonly IContractService _contractService;
        private readonly IUnitOfWork _unitOfWork;

        public ContractFacade(IContractService contractService, IUnitOfWork unitOfWork)
        {
            _contractService = contractService;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(ContractAddModel contractAddModel)
        {
           
            await _contractService.CreateAsync(contractAddModel);
            Task.Delay(100);
            _unitOfWork.Commit();
        }

        public async Task<bool> Delete(Contract contract)
        {
            _contractService.Remvoe(contract);
            return await _unitOfWork.CommitAsync();
        }

        public IQueryable<Contract> GetAll()
        {
            return _contractService.GetAll();
        }

        public async Task<bool> Update(Contract contract)
        {
            _contractService.Update(contract);
            return await _unitOfWork.CommitAsync();
        }
    }
}