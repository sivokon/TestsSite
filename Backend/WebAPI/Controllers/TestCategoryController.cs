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
    [RoutePrefix("api/TestCategory")]
    public class TestCategoryController : ApiController
    {
        private ITestCategoryService _testCategoryService;        

        public TestCategoryController(ITestCategoryService testCategoryService)
        {
            _testCategoryService = testCategoryService;
        }

        // GET: api/TestCategory
        public IHttpActionResult GetCategories()
        {
            return this.Ok(this._testCategoryService.GetAll());
            
        }

        //// GET: api/TestCategory/5
        //public IHttpActionResult GetCategory(int id)
        //{
        //    throw new NotImplementedException();
        //}

        // POST: api/TestCategory
        [HttpPost]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult CreateCategory([FromBody] TestCategoryBindingModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TestCategoryDTO newCategory = new TestCategoryDTO()
            {
                Title = category.Title
            };

            this._testCategoryService.Add(newCategory);

            return Ok();
        }

        // PUT: api/TestCategory/5
        [HttpPut]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult UpdateCategory(int id, [FromBody] TestCategoryBindingModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TestCategoryDTO categoryToUpdate = this._testCategoryService.GetById(id);

            if (categoryToUpdate == null)
            {
                return Content(HttpStatusCode.NotFound, 
                    $"Test category with id={id} does not exist.");
            }

            TestCategoryDTO updatedCategory = new TestCategoryDTO()
            {
                Title = category.Title
            };

            this._testCategoryService.Update(updatedCategory);

            return Ok();
        }

        // DELETE: api/TestCategory/5
        [HttpDelete]
        [Authorize(Roles = "Admin, Editor")]
        public IHttpActionResult DeleteCategory(int id)
        {
            TestCategoryDTO categoryToDel = this._testCategoryService.GetById(id);

            if (categoryToDel == null)
            {
                return Content(HttpStatusCode.NotFound,
                    $"Test category with id={id} does not exist.");
            }

            this._testCategoryService.Delete(id);

            return Ok();
        }

    }
}
