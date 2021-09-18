using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker.Model {

    public class Transaction {

        public int Id { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
        public string Date { get; set; }
        public string CategoryName { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
    }
}