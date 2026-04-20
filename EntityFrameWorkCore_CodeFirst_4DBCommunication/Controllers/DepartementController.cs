using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementController : ControllerBase
    {
        private readonly IDepartmentService _deptservice;
        //EmployeeService obj = new EmployeeService();tightlycouplyed

        public DepartementController(IDepartmentService deptservice)//Constructor injection
        {
            _deptservice = deptservice;
        }
        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post([FromBody] DepartementDto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _deptservice.AddDepartments(deptdto);
                    return StatusCode(StatusCodes.Status201Created, empdata);
                }
            }
            catch (Exception ex)
            {//if you got any error we are using this statuscode:Status500InternalServerError
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpDelete]
        [Route("DeleteDepartmentByEmpid/{deptid}")]
        public async Task<IActionResult> delete([FromRoute] int deptid)
        {
            if (deptid < 0)
            {//If input parameters are wrongly sent or empty, we will get 400 badrequest statuscode:Status400BadRequest
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _deptservice.DeleteDepartmentById(deptid);
                if (deptdata == null)
                {//in db if you get empty data we need to retrun this statuscode:Status404NotFound
                    return StatusCode(StatusCodes.Status404NotFound, "deptdata not  found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "deleted successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                var deptdata = await _deptservice.GetDepartments();
                if (deptdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, deptdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }

        }
        [HttpGet]
        [Route("GetDepartmentByDeptid/{deptid}")]
        public async Task<IActionResult> Get(int deptid)
        {
            if (deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var deptdata = await _deptservice.GetDepartmentById(deptid);
                return StatusCode(StatusCodes.Status200OK, deptdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> put([FromBody] DepartementDto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _deptservice.UpdateDepartment(deptdto);
                    return StatusCode(StatusCodes.Status200OK, empdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
    }
}
/*
 * ======syntax for code first approcah updations=======
 Go to Tools=>NugetPackageManger=>PackageManagerConsole=>It will open one console window=>execute below comands stepby step.


PM>Add-Migration MigrationName -Context ContextClassName
 
PM>update-database -Context ContextClassName
============================================================
PM>Add-migration Department -context DepartmentContext
 
PM>update-database -context DepartmentContext
*/