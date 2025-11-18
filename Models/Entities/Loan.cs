namespace SajhaBhavishyaAPI.Models.Entities
{
    public class Loan
    {
        public int LoanId { get; set; }
        public int MemberId { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal InterestRate { get; set; }  // 7%
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Member Member { get; set; }
        public ICollection<LoanInstallment> Installments { get; set; }
    }
}
