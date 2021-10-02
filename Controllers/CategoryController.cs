using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Services;
using ExpenseTracker.Model;
using System.Web.Http.Cors;
namespace ExpenseTracker.Controllers {
    [ApiController]
    [Route("categories")]
    
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService = new CategoryService();

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ActionResult<List<Category>> GetAllCategories(){
            return categoryService.GetAllCategories();
        }
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ActionResult AddCategory(Category category){
            if(categoryService.AddCategory(category) != null){
                return Ok();
            } else {
                return BadRequest("Category with name: "+category.Name + " already exists");
            }
        }
        [HttpDelete]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public void DeleteAllCategories(){
            categoryService.DeleteAllCategories();
        }
    }
}