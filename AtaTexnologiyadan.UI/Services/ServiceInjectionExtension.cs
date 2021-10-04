using AtaTexnologiyadan.Facades;
using AtaTexnologiyadan.Interfaces.Core;
using AtaTexnologiyadan.Interfaces.FacadeBase;
using AtaTexnologiyadan.Interfaces.ServiceBase.Contract;
using AtaTexnologiyadan.Interfaces.ServiceBase.Employee;
using AtaTexnologiyadan.Interfaces.ServiceBase.EmployeePosition;
using AtaTexnologiyadan.Repostorys;
using AtaTexnologiyadan.Services;
using AtaTexnologiyadan.Services.Contractss;
using AtaTexnologiyadan.Services.EmployeePositionss;
using AtaTexnologiyadan.Services.Employeess;
using AtaTexnologiyadan.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace AtaTexnologiyadan.UI.Services
{
    public static class ServiceInjectionExtension
    {
        public static void InjectionDataBase(this IServiceCollection services)
        {
            #region ::Base::

            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepstory<>), typeof(BaseRepstory<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #endregion ::Base::

            #region ::Service::

            services.AddScoped(typeof(IContractService), typeof(ContractService));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
            services.AddScoped(typeof(IEmployeePositionService), typeof(EmployeePositionService));

            #endregion ::Service::

            services.AddScoped<IContractFacade, ContractFacade>();
            services.AddScoped<IEmployeePositionFacade, EmployeePositionFacade>();
            services.AddScoped<IEmpoyeeFacade, EmpoyeeFacade>();
        }
    }
}