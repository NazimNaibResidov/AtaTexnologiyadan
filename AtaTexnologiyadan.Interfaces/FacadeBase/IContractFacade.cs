using AtaTexnologiyadan.Entityes.Data;
using AtaTexnologiyadan.Entityes.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Interfaces.FacadeBase
{
    public interface IContractFacade
    {
        Task Add(ContractAddModel contractAddModel);

        IQueryable<Contract> GetAll();

        Task<bool> Delete(Contract contract);

        Task<bool> Update(Contract contract);
    }
}