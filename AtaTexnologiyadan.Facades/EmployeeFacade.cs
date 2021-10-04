using AtaTexnologiyadan.Entityes.Data;
using AtaTexnologiyadan.Entityes.Models;
using AtaTexnologiyadan.Interfaces.Core;
using AtaTexnologiyadan.Interfaces.FacadeBase;
using AtaTexnologiyadan.Interfaces.ServiceBase.Employee;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Facades
{
    public class EmpoyeeFacade : IEmpoyeeFacade
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUnitOfWork _unitOfWork;

        public EmpoyeeFacade(IEmployeeService employeeService, IUnitOfWork unitOfWork)
        {
            _employeeService = employeeService;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(EmployeeAddModel employeeAddModel)
        {
            await _employeeService.CreateAsync(employeeAddModel);
            _unitOfWork.Commit();
        }
        public void Addd(EmployeeAddModel employeeAddModel)
        {
          
            
            
            _employeeService.CreateAsync(employeeAddModel);
           var result=  _unitOfWork.Commit();
        }
        public async Task<bool> Delete(Employee employee)
        {
            _employeeService.Remvoe(employee);
            return await _unitOfWork.CommitAsync();
        }

        public IQueryable<Employee> GetAll()
        {
            return _employeeService.GetAll();
        }

        public async Task<bool> Update(Employee employee)
        {
            _employeeService.Update(employee);
            return await _unitOfWork.CommitAsync();
        }
    }
}