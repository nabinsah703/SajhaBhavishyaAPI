using System.Transactions;

namespace SajhaBhavishyaAPI.Models.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public DateTime JoinedDate { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }

        public ICollection<SavingsAccount> SavingsAccounts { get; set; }
        public ICollection<MemberTransaction> MemberTransactions { get; set; }
        public ICollection<Loan> Loans { get; set; }
    }
}
