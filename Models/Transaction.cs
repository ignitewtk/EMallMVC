namespace EMallMVC.Models
{
    public class Transaction
    {
        public int Amount { get; set; }
        public string? Category { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
    }
}
