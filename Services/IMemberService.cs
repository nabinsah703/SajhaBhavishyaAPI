using SajhaBhavishyaAPI.Models.DTOs;
using SajhaBhavishyaAPI.Models.Entities;

namespace SajhaBhavishyaAPI.Services
{
    public interface IMemberService
    {
        Task<int> CreateMemberAsync(MemberCreateDto dto);
        Task<List<Member>> GetAllMembersAsync();
        // you can add other service methods here
    }
}
