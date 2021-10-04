using AtaTexnologiyadan.Entityes.Data;
using System;
using System.Collections.Generic;

namespace AtaTexnologiyadan.Entityes.Models
{
    public class EmployeeViewModel
    {
      
        public ICollection<EmployeePosition> employeePositions { get; set; }
        public ICollection<Contract> Contracts { get; set; }
        
    }
}