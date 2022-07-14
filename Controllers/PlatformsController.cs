using APIWithRedis.Data;
using APIWithRedis.DTOs;
using APIWithRedis.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APIWithRedis.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repo;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{id}", Name = "GetPlatformById")]
        public ActionResult<PlatformReadDto> GetPlatformById(string id)
        {
            var platform = _repo.GetPlatformById(id);
            if (platform == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<PlatformReadDto>(platform));
            }
        }
        [HttpPost]
        public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto platform)
        {
            var platformModel = _mapper.Map<Platform>(platform);
            _repo.CreatePlatform(platformModel);

            var platformReadDto = _mapper.Map<PlatformReadDto>(platformModel);
            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);
        }
        [HttpPut("{id}")]
        public ActionResult UpdatePlatform(string id, PlatformUpdateDto platformUpdateDto)
        {
            var platformModelFromRepo = _repo.GetPlatformById(id);
            if (platformModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(platformUpdateDto, platformModelFromRepo);
                _repo.UpdatePlatform(platformModelFromRepo);
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeletePlatform(string id)
        {
            var platformFromDb = _repo.GetPlatformById(id);
            if (platformFromDb == null)
            {
                return NotFound();
            }
            else
            {
                _repo.DeletePlatform(id);
                return NoContent();
            }
        }
        [HttpGet]
        public ActionResult GetAllPlatforms()
        {
            var platformsFromDb = _repo.GetAllPlatforms();
            if (platformsFromDb == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformsFromDb));
            }
        }
    }
}