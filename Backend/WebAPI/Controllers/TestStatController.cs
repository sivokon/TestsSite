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
    [Authorize]
    public class TestStatController : ApiController
    {
        private ITestStatService _testStatService;

        public TestStatController(ITestStatService testStatService)
        {
            _testStatService = testStatService;
        }

        // POST: api/TestStat
        public IHttpActionResult CreateTestStatistic([FromBody] TestStatViewModel stat)
        {
            TestStatDTO newTestStat = new TestStatDTO()
            {
                TestId = stat.TestId,
                UserId = User.Identity.GetUserId(),
                StartTime = stat.StartTime,
                EndTime = stat.EndTime,
                Answers = stat.Answers
            };
            _testStatService.Add(newTestStat);    
            return this.Ok();
            //throw new NotImplementedException();
        }

        [Route("api/TestStat/byUser")]
        public IHttpActionResult GetTestStatisticsByUserId()
        {
            string userId = User.Identity.GetUserId();
            return this.Ok(_testStatService.GetTestStatisticsByUserId(userId));
        }

    }
}
