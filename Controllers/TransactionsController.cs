using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.Services;
using ExpenseTracker.Model;

namespace ExpenseTracker.Controllers {
    [ApiController]
    [Route("transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly TransactionService transactionService = new TransactionService();
        
        [HttpGet]
        public ActionResult<List<Transaction>> GetTransactions(string categoryName,string orderBy, bool ascending){
            if(categoryName != null || orderBy != null){
                return transactionService.SearchTransactions(categoryName,orderBy,ascending);
            } else {
                return transactionService.GetAllTransactions();
            }
            
        }    
    
        [HttpPost]
        public void AddTransaction(Transaction transaction){
            transactionService.AddTransaction(transaction);
        }

        [HttpDelete]
        public void DeleteAllTransactions(){
            transactionService.DeleteAllTransactions();
        }
    }

}