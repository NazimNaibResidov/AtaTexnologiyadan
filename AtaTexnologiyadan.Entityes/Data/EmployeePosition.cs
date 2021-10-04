using System.Collections.Generic;

namespace AtaTexnologiyadan.Entityes.Data
{
    public class EmployeePosition : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; set; }

        //public Employee   Employees { get; set; }
        //public int EmployeeId { get; set; }

        //public Contract Contracts { get; set; }
        //public int ContractId { get; set; }
    }
}