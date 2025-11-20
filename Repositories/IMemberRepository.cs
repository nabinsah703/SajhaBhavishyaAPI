using SajhaBhavishyaAPI.Models.DTOs;
using SajhaBhavishyaAPI.Models.Entities;

namespace SajhaBhavishyaAPI.Repositories
{
    public interface IMemberRepository
    {
        Task<int> CreateMemberAsync(MemberCreateDto dto);
        // you can add other repository methods here
    }

}
