using AtaTexnologiyadan.Entityes.Data;
using AtaTexnologiyadan.Interfaces.Core;
using AtaTexnologiyadan.Interfaces.FacadeBase;
using AtaTexnologiyadan.Interfaces.ServiceBase.EmployeePosition;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.Facades
{
    public class EmployeePositionFacade : IEmployeePositionFacade
    {
        private readonly IEmployeePositionService _employeePositionService;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeePositionFacade(IEmployeePositionService employeePositionService, IUnitOfWork unitOfWork)
        {
            _employeePositionService = employeePositionService;
            _unitOfWork = unitOfWork;
        }

        public async Task Add(EmployeePosition employeePosition)
        {
            await _employeePositionService.CreateAsync(employeePosition);
            _unitOfWork.Commit();
        }

        public async Task<bool> Delete(EmployeePosition employeePosition)
        {
            _employeePositionService.Remvoe(employeePosition);
            return await _unitOfWork.CommitAsync();
        }

        public IQueryable<EmployeePosition> GetAll()
        {
            return _employeePositionService.GetAll();
        }

        public async Task<bool> Update(EmployeePosition employeePosition)
        {
            _employeePositionService.Update(employeePosition);
            return await _unitOfWork.CommitAsync();
        }
    }
}