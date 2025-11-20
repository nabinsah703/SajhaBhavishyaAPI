using SajhaBhavishyaAPI.Models.DTOs;
using SajhaBhavishyaAPI.Models.Entities;
using SajhaBhavishyaAPI.Repositories;

namespace SajhaBhavishyaAPI.Services
{

    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;

        public MemberService(IMemberRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateMemberAsync(MemberCreateDto dto)
        {
            // You can also map manually or use AutoMapper
            var member = new Member
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                // map other properties
            };

            // Call repository
            var newMemberId = await _repository.CreateMemberAsync(dto);
            return newMemberId;
        }

        public Task<Member> CreateMemberAsync(Member member)
        {
            throw new NotImplementedException();
        }
    }
}