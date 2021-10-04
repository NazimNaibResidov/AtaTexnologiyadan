using System;

namespace AtaTexnologiyadan.Entityes.Data
{
    public class Employee : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

        public string PassportNumber { get; set; }
        
        public string Gender { get; set; }
       
        public int EmployeePositionId { get; set; }
        public EmployeePosition EmployeePosition { get; set; }
      
        public int ContractId { get; set; }
        public Contract Contract { get; set; }
    }
}