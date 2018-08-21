using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTO;
using BLL.Intrefaces;
using WebAPI.Models;
using AutoMapper;

namespace WebAPI.Controllers
{
    [RoutePrefix("api/Question")]
    public class QuestionController : ApiController
    {
        private IQuestionService _questionService;
        private IMapper _mapper;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public QuestionController(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        // GET: api/Question/byTest/5
        [Route("byTest/{id}")]
        public IHttpActionResult GetQuestionsByTestId(int id)
        {
            IEnumerable<QuestionDTO> questionsByTest = questionsByTest = _questionService.GetQuestionsByTestId(id);
            IEnumerable<QuestionViewModel> questionsViewModel = _mapper.Map<IEnumerable<QuestionViewModel>>(questionsByTest);
            return this.Ok(questionsViewModel);
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
            IEnumerable<QuestionDTO> questionByTest = _questionService.GetQuestionsWithRelatedOptionsByTestId(id);
            IEnumerable<QuestionViewModel> questionsViewModel = _mapper.Map<IEnumerable<QuestionViewModel>>(questionByTest);
            return this.Ok(questionsViewModel);
        }


        // POST: api/Question
        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult CreateQuestion([FromBody] QuestionBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            QuestionDTO newQuestion = _mapper.Map<QuestionDTO>(model);

            this._questionService.Add(newQuestion);

            return Ok();
        }

        // PUT: api/Question/5
        [HttpPut]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult UpdateQuestion(int id, [FromBody] QuestionBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            QuestionDTO questionToUpdate = this._questionService.GetById(id);

            if (questionToUpdate == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"Test category with id={id} does not exist.");
            }

            QuestionDTO updatedQuestion = _mapper.Map<QuestionDTO>(model);

            this._questionService.Update(updatedQuestion);

            return Ok();
        }

        // DELETE: api/Question/5
        [HttpDelete]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult DeleteQuestion(int id)
        {
            QuestionDTO questionToDel = this._questionService.GetById(id);

            if (questionToDel == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"Question with id={id} does not exist.");
            }

            this._questionService.Delete(id);

            return Ok();
        }

    }
}
