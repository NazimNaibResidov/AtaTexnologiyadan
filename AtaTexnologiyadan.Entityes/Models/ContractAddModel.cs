using System;

namespace AtaTexnologiyadan.Entityes.Models
{
    public class ContractAddModel
    {
        public int ContractNumber { get; set; }
        public DateTime ContractDate { get; set; }
        public decimal Salary { get; set; }

        public string Position { get; set; }
        public string Department { get; set; }
    }
}