namespace SajhaBhavishyaAPI.Models.DTOs
{
    public class TransactionDto
    {
        public int MemberId { get; set; }
        public decimal Amount { get; set; }
        public string TransactionType { get; set; }
    }
}
