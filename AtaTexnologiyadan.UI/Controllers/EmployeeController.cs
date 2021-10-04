using AtaTexnologiyadan.Entityes.Models;
using AtaTexnologiyadan.Interfaces.FacadeBase;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AtaTexnologiyadan.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeePositionFacade _employeePosition;
        private readonly IEmpoyeeFacade _empoyeeFacade;
        private readonly IContractFacade _contractFacade;
        private readonly string[] mass = new string[] { "Man", "Woman" };

        public EmployeeController(IEmployeePositionFacade employeePosition, IEmpoyeeFacade empoyeeFacade, IContractFacade contractFacade)
        {
            _employeePosition = employeePosition;
            _empoyeeFacade = empoyeeFacade;
            _contractFacade = contractFacade;
        }

        [HttpGet]
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Contracts = _contractFacade.GetAll().ToList();
            employeeViewModel.employeePositions = _employeePosition.GetAll().ToList();
            ViewBag.data = mass;

            return View(employeeViewModel);
        }
        [HttpPost]
        public IActionResult Add(EmployeeAddModel employeeAddModel)
        {
            employeeAddModel.BirthDate = DateTime.UtcNow;
             _empoyeeFacade.Addd(employeeAddModel);
            return RedirectToAction("Index", "Home");
        }
    }
}