using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Models;
using Users.UsersData;

namespace Users.Controllers
{
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IUserData _UserData;
        public DepartmentController(IUserData userData)
        {
            _UserData = userData;
        }

        [HttpGet]
        [Route("api/[controller]/GetDepartments")]
        public IActionResult GetDepartments()
        {
            return Ok(_UserData.GetDeparments());
        }

        [HttpGet]
        [Route("api/[controller]/getDepartment/{id}")]
        public IActionResult getDeparment(int department_id)
        {
            var department = _UserData.GetDeparment(department_id);

            if (department != null)
            {
                return Ok(department);
            }

            return NotFound($"Department with id: {department_id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]/AddDepartment")]
        public IActionResult AddDepartment(Department department)
        {
            _UserData.AddDeparment(department);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + department.Department_ID,
                department);
        }


        [HttpDelete]
        [Route("api/[controller]/DeleteDepartment/{id}")]
        public IActionResult DeleteDepartment(int department_id)
        {
            var department = _UserData.GetDeparment(department_id);

            if (department != null)
            {
                _UserData.DeleteDeparment(department);
                return Ok();
            }

            return NotFound($"Department Adress with id: {department_id} was not found");
        }

        [HttpPut]
        [Route("api/[controller]/EditDepartment/{id}")]
        public IActionResult EditDepartment(int department_id, Department department)
        {
            var ExistingDepartment = _UserData.GetDeparment(department_id);

            if (ExistingDepartment != null)
            {
                department.Department_ID = ExistingDepartment.Department_ID;
                _UserData.EditDeparment(department);
                return Ok();
            }

            return Ok(department);
        }
    }
}