using Basic_Operations.Models;
using Basic_Operations.Repository;
using Basic_Operations.RepositoryContract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basic_Operations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }


        [HttpPost]
        public async Task<ActionResult> Create(Employee employee)
        {
             await employeeRepository.InsertOne(employee);
            //return Ok();
            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);

            //return result 
        }

        [HttpGet]

        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var result = await employeeRepository.GetAsync();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(string Id, [FromBody] Employee employee)
        {
            var result = await employeeRepository.UpdateOne(Id,employee);
            return result;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(string Id)
        {
            await employeeRepository.DeleteOne(Id);
            return Ok();
        }
    }
}
