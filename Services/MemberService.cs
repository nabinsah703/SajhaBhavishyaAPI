using SajhaBhavishyaAPI.Data;
using SajhaBhavishyaAPI.Models.DTOs;
using SajhaBhavishyaAPI.Models.Entities;
using SajhaBhavishyaAPI.Repositories;
using System;
using Microsoft.EntityFrameworkCore;
namespace SajhaBhavishyaAPI.Services
{

    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;
        private readonly SajhaDbContext sajhaDbContext;

        public MemberService(IMemberRepository repository, SajhaDbContext context)
        {
            _repository = repository;
            sajhaDbContext = context;
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

        public async Task<List<Member>> GetAllMembersAsync()
        {
            // Fetch all members from SQL Server via EF Core
            return await sajhaDbContext.Members.Include(x => x.MemberTransactions)
                .ToListAsync();
        }
    }
}