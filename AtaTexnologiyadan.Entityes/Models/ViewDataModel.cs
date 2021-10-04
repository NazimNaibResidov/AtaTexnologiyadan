using System;
using System.Collections.Generic;
using System.Text;

namespace AtaTexnologiyadan.Entityes.Models
{
   public class ViewDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }

        public string PassportNumber { get; set; }
        public string Position { get; set; }
        public string Gender { get; set; }

       

        public int ContractNumber { get; set; }

        
        public string ContractDate { get; set; } 

        public decimal Salary { get; set; }

       
        public string Department { get; set; }
    }
}
