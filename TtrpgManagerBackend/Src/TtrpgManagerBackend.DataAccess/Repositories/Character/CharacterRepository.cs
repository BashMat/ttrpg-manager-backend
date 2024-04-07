using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TtrpgManagerBackend.Common;
using TtrpgManagerBackend.Dto.Character;
using TtrpgManagerBackend.Dto.User;

namespace TtrpgManagerBackend.DataAccess.Repositories.Character;

public class CharacterRepository : ICharacterRepository
{
    private readonly IConfiguration _configuration;
    
    public CharacterRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<CharacterGetResponseDto?> Insert(CharacterInsertDto insertedCharacter)
    {
        await using SqlConnection connection = new(_configuration.GetConnectionString(ConfigurationKeys.DefaultConnection));

        int id = await connection.ExecuteScalarAsync<int>(
            "insert into [Character] (PlayerId, Name, RaceId, ClassId, Level, MaxHealthPoints, HealthPoints) values " +
            "(@PlayerId, @Name, @RaceId, @ClassId, @Level, @MaxHealthPoints, @HealthPoints); " +
            "select scope_identity();", insertedCharacter);

        return await GetByIdInternal(connection, id);
    }

    public async Task<List<CharacterGetResponseDto>?> GetByPlayerId(int playerId)
    {
        await using SqlConnection connection = new(_configuration.GetConnectionString(ConfigurationKeys.DefaultConnection));

        return await GetAllInternal(connection, playerId);
    }

    public async Task<CharacterGetResponseDto?> GetByCharacterId(int characterId)
    {
        await using SqlConnection connection = new(_configuration.GetConnectionString(ConfigurationKeys.DefaultConnection));

        return await GetByIdInternal(connection, characterId);
    }

    public async Task<List<CharacterGetResponseDto>?> Delete(int userId, int characterId)
    {
        await using SqlConnection connection = new(_configuration.GetConnectionString(ConfigurationKeys.DefaultConnection));

        await connection.ExecuteAsync("delete from [Character] where [Character].[Id]=@CharacterId",
            new { CharacterId = characterId });

        return await GetAllInternal(connection, userId);
    }

    #region Internal
    
    private async Task<CharacterGetResponseDto?> GetByIdInternal(SqlConnection connection, int characterId)
    {
        IEnumerable<CharacterGetResponseDto> characterEnumerable = await connection.QueryAsync<CharacterGetResponseDto, 
                                                                                  UserInfoDto,
                                                                                  CharacterGetResponseDto>(
            "select [C].[Id], [C].[Name], [C].[RaceId], [C].[ClassId], [C].[Level], " +
            "[C].[MaxHealthPoints], [C].[HealthPoints], " +
            "[Player].[Id], [Player].[UserName], [Player].[FirstName], [Player].[LastName], [Player].[Email] " +
            "from [Character] as [C] " +
            "inner join [User] as [Player] on [C].[PlayerId] = [Player].[Id] " +
            "where [C].[Id] = @CharacterId",
            (character, user) =>
            {
                character.Player = user;
                return character;
            },
            param: new { CharacterId = characterId },
            splitOn: "Id"); 
        
        var character = characterEnumerable.ToList();
        return character.Count == 0
            ? null 
            : character[0];
    }

    private async Task<List<CharacterGetResponseDto>> GetAllInternal(SqlConnection connection, int userId)
    {
        IEnumerable<CharacterGetResponseDto> characters = await connection.QueryAsync<CharacterGetResponseDto, 
                                                                                      UserInfoDto,
                                                                                      CharacterGetResponseDto>(
            "select [C].[Id], [C].[Name], [C].[RaceId], [C].[ClassId], [C].[Level], " +
            "[C].[MaxHealthPoints], [C].[HealthPoints], " +
            "[Player].[Id], [Player].[UserName], [Player].[FirstName], [Player].[LastName], [Player].[Email] " +
            "from [Character] as [C] " +
            "inner join [User] as [Player] on [C].[PlayerId] = [Player].[Id] " +
            "where [Player].[Id] = @UserId",
            (character, user) =>
            {
                character.Player = user;
                return character;
            },
            param: new { UserId = userId },
            splitOn: "Id");
        
        return characters.Distinct().ToList();
    }
    
    #endregion
}