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
        public ActionResult<List<Transaction>> GetTransactions(string categoryName,string sortOrder){
            if(categoryName != null || sortOrder != null){
                return transactionService.SearchTransactions(categoryName,sortOrder);
            } else {
                return transactionService.GetAllTransactions();
            }
            
        }    
    
        [HttpPost]
        public void AddTransaction(List<Transaction> transactions){
            transactionService.AddTransactions(transactions);
        }

        [HttpDelete]
        public void DeleteAllTransactions(){
            transactionService.DeleteAllTransactions();
        }
    }

}