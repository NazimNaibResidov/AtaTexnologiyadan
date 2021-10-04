using AtaTexnologiyadan.Entityes.Data;
using AtaTexnologiyadan.Entityes.Models;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Interfaces.FacadeBase
{
    public interface IEmpoyeeFacade
    {
        Task Add(EmployeeAddModel employeeAddModel);
        void Addd(EmployeeAddModel employeeAddModel);

        IQueryable<Employee> GetAll();

        Task<bool> Delete(Employee employee);

        Task<bool> Update(Employee employee);
    }
}