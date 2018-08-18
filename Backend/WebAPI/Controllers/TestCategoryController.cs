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
            return this.Ok(_testCategoryService.GetAll());
        }

        //// GER: api/TestCategory/5
        //public IHttpActionResult GetCategory(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //// POST: api/TestCategory
        //[HttpPost]
        //public IHttpActionResult CreateCategory([FromBody] TestCategoryDTO category)
        //{
        //    throw new NotImplementedException();
        //}

        //// PUT: api/TestCategory/5
        //[HttpPut]
        //public IHttpActionResult UpdateCategory(int id, [FromBody] TestCategoryDTO category)
        //{
        //    throw new NotImplementedException();
        //}

        //// DELETE: api/TestCategory/5
        //[HttpDelete]
        //public IHttpActionResult DeleteCategory(int id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
