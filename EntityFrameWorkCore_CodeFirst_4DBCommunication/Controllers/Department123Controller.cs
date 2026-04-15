using EntityFrameWorkCore_CodeFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_CodeFirst_4DBCommunication.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameWorkCore_CodeFirst_4DBCommunication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Department123Controller : ControllerBase
    {
        private readonly IDepartmentService123 _departmentService123;
        public Department123Controller(IDepartmentService123 departmentService123)
        {
            _departmentService123= departmentService123;
        }
        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post([FromBody] Department123Dto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {//we are passing the data to service layer
                    var empdata = await _departmentService123.AddDepartments(deptdto);
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
                var deptdata = await _departmentService123.DeleteDepartmentById(deptid);
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
                var deptdata = await _departmentService123.GetDepartments();
                if (deptdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "deptdata not  found");
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
                var deptdata = await _departmentService123.GetDepartmentById(deptid);
                return StatusCode(StatusCodes.Status200OK, deptdata);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server eror");
            }
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> put([FromBody] Department123Dto deptdto)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var empdata = await _departmentService123.UpdateDepartment(deptdto);
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
