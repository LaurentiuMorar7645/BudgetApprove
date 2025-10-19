namespace BudgetApproved.Models
{
    public class ExpenseModel
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!; 
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
