using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace AtaTexnologiyadan.Entityes.Data
{
    public class Contract : BaseEntity<int>
    {
        public int ContractNumber { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime ContractDate { get; set; } = DateTime.Now;

        public decimal Salary { get; set; }

        public string Position { get; set; }
        public string Department { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}