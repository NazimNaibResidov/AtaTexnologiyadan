using System;
using System.Collections.Generic;

namespace AtaTexnologiyadan.Entityes.Models
{
    public class EmployeeAddModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string PassportNumber { get; set; }
    
        public int EmployeePositionId { get; set; }
        
        public int ContractId { get; set; }
    }
}