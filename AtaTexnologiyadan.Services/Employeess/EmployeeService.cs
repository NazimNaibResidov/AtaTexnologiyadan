using AtaTexnologiyadan.Entityes.Data;
using AtaTexnologiyadan.Interfaces.Core;
using AtaTexnologiyadan.Interfaces.ServiceBase.Employee;

namespace AtaTexnologiyadan.Services.Employeess
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}