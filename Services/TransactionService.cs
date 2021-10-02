using ExpenseTracker.Model;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Repositories;

namespace ExpenseTracker.Services {

    public class TransactionService {
        private readonly TransactionRepository _transactionRepo = new TransactionRepository();
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();
        
        private readonly TransactionContext db = new TransactionContext();
        public List<Transaction> SearchTransactions(string categoryName, string sortOrder){
            var searchQuery = this.BuildSearchQuery(categoryName,sortOrder);
            return searchQuery.ToList();
        }

        private IQueryable<Transaction> BuildSearchQuery(string categoryName, string sortOrder) {
            IQueryable<Transaction> searchQuery = db.Transactions;

            searchQuery = this.AddCategoryFilter(searchQuery,categoryName);
            searchQuery = this.AddOrderFilter(searchQuery,sortOrder);
            return searchQuery;
            
        }
        public List<Transaction> GetAllTransactions(){
            return _transactionRepo.GetAll().ToList();
        }

        public List<Transaction> GetAllByCategory(string categoryName){
            return _transactionRepo.GetAllByCategory(categoryName).ToList();
        }

        private IQueryable<Transaction> AddCategoryFilter(IQueryable<Transaction> searchQuery, string categoryName){
            if(categoryName != null){
                return searchQuery
                .Where(t => t.CategoryName == categoryName);
            }
            return searchQuery;
        }

        private IQueryable<Transaction> AddOrderFilter(IQueryable<Transaction> searchQuery, string sortOrder){
            if(sortOrder != null){
                switch(sortOrder){
                    case "priceAsc" :
                        searchQuery = searchQuery
                        .OrderBy(t => t.Amount);
                        break;
                    
                    case "priceDesc" :
                        searchQuery = searchQuery
                        .OrderByDescending(t => t.Amount);
                        break;
                    
                    case "categoryAsc" :
                        searchQuery = searchQuery
                        .OrderBy(t => t.CategoryName);
                        break;  
                        
                    case "categoryDesc" :
                        searchQuery = searchQuery
                        .OrderByDescending(t => t.CategoryName);
                        break;
                        
                    default :
                        break;
                }
            }
            return searchQuery;
        }
    
        public void AddTransactions(List<Transaction> transactions) {
            foreach(Transaction transaction in transactions){
                Category category = _categoryRepo.GetCategoryById(transaction.CategoryId);
                if(category != null){
                    transaction.CategoryName = category.Name;
                    _transactionRepo.Add(transaction);
                }
            }
        }

        public Category GetCategoryByName(string categoryName) {
            if(this._categoryRepo.GetCategoryByName(categoryName) != null) {
                return this._categoryRepo.GetCategoryByName(categoryName);
            } 
            return null;
        }

        public Category GetCategoryById(int categoryId) {
             if(this._categoryRepo.GetCategoryById(categoryId) != null) {
                return this._categoryRepo.GetCategoryById(categoryId);
            }
            return null;
        }
        public void DeleteAllTransactions(){
            _transactionRepo.DeleteAll();
        }
    }
    
}