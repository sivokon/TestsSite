using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTO;
using BLL.Intrefaces;
using Microsoft.AspNet.Identity;
using WebAPI.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebAPI.Controllers
{    
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        private ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        // GER: api/Test/5
        public IHttpActionResult GetTest(int id)
        {
            TestDTO test = _testService.GetById(id);

            if (test == null)
            {
                return Content(HttpStatusCode.NotFound, 
                    $"Test with id = {id} does not exist.");
            }

            return this.Ok(test);
        }

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

        // GET: api/Test/byKeyWord&keyWord=word
        [Route("byKeyWord")]
        public IHttpActionResult GetTestsByTitleKeyWord(string keyWord)
        {
            IEnumerable<TestDTO> tests = _testService.GetTestsByTitleKeyWord(keyWord);
            return Ok(tests);
        }

        // POST: api/Test
        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult CreateTest([FromBody] TestDTO test)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Test/5
        [HttpPut]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult UpdateTest(int id, [FromBody] TestDTO test)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Test/5
        [HttpDelete]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult DeleteTest(int id)
        {
            throw new NotImplementedException();
        }

    }
}
