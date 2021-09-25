using ExpenseTracker.Model;
using System.Linq;
using System.Collections.Generic;

namespace ExpenseTracker.Repositories {

    public class CategoryRepository {
        
        private readonly TransactionContext db = new TransactionContext();

        public Category GetCategoryByName(string categoryName) {
            return db.Categories
                .Where(c => c.Name == categoryName)
                .FirstOrDefault();
        }

        public Category GetCategoryById(int categoryId) {
            return db.Categories
                .Where(c => c.Id == categoryId)
                .FirstOrDefault();
        }

        public List<Category> GetAllCategories(){
            return db.Categories
                .ToList();
        }
        
        public void DeleteAllCategories(){
            var dataToDelete = db.Categories.Where(t => t.Id > 0);
            foreach( var data in dataToDelete){
                db.Remove(data);
            }
            db.SaveChanges();
        }

        public Category AddCategory(Category category) {
            db.Add(category);
            db.SaveChanges();

            return this.GetCategoryByName(category.Name);
        }
    }
}