using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCompany.Core.Models.Entities;
using MyCompany.Core.Services;
using MyCompany.Core.Services.Communication.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

namespace MyCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmployeeResource>>> GetAllEmployees()
        {
            var results = await _employeeService.GetAllEmployeesAsync();
            var response = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(results);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EmployeeResource>> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetEmployeeByIdAsync(id);
            if (result == null) return NotFound("Can't find employee with provided id");
            var response = _mapper.Map<Employee, EmployeeResource>(result);
            return Ok(response);
        }

        [HttpGet("/department/{id}/employees")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<EmployeeResource>>> GetAllEmployeesByDepartmentId(int id)
        {
            var result = await _employeeService.GetAllEmployeesByDepartmentIdAsync(id);
            var response = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeResource>>(result);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateAsync([FromBody] SaveEmployeeResource resource)
        {
            if (resource == null) return BadRequest();
            var employeeToAdd = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.CreateAsync(employeeToAdd);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var res = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Created("", resource);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]SaveEmployeeResource resource)
        {
            if (resource == null) return BadRequest();
            var employee = _mapper.Map<SaveEmployeeResource, Employee>(resource);
            var result = await _employeeService.UpdateAsync(id, employee);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var response = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employeeService.DeleteAsync(id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            var response = _mapper.Map<Employee, EmployeeResource>(result.Resource);
            return Ok(response);
        } 
    }
}
