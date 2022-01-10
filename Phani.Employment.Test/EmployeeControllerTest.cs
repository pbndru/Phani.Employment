using Microsoft.AspNetCore.Mvc;
using Phani.Employment.API.Data.Models;
using Phani.Employment.API.Data.Service;
using System.Collections.Generic;
using Xunit;

namespace Phani.Employment.Test
{
    public class EmployeeControllerTest
    {
        EmployeeController _controller;
        IEmployeeService _service;

        public EmployeeControllerTest()
        {
            _service = new EmployeeService();
            _controller = new EmployeeController(_service);
        }

        [Fact]
        public void GetAllTest()
        {
            var result = _controller.Get();
            //check response type
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;
            Assert.IsType<List<Employee>>(list.Value);

            var listEmployees = list.Value as List<Employee>;
            Assert.Equal(4, listEmployees.Count);
        }
    }
}
