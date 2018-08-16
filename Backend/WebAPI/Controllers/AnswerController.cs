using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTO;
using BLL.Intrefaces;

namespace WebAPI.Controllers
{
    public class AnswerController : ApiController
    {
        private IAnswerService _answerService;

        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [Route("api/Answer/byTestStat/{id}")]
        public IHttpActionResult GetAnswersByTestStatisticId(int id)
        {
            return this.Ok(_answerService.GetAnswersByTestStatisticId(id));
        }

    }
}
