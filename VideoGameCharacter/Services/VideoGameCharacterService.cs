using VideoGameCharacter.Models;

namespace VideoGameCharacter.Services
{
    public class VideoGameCharacterService : IVideoGameCharacterService
    {
        static List<Character> Characters = new List<Character>
        {
               new() {
                    Id=1,
                    Game="God of War",
                    Name="Aphrodite",
                    Role="Side Character"
                },
                new() {
                    Id=2,
                    Game="Counter Strike 2",
                    Name="Jesta",
                    Role="Player"
                }
        };
        public Task<Character> AddCharacterAsync(Character character)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCharacterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Character>> GetAllCharactersAsync() => await Task.FromResult(Characters);
        public async Task<Character?> GetCharacterByIdAsync(int id)
        {
            return await Task.FromResult(Characters.FirstOrDefault(character=>character.Id==id));
        }

        public Task<bool> UpdateCharacterAsync(int id, Character character)
        {
            throw new NotImplementedException();
        }
    }
}
