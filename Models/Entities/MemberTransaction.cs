namespace SajhaBhavishyaAPI.Models.Entities
{
    public class MemberTransaction
    {
        public int Id { get; set; }
        public int MemberId { get; set; } // Foreign key
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }

        // Navigation property
        public Member Member { get; set; }
    }
}
