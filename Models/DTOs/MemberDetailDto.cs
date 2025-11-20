namespace SajhaBhavishyaAPI.Models.DTOs
{
    public class MemberDetailDto
    {
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string? Mobile { get; set; }
        public string? Email { get; set; }
        public DateTime JoinedDate { get; set; }
        public decimal SavingsBalance { get; set; }
    }
}
