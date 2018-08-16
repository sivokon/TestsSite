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
    //[Authorize]
    public class QuestionController : ApiController
    {
        private IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET: api/Question
        public IHttpActionResult GetQuestions()
        {
            throw new NotImplementedException();
        }

        // GER: api/Question/5
        public IHttpActionResult GetQuestion(int id)
        {
            return this.Ok(_questionService.GetById(id));
        }

        // POST: api/Question
        [HttpPost]
        public IHttpActionResult CreateQuestion([FromBody] QuestionDTO question)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Question/5
        [HttpPut]
        public IHttpActionResult UpdateQuestion(int id, [FromBody] QuestionDTO question)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Question/5
        [HttpDelete]
        public IHttpActionResult DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

        [Route("api/Question/byTest/{id}")]
        public IHttpActionResult GetQuestionsByTestId(int id)
        {
            IEnumerable<QuestionDTO> questionsByTest;
            try
            {
                questionsByTest = _questionService.GetQuestionsByTestId(id);
            }
            catch
            {
                return InternalServerError();
            }
            return Ok(questionsByTest);
        }

        [Route("api/Question/{index}/byTest/{testId}")]
        public IHttpActionResult GetQuestionByIndexAndTestId(int index, int testId)
        {
            return Ok(_questionService.GetQuestionByIndexAndTestId(index, testId));
        }

    }
}
