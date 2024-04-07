using System.Security.Claims;
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

        // GET /api/characters?playerId=xxx
        [EnableCors("MyDefaultPolicy")]
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
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<CharacterGetResponseDto>>> GetById([FromRoute] int characterId)
        {
            ServiceResponse<CharacterGetResponseDto> response = await _characterService.GetByCharacterId(characterId);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        
        [EnableCors("MyDefaultPolicy")]
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CharacterCreateResponseDto>>> Create([FromBody] CharacterCreateRequestDto newCharacter)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            ServiceResponse<CharacterCreateResponseDto> response = await _characterService.Create(userId, newCharacter);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        
        [EnableCors("MyDefaultPolicy")]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<List<CharacterGetResponseDto>>>> Delete([FromRoute] int characterId)
        {
            var userId = Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            ServiceResponse<List<CharacterGetResponseDto>> response = await _characterService.Delete(userId, characterId);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}