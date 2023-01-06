using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList_MySQL.DTOs;
using TodoList_MySQL.Model;
using TodoList_MySQL.Service.Interface;
using TodoList_MySQL.Specification.ModelSpecification;

namespace TodoList_MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService memberService;
        private readonly IMapper mapper;
        private readonly IPhotoService photoService;

        public MemberController(
            IMemberService memberService, 
            IMapper mapper,
            IPhotoService photoService
        )
        {
            this.memberService = memberService;
            this.mapper = mapper;
            this.photoService = photoService;
        }

        [HttpPost]
        public async Task<ActionResult<MemberDto>> CreateOrder(string name, string password)
        {
            var newMember = await memberService.CreateMember(name, password);

            if (newMember == null) return BadRequest("error");

            return Ok(mapper.Map<Member, MemberDto>(newMember));
        }

        [HttpGet]
        public async Task<ActionResult<MemberDto>> GetMember(string name, string password)
        {
            var member = await memberService.GetMember(name, password);

            return Ok(mapper.Map<Member, MemberDto>(member));
        }

        [HttpPost("addPhoto")]
        public async Task<ActionResult<Photo>> AddPhoto(IFormFile file, int userId)
        {
            var result = await photoService.AddPhotoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var member = await memberService.GetMember(userId);

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            photo.isMain = (member.Photos.Count == 0 ? true : false);

            member.Photos.Add(photo);

            var updatedMember = await memberService.UpdateMember(member);

            if (member == null) return BadRequest("adding photo error");

            return Ok(mapper.Map<Member, MemberDto>(member));
        }

        [HttpDelete("deletePhoto")]
        public async Task<ActionResult> DeletePhoto(int photoId, int userId)
        {
            var member = await memberService.GetMember(userId);

            var photo = member.Photos.FirstOrDefault(p => p.Id == photoId);

            if (photo == null) return NotFound();

            if (photo.isMain) return BadRequest("cann't delete main photo");

            if(photo.PublicId != null)
            {
                var result = await photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null) return BadRequest(result.Error.Message);
            }

            member.Photos.Remove(photo);

            if (await memberService.UpdateMember(member) != null) return Ok();

            return BadRequest("Deleting photo error");
        }
    }
}
