using Microsoft.EntityFrameworkCore;
using ExpenseTracker.Model;
using System.Linq;

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

        public Category AddCategory(Category category) {
            db.Add(category);
            db.SaveChanges();

            return this.GetCategoryByName(category.Name);

        }
    }
}