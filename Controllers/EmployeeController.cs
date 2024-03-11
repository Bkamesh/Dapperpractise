using Dapperpractise.Models;
using Dapperpractise.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dapperpractise.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _emp;
        public EmployeeController(EmployeeService emp)
        {
            _emp = emp;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            var empl = await _emp.Get();
            if (empl.Count > 0)
            {
                return Ok(empl);
            }
            else
            {
                return Ok("Nothing is there");
            }
        }

        [HttpGet("Id:int")]
        public async Task<IActionResult> Getid(int id) 
        {
            var empl = await _emp.Getid(id); 
            if (empl.Count >0) 
            {
                return Ok(empl);
            }
            else
            {
                return Ok("Not found");
            }
        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Employee emp)
        {
            int empl = await _emp.Insert(emp);
            return Ok(empl);
        }

        [HttpDelete("Id:int")]
        public async Task<IActionResult> Delete(int Id)
        {
            int empl = await _emp.Delete(Id);
            if (empl > 0)
            {
                return Ok(empl);
            }
            else
            {
                return Ok("Not Found");
            }
        }

        [HttpPut("Id:int")]
        public async Task<IActionResult> Update(Employee emp)
        {
            var empl = await _emp.Update(emp);
            if (empl > 0)
            {
                return Ok(empl);
            }
            else
            {
                return Ok("Not Found");
            }
        }

    }
}

