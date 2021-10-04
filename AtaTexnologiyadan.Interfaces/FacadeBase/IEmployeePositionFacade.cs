using AtaTexnologiyadan.Entityes.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Interfaces.FacadeBase
{
    public interface IEmployeePositionFacade
    {
        Task Add(EmployeePosition employeePosition);

        IQueryable<EmployeePosition> GetAll();

        Task<bool> Delete(EmployeePosition employeePosition);

        Task<bool> Update(EmployeePosition employeePosition);
    }
}