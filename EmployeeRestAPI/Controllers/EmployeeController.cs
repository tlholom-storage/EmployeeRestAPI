using EmployeeRestAPI.Interface;
using EmployeeRestAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeController(IEmployeeRepo employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await this._employeeRepo.GetEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await this._employeeRepo.GetEmployeeById(id);
            return Ok(employee);
        }


        [HttpPost]
        public async Task<IActionResult> PostEmployee(Employee employee)
        {
            await this._employeeRepo.InsertEmployee(employee);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            await this._employeeRepo.UpdateEmployee(employee);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            await this._employeeRepo.DeleteEmployeeById(id);
            return Ok();
        }
    }
}
