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
    public class VideoController : ControllerBase
    {
        private readonly IVideoService videoService;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public VideoController(IVideoService videoService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.videoService = videoService;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost("addVideo")]
        public async Task<ActionResult<VideoDto>> AddPhoto(IFormFile file)
        {
            var result = await videoService.AddVideoAsync(file);

            if (result.Error != null) return BadRequest(result.Error.Message);

            var video = new Video
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            unitOfWork.Repository<Video>().Add(video);

            return (await unitOfWork.Complete() == null ? BadRequest() : Ok(mapper.Map<Video, VideoDto>(video)));
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<VideoDto>>> GetVideos()
        {
            var videos = await videoService.GetVideo();

            if (videos.Count == 0) return Ok("No videos");

            return Ok(mapper.Map<IReadOnlyList<Video>, IReadOnlyList<VideoDto>>(videos));
        }

        [HttpGet("getId")]
        public async Task<ActionResult<VideoDto>> GetVideo(int id)
        {
            var videos = await videoService.GetVideo();

            if (videos.Count == 0) return Ok("No videos");

            var video = videos.FirstOrDefault(v => v.Id == id);

            return video!= null ? Ok(mapper.Map<Video, VideoDto>(video)):BadRequest("No video");
        }
    }
}
