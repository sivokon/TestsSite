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
    [RoutePrefix("api/Option")]
    public class OptionController : ApiController
    {
        private IOptionService _optionService;
        private IMapper _mapper;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        public OptionController(IOptionService optionService, IMapper mapper)
        {
            _optionService = optionService;
            _mapper = mapper;
        }

        // GET: api/Option/byQuestion/5
        [Route("byQuestion/{id}")]
        public IHttpActionResult getOptionsByQuestionId(int id)
        {
            IEnumerable<OptionDTO> optionsByQuestion = _optionService.GetOptionsByQuestionId(id);
            IEnumerable<OptionViewModel> viewModelOptions = _mapper.Map<IEnumerable<OptionViewModel>>(optionsByQuestion);
            return Ok(optionsByQuestion);
        }


        // POST: api/Option
        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult CreateOption([FromBody] OptionBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OptionDTO newOption = new OptionDTO()
            {
                QuestionId = model.QuestionId,
                Body = model.Body,
                Index = model.Index,
                IsCorrect = model.IsCorrect
            };

            _optionService.Add(newOption);

            return this.Ok();
        }

        // PUT: api/Option/5
        [HttpPut]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult UpdateOption(int id, [FromBody] OptionBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OptionDTO optionToUpdate = this._optionService.GetById(id);

            if (optionToUpdate == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"Test category with id={id} does not exist.");
            }

            OptionDTO updatedOption = new OptionDTO()
            {
                QuestionId = model.QuestionId,
                Body = model.Body,
                Index = model.Index,
                IsCorrect = model.IsCorrect
            };

            this._optionService.Update(updatedOption);

            return Ok();
        }

        // DELETE: api/Option/5
        [HttpDelete]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult DeleteOption(int id)
        {
            OptionDTO optionToDel = this._optionService.GetById(id);

            if (optionToDel == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"option with id={id} does not exist.");
            }

            this._optionService.Delete(id);

            return Ok();
        }

    }
}
