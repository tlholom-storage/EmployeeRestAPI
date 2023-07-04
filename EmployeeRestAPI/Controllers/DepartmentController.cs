using EmployeeRestAPI.Interface;
using EmployeeRestAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _departmentRepo;
        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }


        [HttpGet]
        public async Task<IActionResult> GetDepartments()
        {
            var deparments = await this._departmentRepo.GetDepartments();
            return Ok(deparments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var deparment = await this._departmentRepo.GetDepartmentById(id);
            return Ok(deparment);
        }


        [HttpPost]
        public async Task<IActionResult> PostDeparment(Department department)
        {
            await this._departmentRepo.InsertDepartment(department);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            await this._departmentRepo.UpdateDepartment(department);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDeparment(int id)
        {
            await this._departmentRepo.DeleteDepartmentById(id);
            return Ok();
        }
    }
}
