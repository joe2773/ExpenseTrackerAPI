using ExpenseTracker.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Repositories {

    public class TransactionRepository {
        
        private readonly TransactionContext db = new TransactionContext();


        public IEnumerable<Transaction> GetAllByCategory(string category){
            return db.Transactions
            .Where(t => t.CategoryName == category)
            .OrderBy(t => t.CategoryName);
        }

        public IEnumerable<Transaction> GetAll(){
            return db.Transactions;
        }

    
        public IEnumerable<Transaction> GetAllInPriceOrder(bool ascending) {
            return ascending ? 
                db.Transactions
                .OrderBy(t => t.Amount) 
                : 
                db.Transactions
                .OrderByDescending(t => t.Amount);
        }
        public IEnumerable<Transaction> GetAllInCategoryOrder(bool ascending) {
            return ascending ? 
                db.Transactions
                .OrderBy(t => t.CategoryName) 
                : 
                db.Transactions
                .OrderByDescending(t => t.CategoryName);
        }

        public IEnumerable<Transaction> GetByCategoryInPriceOrder(string category,bool ascending) {
            return ascending ? 
                db.Transactions
                .Where(t => t.CategoryName == category)
                .OrderBy(t => t.Amount) 
                :
                db.Transactions
                .Where(t => t.CategoryName == category)
                .OrderByDescending(t => t.Amount);
        }
        public void Add(Transaction transaction){
            db.Add(transaction);
            db.SaveChanges();
        }

        public void Add(List<Transaction> transactions){
            foreach(Transaction transaction in transactions){
                db.Add(transactions);
            }
            db.SaveChanges();
        }

        public void DeleteAll(){
            var dataToDelete = db.Transactions.Where(t => t.Id > 0);
            foreach( var data in dataToDelete){
                db.Remove(data);
            }
            db.SaveChanges();
        }
    }
}
