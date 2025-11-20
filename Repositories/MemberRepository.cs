using Microsoft.EntityFrameworkCore;
using SajhaBhavishyaAPI.Data;
using SajhaBhavishyaAPI.Models.DTOs;
using SajhaBhavishyaAPI.Models.Entities;
using System.Data;
using Microsoft.Data.SqlClient;

namespace SajhaBhavishyaAPI.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly SajhaDbContext _db;

        public MemberRepository(SajhaDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<int> CreateMemberAsync(MemberCreateDto dto)
        {
            return await CreateMemberUsingSP(dto);
        }

        public async Task<int> CreateMemberUsingSP(MemberCreateDto dto)
        {
            var idParam = new SqlParameter("@MemberId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            await _db.Database.ExecuteSqlRawAsync(
                "EXEC dbo.usp_CreateMember @FirstName, @LastName, @Mobile, @Email, @MemberId OUTPUT",
                new SqlParameter("@FirstName", dto.FirstName),
                new SqlParameter("@LastName", dto.LastName),
                new SqlParameter("@Mobile", dto.Mobile ?? (object)DBNull.Value),
                new SqlParameter("@Email", dto.Email ?? (object)DBNull.Value),
                idParam
            );

            return (int)idParam.Value;
        }
    }

}
