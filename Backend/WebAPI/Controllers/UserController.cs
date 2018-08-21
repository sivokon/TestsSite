using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
using BLL.Intrefaces;
using BLL.DTO;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private IUserService _userService;
        private IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        // GET: api/User
        public IHttpActionResult GetAllUsers()
        {
            IEnumerable<UserDTO> users = _userService.GetAll();
            return Ok(users);
        }

        // GET: api/User/5
        public IHttpActionResult GetById(int id)
        {
            UserDTO user = _userService.GetById(id);

            if (user == null)
            {
                return Content(HttpStatusCode.NotFound, $"User with id = {id} does not exist.");
            }

            return Ok(user);
        }

        // GET: api/User/byKeyWord&keyWord=name
        [Route("byKeyWord")]
        public IHttpActionResult GetByName(string keyWord)
        {
            IEnumerable<UserDTO> users = _userService.GetUsersByUsernameKeyWord(keyWord);
            return Ok(users);
        }

        // DELETE: api/User/5
        [HttpDelete]
        public IHttpActionResult DeleteUser(int id)
        {
            UserDTO userToDel = _userService.GetById(id);

            if (userToDel == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"User with id={id} does not exist.");
            }

            this._userService.Delete(id);

            return Ok();
        }

        //// POST: api/User
        //[HttpPost]
        //public IHttpActionResult AddUserRoles([FromBody] AddUserRolesBindingModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        BadRequest(ModelState);
        //    }

        //    UserDTO user = _userService.GetById(model.UserId);

        //    if (user == null)
        //    {
        //        return Content(HttpStatusCode.NotFound,
        //            "Can't add roles to user that does not exist");
        //    }

        //    _userManager.


        //}

    }
}
