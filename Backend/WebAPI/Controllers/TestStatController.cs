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

namespace WebAPI.Controllers
{
    [Authorize(Roles = "User")]
    [RoutePrefix("api/TestStat")]
    public class TestStatController : ApiController
    {
        private ITestStatService _testStatService;

        public TestStatController(ITestStatService testStatService)
        {
            _testStatService = testStatService;
        }

        //[Route("byUser")]
        //public IHttpActionResult GetTestStatisticsByUserId()
        //{
        //    string userId = User.Identity.GetUserId();
        //    return this.Ok(_testStatService.GetTestStatisticsByUserId(userId));
        //}

        // GET: api/TestStat/WithTests/byUser
        [Route("WithTests/byUser")]
        public IHttpActionResult GetTestStatisticsWithRelatedTestsByUserId()
        {
            string userId = User.Identity.GetUserId();
            return this.Ok(_testStatService.GetTestStatisticsWithRelatedTestsByUserId(userId));
        }

        // POST: api/TestStat
        [HttpPost]
        public IHttpActionResult StartTest([FromBody] StartTestBindingModel stat)
        {
            TestStatDTO newTestStat = new TestStatDTO()
            {
                TestId = stat.TestId,
                UserId = User.Identity.GetUserId(),
                StartTime = DateTime.Now,
            };
            _testStatService.StartTest(newTestStat);

            return this.Ok();
        }

        // PUT: api/TestStat
        [HttpPut]
        public IHttpActionResult SaveCompletedTest([FromBody] FinishTestBindingModel stat)
        {
            TestStatDTO testStat = new TestStatDTO()
            {
                TestId = stat.TestId,
                UserId = User.Identity.GetUserId(),
                EndTime = DateTime.Now,
                Answers = stat.Answers
            };
            _testStatService.SaveCompletedTest(testStat);

            return this.Ok();
        }

    }
}
