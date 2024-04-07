using TtrpgManagerBackend.Dto.Character;

namespace TtrpgManagerBackend.DataAccess.Repositories.Character;

public interface ICharacterRepository
{
    public Task<CharacterGetResponseDto?> Insert(CharacterInsertDto requestData);
    public Task<List<CharacterGetResponseDto>?> GetByPlayerId(int playerId);
    public Task<CharacterGetResponseDto?> GetByCharacterId(int characterId);
    public Task<List<CharacterGetResponseDto>?> Delete(int userId, int characterId);
}