using Phani.Employment.API.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Phani.Employment.API.Data.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = new Guid("9d81a1e5-a7fa-45b5-8d17-80b4b9717864"),
                    Title="Developer",
                    Description="Develop Applications",
                    Name= "Phani Bandaru",
                },
                new Employee()
                {
                    Id= new Guid("c470059b-0d20-46dd-ab0b-6fffb2d4381e"),
                    Title="Tester",
                    Description="Testing Applications",
                    Name= "Test Tester",
                },
                new Employee()
                {
                    Id= new Guid("55d87af7-270e-49dd-92ce-622f5f477b8d"),
                    Title="Business Analyst",
                    Description="Business Analyst",
                    Name= "Business Analyst"
                },
                new Employee()
                {
                    Id =  new Guid("016d62ca-deab-4340-90ad-f357eb7c09cb"),
                    Title = "DevOPs Selfish Gene",
                    Description = "DevOPs",
                    Name = "DevOPs"
                }
            };
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employees;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _employees.Add(employee);
            return employee;
        }

        public Employee GetById(Guid id) => _employees.Where(a => a.Id == id).FirstOrDefault();

        public void Remove(Guid id)
        {
            var existing = _employees.First(a => a.Id == id);
            _employees.Remove(existing);
        }
    }
}
