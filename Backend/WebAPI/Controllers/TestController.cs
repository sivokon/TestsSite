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
using AutoMapper;

namespace WebAPI.Controllers
{    
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        private ITestService _testService;
        private IMapper _mapper;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }

        public TestController(ITestService testService, IMapper mapper)
        {
            _testService = testService;
            _mapper = mapper;
        }

        // GET: api/Test/5
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
            IEnumerable<TestDTO> testsByCategory = _testService.GetTestsByCategoryId(id);
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
        //[Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult CreateTest([FromBody] NewTestBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TestDTO newTest = new TestDTO()
            {
                Title = model.Title,
                CategoryId = model.CategoryId,
                Descr = model.Descr,
                DurationMin = model.DurationMin,
                Questions = _mapper.Map<List<QuestionDTO>>(model.Questions)
            };

            _testService.Add(newTest);

            return Ok(newTest);
        }

        // PUT: api/Test/5
        [HttpPut]
        //[Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult UpdateWholeTest(int id, [FromBody] NewTestBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TestDTO testToUpdate = _testService.GetById(id);

            if (testToUpdate == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"Test with id={id} does not exist.");
            }

            _testService.UpdateWholeTest(id, _mapper.Map<TestDTO>(model));

            return Ok();
        }

        [HttpPut]
        //[Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult UpdateTestInfo(int id, [FromBody] UpdateTestInfoBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TestDTO testToUpdate = _testService.GetById(id);

            if (testToUpdate == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"Test with id={id} does not exist.");
            }

            TestDTO updatedTest = new TestDTO()
            {
                Id = id,
                Title = model.Title,
                Descr = model.Descr,
                DurationMin = model.DurationMin,
                CategoryId = model.CategoryId
            };

            _testService.UpdateTestInfo(updatedTest);

            return Ok();
        }

        // DELETE: api/Test/5
        [HttpDelete]
        //[Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult DeleteTest(int id)
        {
            TestDTO testToDel = _testService.GetById(id);

            if (testToDel == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"Test with id={id} does not exist.");
            }

            _testService.Delete(id);

            return Ok();
        }

    }
}
