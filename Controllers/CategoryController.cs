using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Services;
using ExpenseTracker.Model;

namespace ExpenseTracker.Controllers {
    [ApiController]
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService categoryService = new CategoryService();

        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories(){
            return categoryService.GetAllCategories();
        }
        [HttpPost]
        public void AddCategory(Category category){
            categoryService.AddCategory(category);
        }
        [HttpDelete]
        public void DeleteAllCategories(){
            categoryService.DeleteAllCategories();
        }
    }
}