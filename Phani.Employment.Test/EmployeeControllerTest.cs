using Microsoft.AspNetCore.Mvc;
using Phani.Employment.API.Data.Models;
using Phani.Employment.API.Data.Service;
using System;
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

        [Theory]
        [InlineData("9d81a1e5-a7fa-45b5-8d17-80b4b9717864")]
        public void GetEmployeeByIdTest(string guid)
        {
            //Arrange
            var validGuid = new Guid(guid);

            //Act
            var okResult = _controller.Get(validGuid);

            //Assert
            Assert.IsType<OkObjectResult>(okResult.Result);

            //check the result is ok object
            var item = okResult.Result as OkObjectResult;

            //check if it returns single result
            Assert.IsType<Employee>(item.Value);

            //check the values
            var employee = item.Value as Employee;
            Assert.Equal(validGuid, employee.Id);
            Assert.Equal("Phani Bandaru", employee.Name);
            Assert.Equal("Developer", employee.Title);
        }


        [Theory]
        [InlineData("9981a1e5-a7fa-45b5-8d17-80b4b9717864")]
        public void GetEmployeeByIncorrectIdTest(string incorrectGuid)
        {
            //Arrange
            var invalidGuid = new Guid(incorrectGuid);

            //Act
            var notFoundResult = _controller.Get(invalidGuid);

            //Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void AddEmployeeTest()
        {
            //Arrange
            var employee = new Employee()
            {
                Title = "tester",
                Name = "test",
                Description = "tester"
            };

            //Act
            var createdResponse = _controller.Post(employee);
             
            //Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);

            //value of the result
            var item = createdResponse as CreatedAtActionResult;
            Assert.IsType<Employee>(item.Value);

            //check value of this Employee
            var employeeItem = item.Value as Employee;
            Assert.Equal(employee.Name, employeeItem.Name);
            Assert.Equal(employee.Description, employeeItem.Description);
            Assert.Equal(employee.Title, employeeItem.Title);
        }

        [Fact]
        public void AddIncorrectEmployeeTest()
        {
            //Arrange
            var employee = new Employee()
            {
                Name = "test",
                Description = "tester"
            };

            //Act
            _controller.ModelState.AddModelError("Title", "Title is a requried filed");
            var badResponse = _controller.Post(employee);

            //Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
    }
}