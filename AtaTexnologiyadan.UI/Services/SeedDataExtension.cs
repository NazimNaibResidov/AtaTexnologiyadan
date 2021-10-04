using AtaTexnologiyadan.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtaTexnologiyadan.UI.Services
{
    public static class SeedDataExtension
    {
        public static void SeedData(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<MainDataDBContext>();
            context.Database.Migrate();
            if (!context.Contracts.Any())
            {
                context.Contracts.AddRange(new Entityes.Data.Contract
                {
                    ContractDate = DateTime.Now,
                    ContractNumber = 1324567,
                    Department = "Main",
                    Position = "Frist",
                    Salary = 14356,

                },
                new Entityes.Data.Contract
                {
                    ContractDate = DateTime.Now,
                    ContractNumber = 1324567,
                    Department = "Second",
                    Position = "Data",
                    Salary = 143587,

                }
                );
                context.SaveChanges();
            }
            if (!context.EmployeePositions.Any())
            {
                context.EmployeePositions.AddRange(new Entityes.Data.EmployeePosition
                {
                    Name = "Mudur"
                },
                new Entityes.Data.EmployeePosition
                {
                    Name = "Reyis"
                });
                context.SaveChanges();
            }
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(new Entityes.Data.Employee
                {
                    BirthDate = DateTime.Now,
                    ContractId = 1,
                    EmployeePositionId = 1,
                    Gender = "Man",
                    Name = "Men",
                    Surname = "Ozum",
                    PassportNumber = "145676"
                   
                },
                new Entityes.Data.Employee
                {
                    BirthDate = DateTime.Now,
                    ContractId = 2,
                    EmployeePositionId = 2,
                    Gender = "Men",
                    Name = "sen",
                    Surname = "Ozum",
                    PassportNumber = "145676"

                });
                context.SaveChanges();
            }
           
        }
    }
}

