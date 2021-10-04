using Microsoft.AspNetCore.Mvc;
using AtaTexnologiyadan.Interfaces.FacadeBase;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using AtaTexnologiyadan.Entityes.Models;

namespace AtaTexnologiyadan.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IContractFacade _contractFacade;
        private readonly IEmpoyeeFacade _empoyeeFacade;

        public HomeController(IContractFacade contractFacade, IEmpoyeeFacade empoyeeFacade)
        {
            _contractFacade = contractFacade;
            _empoyeeFacade = empoyeeFacade;
        }
        public IActionResult Index()
        {
            //var customerData = _empoyeeFacade.GetAll()
            //       .Include(k => k.Contract)
            //       .Include(p => p.EmployeePosition)
            //       .Select(x => new ViewDataModel
            //       {
            //           Name = x.Name,
            //           Surname = x.Surname,
            //           BirthDate =x.BirthDate.ToString("dd mm yyyy"),
            //           PassportNumber = x.PassportNumber,
            //           Gender = x.Gender,
            //           Position = x.EmployeePosition.Name,

            //           ContractNumber = x.Contract.ContractNumber,
            //           ContractDate = x.Contract.ContractDate.ToString("dd mm yyyy"),
            //           Department = x.Contract.Department,
            //           Salary = x.Contract.Salary


            //       }).ToList();
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
        public IActionResult LoadData()
        {

            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count  
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20  
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name  
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)  
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)  
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)  
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                
                // Getting all Customer data  
                var customerData = _empoyeeFacade.GetAll()
                    .Include(k => k.Contract)
                    .Include(p => p.EmployeePosition)
                    .Select(x => new ViewDataModel
                    {
                        Id=x.Id,
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


                    });
                    
                    

                //var customerData = (from tempcustomer in _cVSFacade.GetAll()

                //                    select tempcustomer)
                //                    .AsQueryable();

                //Sorting  
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {

                    customerData = customerData.OrderBy(x => x.Name);
                    //(sortColumn + " " + sortColumnDirection)
                    //customerData = customerData.Where(m => m.Name == searchValue ||
                    //               (m.Name != null && m.Name.StartsWith(searchValue) ||

                    //                m.DateofBirth.ToShortDateString() == searchValue ||
                    //                (m.DateofBirth.ToShortDateString() != null && m.DateofBirth.ToShortDateString().StartsWith(searchValue)) ||

                    //                 m.Phone == searchValue ||
                    //                (m.Phone != null && m.Phone.StartsWith(searchValue)) ||

                    //                m.Married.ToString() == searchValue ||
                    //                (m.Married.ToString() != null && m.Married.ToString().StartsWith(searchValue))));
                }
                //Search  
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Name == searchValue);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Surname == searchValue);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Department == searchValue);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.ContractDate == searchValue);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Position == searchValue);
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.ContractNumber.ToString() == searchValue);
                }
                //total number of rows count   
                recordsTotal = customerData.Count();
                //Paging   
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data  
               // var datas = customerData.ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}