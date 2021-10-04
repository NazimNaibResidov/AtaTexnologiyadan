using AtaTexnologiyadan.Entityes.Models;
using AtaTexnologiyadan.Interfaces.FacadeBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AtaTexnologiyadan.UI.Controllers
{
    public class ContractController : Controller
    {
        private readonly IContractFacade _contractFacade;
        private readonly IEmpoyeeFacade _empoyeeFacade;

        public ContractController(IContractFacade contractFacade, IEmpoyeeFacade empoyeeFacade)
        {
            this._contractFacade = contractFacade;
            this._empoyeeFacade = empoyeeFacade;
        }

        public IActionResult Index()
        {
           var _result= _contractFacade.GetAll()
                .ToList();
            return View(_result);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ContractAddModel contractAddModel)
        {
            contractAddModel.ContractDate = DateTime.UtcNow;
            _contractFacade.Add(contractAddModel);
            return View();
        }
        public IActionResult Find(int id)
        {
           var _result= _empoyeeFacade.GetAll()
                .Include(x=>x.Contract)
                .Include(p => p.EmployeePosition)
                .Where(x=>x.ContractId==id)
                .Select(x => new ViewDataModel
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    BirthDate = x.BirthDate.ToString("dd mm yyyy"),
                    PassportNumber = x.PassportNumber,
                    Gender = x.Gender,
                    Position = x.EmployeePosition.Name,

                    ContractNumber = x.Contract.ContractNumber,
                    ContractDate = x.Contract.ContractDate.ToString("dd mm yyyy"),
                    Department = x.Contract.Department,
                    Salary = x.Contract.Salary


                }).ToList();

            return View(_result);
        }
    }
}