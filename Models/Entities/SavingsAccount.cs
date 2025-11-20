namespace SajhaBhavishyaAPI.Models.Entities
{
    public class SavingsAccount
    {
        public int SavingsAccountId { get; set; }
        public int MemberId { get; set; }
        public decimal Balance { get; set; }
        public DateTime LastUpdated { get; set; }
        public Member Member { get; set; }
    }
}
