using AtaTexnologiyadan.Entityes.Data;
using AtaTexnologiyadan.Interfaces.FacadeBase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.UI.Controllers
{
    public class EmployeePositionController1 : Controller
    {
        private readonly IEmployeePositionFacade _employeePositionFacade;
        public EmployeePositionController1(IEmployeePositionFacade employeePositionFacade)
        {
            this._employeePositionFacade = employeePositionFacade;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(EmployeePosition employeePosition)
        {
            _employeePositionFacade.Add(employeePosition);
            return View();
        }
    }
}
