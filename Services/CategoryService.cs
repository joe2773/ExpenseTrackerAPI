using ExpenseTracker.Model;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Repositories;

namespace ExpenseTracker.Services {

    public class CategoryService {
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();

        public List<Category> GetAllCategories(){
            return _categoryRepo.GetAllCategories();
        }

        public Category AddCategory(Category category){
            if(_categoryRepo.GetCategoryByName(category.Name) == null){
                _categoryRepo.AddCategory(category);
                return category;
            } else {
                return null;
            }
        }

        public void DeleteAllCategories(){
            _categoryRepo.DeleteAllCategories();
        }

    }
}