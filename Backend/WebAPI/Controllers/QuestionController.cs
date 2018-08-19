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
    [Authorize]
    [RoutePrefix("api/Question")]
    public class QuestionController : ApiController
    {
        private IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET: api/Question/byTest/5
        [Route("byTest/{id}")]
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
            return this.Ok(questionsByTest);
        }

        // GET: api/Question/5/byTest/5
        [Route("{index}/byTest/{testId}")]
        public IHttpActionResult GetQuestionByIndexAndTestId(int index, int testId)
        {
            QuestionDTO question = _questionService.GetQuestionByIndexAndTestId(index, testId);

            if (question == null)
            {
                return Content(HttpStatusCode.NotFound, 
                    $"Question with index={index} in test with id={testId} does not exist.");
            }

            return this.Ok(_questionService.GetQuestionByIndexAndTestId(index, testId));
        }

        // GET: api/Question/WithOptions/byTest/5
        [Route("WithOptions/byTest/{id}")]
        public IHttpActionResult GetQuestionsWithRelatedOptionsByTestId(int id)
        {
            return this.Ok(_questionService.GetQuestionsWithRelatedOptionsByTestId(id));
        }

        //// GET: api/Question
        //public IHttpActionResult GetQuestions()
        //{
        //    throw new NotImplementedException();
        //}

        //// GET: api/Question/5
        //public IHttpActionResult GetQuestion(int id)
        //{
        //    return this.Ok(_questionService.GetById(id));
        //}

        // POST: api/Question
        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult CreateQuestion([FromBody] QuestionDTO question)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Question/5
        [HttpPut]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult UpdateQuestion(int id, [FromBody] QuestionDTO question)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Question/5
        [HttpDelete]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult DeleteQuestion(int id)
        {
            throw new NotImplementedException();
        }

    }
}
