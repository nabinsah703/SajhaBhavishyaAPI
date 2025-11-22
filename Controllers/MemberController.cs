using Microsoft.AspNetCore.Mvc;
using SajhaBhavishyaAPI.Models.DTOs;
using SajhaBhavishyaAPI.Models.Entities;
using SajhaBhavishyaAPI.Services;

namespace SajhaBhavishyaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _service;

        public MemberController(IMemberService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetAll()
        {
            var members = await _service.GetAllMembersAsync();
            return Ok(members);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberCreateDto dto)
        {
            var newId = await _service.CreateMemberAsync(dto);
            return Ok(new { MemberId = newId });
        }
    }
}
