using BLL.DTO;
using BLL.Intrefaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/Role")]
    public class RoleController : ApiController
    {
        private IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/Role
        public IHttpActionResult GetRoles()
        {
            return Ok(_roleService.GetAll());
        }

        // DELETE: api/Role/5
        [HttpDelete]
        public IHttpActionResult DeleteRole(int id)
        {
            RoleDTO roleToDel = _roleService.GetById(id);

            if (roleToDel == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"Role with id={id} does not exist.");
            }

            this._roleService.Delete(id);

            return Ok();
        }

        // POST: api/Role
        [HttpPost]
        public IHttpActionResult AddRole([FromBody] RoleBindingModel role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RoleDTO newRole = new RoleDTO()
            {
                Title = role.Title
            };

            _roleService.Add(newRole);

            return Ok();
        }

        // PUT: api/Role/5
        [HttpPut]
        public IHttpActionResult UpdateRole(int id, [FromBody] RoleBindingModel role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            RoleDTO roleToUpdate = _roleService.GetById(id);

            if (roleToUpdate == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"Role with id={id} does not exist.");
            }

            RoleDTO newRole = new RoleDTO()
            {
                Title = role.Title
            };

            _roleService.Update(roleToUpdate);

            return Ok();
        }

    }
}
