namespace SajhaBhavishyaAPI.Models.DTOs
{
    public class MemberUpdateDTO
    {
        public int Id { get; set; }              // Required
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }

}
