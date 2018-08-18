using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTO;
using BLL.Intrefaces;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Option")]
    public class OptionController : ApiController
    {
        private IOptionService _optionService;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

        //// GET: api/Option
        //public IHttpActionResult GetOptions()
        //{
        //    throw new NotImplementedException();
        //}

        //// GER: api/Option/5
        //public IHttpActionResult GetOption(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //// POST: api/Option
        //[HttpPost]
        //public IHttpActionResult CreateOption([FromBody] OptionDTO option)
        //{
        //    throw new NotImplementedException();
        //}

        //// PUT: api/Option/5
        //[HttpPut]
        //public IHttpActionResult UpdateOption(int id, [FromBody] OptionDTO option)
        //{
        //    throw new NotImplementedException();
        //}

        //// DELETE: api/Option/5
        //[HttpDelete]
        //public IHttpActionResult DeleteOption(int id)
        //{
        //    throw new NotImplementedException();
        //}

        // GET: api/Option/byQuestion/5
        [Route("byQuestion/{id}")]
        public IHttpActionResult getOptionsByQuestionId(int id)
        {
            IEnumerable<OptionDTO> optionsByQuestion;
            try
            {
                optionsByQuestion = _optionService.GetOptionsByQuestionId(id);
            }
            catch
            {
                return InternalServerError();
            }

            //List<OptionViewModel> optionsVM = null;
            //foreach (OptionDTO option in optionsByQuestion)
            //{
            //    OptionViewModel optVM = new OptionViewModel()
            //    {
            //        Body = option.Body,
            //        Index = option.Index,
            //        QuestionId = option.QuestionId
            //    };
            //    optionsVM.Add(optVM);
            //}

            return Ok(optionsByQuestion);
        }

    }
}
