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
        // api/Role
        public IHttpActionResult GetRoles()
        {
            var roleStore = new RoleStore<IdentityRole>(new ApplicationDbContext());
            var roleManager = new RoleManager<IdentityRole>(roleStore);

            var roles = roleManager.Roles.ToList();

            return this.Ok(roles);
        }
    }
}
