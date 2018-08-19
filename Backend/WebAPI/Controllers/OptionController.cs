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
    [Authorize]
    [RoutePrefix("api/Option")]
    public class OptionController : ApiController
    {
        private IOptionService _optionService;

        public OptionController(IOptionService optionService)
        {
            _optionService = optionService;
        }

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

            return Ok(optionsByQuestion);
        }

        //// GET: api/Option
        //public IHttpActionResult GetOptions()
        //{
        //    throw new NotImplementedException();
        //}

        //// GET: api/Option/5
        //public IHttpActionResult GetOption(int id)
        //{
        //    throw new NotImplementedException();
        //}

        // POST: api/Option
        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult CreateOption([FromBody] OptionDTO newOption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (newOption == null)
            {
                return BadRequest();
            }

            _optionService.Add(newOption);

            return this.Ok();
        }

        // PUT: api/Option/5
        [HttpPut]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult UpdateOption(int id, [FromBody] OptionDTO option)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Option/5
        [HttpDelete]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult DeleteOption(int id)
        {
            throw new NotImplementedException();
        }

    }
}
