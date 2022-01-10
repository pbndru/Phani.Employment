using Microsoft.AspNetCore.Mvc;
using Phani.Employment.API.Data.Models;
using Phani.Employment.API.Data.Service;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    // GET api/Employees
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> Get()
    {
        var employees = _service.GetAll(); 

        return Ok(employees);
    }

    // GET api/Employees/1
    [HttpGet("{id}")]
    public ActionResult<Employee> Get(Guid id)
    {
        var item = _service.GetById(id);

        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }

    // POST api/Employees
    [HttpPost]
    public ActionResult Post([FromBody] Employee value)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var item = _service.Add(value);
        return CreatedAtAction("Get", new { id = item.Id }, item);
    }

    // DELETE api/Employees/1
    [HttpDelete("{id}")]
    public ActionResult Remove(Guid id)
    {
        var existingItem = _service.GetById(id);

        if (existingItem == null)
        {
            return NotFound();
        }

        _service.Remove(id);
        return Ok();
    }
}