namespace SajhaBhavishyaAPI.Models.Entities
{
    public class LoanInstallment
    {
        public int LoanInstallmentId { get; set; }
        public int LoanId { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime PaidDate { get; set; }

        public Loan Loan { get; set; }
    }
}
