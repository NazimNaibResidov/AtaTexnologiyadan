using System;
using System.ComponentModel;

namespace AtaTexnologiyadan.Entityes.Models
{
    public class ContractViewModel
    {
        public int ContractNumber { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime ContractDate { get; set; }

        public decimal Salary { get; set; }

        public string Position { get; set; }
        public string Department { get; set; }
    }
}