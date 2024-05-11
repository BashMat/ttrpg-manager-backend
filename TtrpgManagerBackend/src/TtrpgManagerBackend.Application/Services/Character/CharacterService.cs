using TtrpgManagerBackend.Dto.Character;
using TtrpgManagerBackend.DataAccess.Repositories.Character;

namespace TtrpgManagerBackend.Application.Services.Character
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        
        private const string CouldNotCreateMessage = "Could not create resource";
        private const string ResourceDoesNotExist = "Resource does not exist";

        public CharacterService(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }
        
        public async Task<ServiceResponse<CharacterGetResponseDto>> Create(int userId, CharacterCreateRequestDto requestData)
        {
            CharacterInsertDto characterToInsert = new()
            {
                PlayerId = userId,
                Name = requestData.Name,
                RaceId = requestData.RaceId,
                ClassId = requestData.ClassId,
                Level = requestData.Level,
                MaxHealthPoints = requestData.MaxHealthPoints,
                HealthPoints = requestData.HealthPoints
            };
            
            ServiceResponse<CharacterGetResponseDto> response = new()
            {
                Data = await _characterRepository.Insert(characterToInsert)
            };

            if (response.Data == null)
            {
                response.Success = false;
                response.Message = CouldNotCreateMessage;
            }
            
            return response;
        }

        public async Task<ServiceResponse<List<CharacterGetResponseDto>>> GetByPlayerId(int playerId)
        {
            ServiceResponse<List<CharacterGetResponseDto>> response = new()
            {
                Data = await _characterRepository.GetByPlayerId(playerId)
            };

            return response;
        }

        public async Task<ServiceResponse<CharacterGetResponseDto>> GetByCharacterId(int characterId)
        {
            ServiceResponse<CharacterGetResponseDto> response = new()
            {
                Data = await _characterRepository.GetByCharacterId(characterId)
            };
            
            if (response.Data == null)
            {
                response.Success = false;
                response.Message = ResourceDoesNotExist;
            }

            return response;
        }

        public async Task<ServiceResponse<List<CharacterGetResponseDto>>> Delete(int userId, int characterId)
        {
            ServiceResponse<List<CharacterGetResponseDto>> response = new()
            {
                Data = await _characterRepository.Delete(userId, characterId)
            };

            return response;
        }
    }
}