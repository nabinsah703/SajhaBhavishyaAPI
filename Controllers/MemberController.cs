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
        private readonly IMemberService _memberService;

        public MemberController(IMemberService service)
        {
            _memberService = service;
        }
        [HttpGet]
        public async Task<ActionResult<List<Member>>> GetAll()
        {
            var members = await _memberService.GetAllMembersAsync();
            return Ok(members);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberCreateDto dto)
        {
            var newId = await _memberService.CreateMemberAsync(dto);
            return Ok(new { MemberId = newId });
        }

        [HttpPut("update")]
        public async Task<ActionResult> updateMember([FromBody] MemberUpdateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var updatedMember = await _memberService.UpdateMemberAsync(dto);

            if (updatedMember == null)
                return NotFound(new { Message = "Member Not Found" });
            return Ok(updatedMember);
        }

    }
}
