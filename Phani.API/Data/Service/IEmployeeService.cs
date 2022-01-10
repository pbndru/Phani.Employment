using Phani.Employment.API.Data.Models;
using System;
using System.Collections.Generic;

namespace Phani.Employment.API.Data.Service
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAll();
        Employee Add(Employee employee);
        Employee GetById(Guid id);
        void Remove(Guid id);
    }
}
