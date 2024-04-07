using TtrpgManagerBackend.Dto.Character;

namespace TtrpgManagerBackend.Services.Character
{
	public interface ICharacterService
	{
		public Task<ServiceResponse<CharacterCreateResponseDto>> Create(int userId, CharacterCreateRequestDto requestData);
		public Task<ServiceResponse<List<CharacterGetResponseDto>>> GetByPlayerId(int playerId);
		public Task<ServiceResponse<CharacterGetResponseDto>> GetByCharacterId(int characterId);
		public Task<ServiceResponse<List<CharacterGetResponseDto>>> Delete(int userId, int characterId);
	}
}