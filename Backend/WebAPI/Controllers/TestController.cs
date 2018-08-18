﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTO;
using BLL.Intrefaces;
using Microsoft.AspNet.Identity;

namespace WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        private ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        //// GET: api/Test
        //public IHttpActionResult GetTests()
        //{
        //    throw new NotImplementedException();
        //}

        // GER: api/Test/5
        public IHttpActionResult GetTest(int id)
        {
            return this.Ok(_testService.GetById(id));
        }

        //// POST: api/Test
        //[HttpPost]
        //public IHttpActionResult CreateTest([FromBody] TestDTO test)
        //{
        //    throw new NotImplementedException();
        //}

        //// PUT: api/Test/5
        //[HttpPut]
        //public IHttpActionResult UpdateTest(int id, [FromBody] TestDTO test)
        //{
        //    throw new NotImplementedException();
        //}

        //// DELETE: api/Test/5
        //[HttpDelete]
        //public IHttpActionResult DeleteTest(int id)
        //{
        //    throw new NotImplementedException();
        //}

        // GET: api/Test/byCategory/5
        [Route("byCategory/{Id}")]
        public IHttpActionResult GetTestsByCategoryId(int id)
        {
            IEnumerable<TestDTO> testsByCategory;
            try
            {
                testsByCategory = _testService.GetTestsByCategoryId(id);
            }
            catch
            {
                return InternalServerError();
            }
            return Ok(testsByCategory);
        }

    }
}
