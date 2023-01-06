using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList_MySQL.DTOs;
using TodoList_MySQL.Model;
using TodoList_MySQL.Service.Interface;

namespace TodoList_MySQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoService photoService;
        private readonly IMapper mapper;

        public PhotoController(IPhotoService photoService, IMapper mapper)
        {
            this.photoService = photoService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PhotoDto>>> GetPhotosByMember(int id)
        {
            var photos = await photoService.GetUserPhoto(id);

            if (photos.Count == 0) return Ok("No photo");

            return Ok(mapper.Map<IReadOnlyList<Photo>, IReadOnlyList<PhotoDto>>(photos));
        }
    }
}
