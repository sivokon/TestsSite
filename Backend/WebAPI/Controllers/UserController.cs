using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {

        public IHttpActionResult GetAllUsers()
        {

        }
    }
}
