using ExpenseTracker.Model;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Repositories;

namespace ExpenseTracker.Services {

    public class TransactionService {
        private readonly TransactionContext db = new TransactionContext();
        private readonly TransactionRepository _transactionRepo = new TransactionRepository();
        private readonly CategoryRepository _categoryRepo = new CategoryRepository();
        
        public List<Transaction> SearchTransactions(string categoryName, string orderBy, bool ascending){ 
            switch(orderBy){
                case("price"):
                    return categoryName != null ? GetByCategoryInPriceOrder(categoryName,ascending) : GetAllInPriceOrder(ascending);

                case("category"):
                    return GetAllInCategoryOrder(ascending);

                default: 
                    if(categoryName != null){
                        return GetAllByCategory(categoryName);
                    }
                    return GetAllTransactions();
                    
            }
        }
        public List<Transaction> GetAllTransactions(){
            return _transactionRepo.GetAll().ToList();
        }

        public List<Transaction> GetAllByCategory(string categoryName){
            return _transactionRepo.GetAllByCategory(categoryName).ToList();
        }

        public List<Transaction> GetAllInPriceOrder(bool ascending){
            return this._transactionRepo.GetAllInPriceOrder(ascending).ToList();
        }
        public List<Transaction> GetAllInCategoryOrder(bool ascending){
            return this._transactionRepo.GetAllInCategoryOrder(ascending).ToList();
        }

        public List<Transaction> GetByCategoryInPriceOrder(string categoryName, bool ascending) {
            return this._transactionRepo.GetByCategoryInPriceOrder(categoryName,ascending).ToList();
        }
    
        public void AddTransaction(Transaction transaction) {
            if(this.GetCategoryByName(transaction.CategoryName) != null){
                transaction.CategoryId = this.GetCategoryByName(transaction.CategoryName).Id;
                _transactionRepo.Add(transaction);
            } else {
                Category categoryToAdd = new Category{Name = transaction.CategoryName};
                transaction.CategoryId = this._categoryRepo.AddCategory(categoryToAdd).Id;
                _transactionRepo.Add(transaction);
            }
            
        }

        public Category GetCategoryByName(string categoryName) {
            if(this._categoryRepo.GetCategoryByName(categoryName) != null) {
                return this._categoryRepo.GetCategoryByName(categoryName);
            } 
            return null;
        }
        public void DeleteAllTransactions(){
            _transactionRepo.DeleteAll();
        }
    }
    
}