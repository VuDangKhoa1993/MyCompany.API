using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCompany.API.Resources;
using MyCompany.API.Response;
using MyCompany.Core.Models.Entities;
using MyCompany.Core.Services;
using MyCompany.Core.Services.Communication.Resources;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation("Query a list of the department")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DepartmentResource>>> ListAsync()
        {
            var result = await _departmentService.GetAllDepartmentsAsync();

            var response = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(result);
           
            return Ok(response);
        }

        /// <summary>
        /// department id
        /// </summary>
        /// <param name="id">department id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerOperation("Query a department detail by id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DepartmentResource>> GetDepartmentById(int id)
        {
            var result = await _departmentService.GetDepartmentById(id);
            
            if (result == null) return NotFound($"Cann't find department with provided id");
            
            var response = _mapper.Map<Department, DepartmentResource>(result);
            
            return Ok(response);
        }

        [HttpGet("/employee/{id}/departments")]
        [SwaggerOperation("Query all departments belong to an employee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<DepartmentResource>>> ListDepartmentsWithEmployeeId(int id)
        {
            var result = await _departmentService.GetAllDepartmentsByEmployeeIdAsync(id);
            
            var response = _mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentResource>>(result);
            
            return Ok(response);
        }

        /// <summary>
        /// Post api
        /// </summary>
        /// <param name="resource">saved department</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation("Creating a new department")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] SaveDepartmentResource resource) 
        {
            if (resource == null)
            {
                return BadRequest("Invalid Model");
            }
           
            var departmentToAdd = _mapper.Map<SaveDepartmentResource, Department>(resource);
           
            var result = await _departmentService.CreateAsync(departmentToAdd);
            
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            var response = _mapper.Map<Department, DepartmentResource>(result.Resource);

            return CreatedAtAction(nameof(CreateAsync), "Department", new { departmentId = response.DepartmentId }, resource);
        }

        [HttpPut("{id}")]
        [SwaggerOperation("Updating a existing department by id")]
        [ProducesResponseType(typeof(DepartmentResource), 200)]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] SaveDepartmentResource resource)
        {
            if(resource == null)
            {
                return BadRequest("Invalid model");
            }
            var department = _mapper.Map<SaveDepartmentResource, Department>(resource);

            var result = await _departmentService.UpdateAsync(id, department);
            
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            var response = _mapper.Map<Department, DepartmentResource>(result.Resource);
            
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation("Deleting a existing department")]
        [ProducesResponseType(typeof(DepartmentResource), 200)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _departmentService.DeleteAsync(id);
            if(!result.Success)
            {
                return BadRequest(result.Message);
            }
            var response = _mapper.Map<Department, DepartmentResource>(result.Resource);
            return Ok(response);
        }
    }
}
