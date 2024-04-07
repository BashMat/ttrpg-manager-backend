using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TtrpgManagerBackend.Dto.Character;
using TtrpgManagerBackend.Services.Character;

namespace TtrpgManagerBackend.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        
        [EnableCors("MyDefaultPolicy")]
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CharacterGetResponseDto>>> Create([FromBody] CharacterCreateRequestDto newCharacter)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            ServiceResponse<CharacterGetResponseDto> response = await _characterService.Create(userId, newCharacter);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        // GET /api/characters?playerId=xxx
        [EnableCors("MyDefaultPolicy")]
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CharacterGetResponseDto>>>> GetByPlayerId([FromQuery] int playerId)
        {
            ServiceResponse<List<CharacterGetResponseDto>> response = await _characterService.GetByPlayerId(playerId);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        
        [EnableCors("MyDefaultPolicy")]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CharacterGetResponseDto>>> GetById([FromRoute] int id)
        {
            ServiceResponse<CharacterGetResponseDto> response = await _characterService.GetByCharacterId(id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        
        [EnableCors("MyDefaultPolicy")]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<CharacterGetResponseDto>>>> Delete([FromRoute] int id)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            ServiceResponse<List<CharacterGetResponseDto>> response = await _characterService.Delete(userId, id);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}