namespace TtrpgManagerBackend.Dto.Character;

public class CharacterInsertDto
{
    public int PlayerId { get; set; }
    public string Name { get; set; }
    public int RaceId { get; set; }
    public int ClassId { get; set; }
    public int Level { get; set; }
    public int MaxHealthPoints { get; set; }
    public int HealthPoints { get; set; }
}