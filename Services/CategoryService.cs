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

        public void AddCategory(Category category){
            _categoryRepo.AddCategory(category);
        }

        public void DeleteAllCategories(){
            _categoryRepo.DeleteAllCategories();
        }

    }
}