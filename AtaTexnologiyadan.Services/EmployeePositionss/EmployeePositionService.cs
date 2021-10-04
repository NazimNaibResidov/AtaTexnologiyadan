using AtaTexnologiyadan.Entityes.Data;
using AtaTexnologiyadan.Interfaces.Core;
using AtaTexnologiyadan.Interfaces.ServiceBase.EmployeePosition;

namespace AtaTexnologiyadan.Services.EmployeePositionss
{
    public class EmployeePositionService : BaseService<EmployeePosition>, IEmployeePositionService
    {
        public EmployeePositionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}