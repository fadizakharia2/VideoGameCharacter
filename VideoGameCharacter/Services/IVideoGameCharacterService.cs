using VideoGameCharacter.Dtos;
using VideoGameCharacter.Models;

namespace VideoGameCharacter.Services
{
    public interface IVideoGameCharacterService
    {
        Task<List<CharacterResponseDto>> GetAllCharactersAsync();
        Task<CharacterResponseDto?> GetCharacterByIdAsync(int id);

        Task<CharacterResponseDto> AddCharacterAsync( CreateCharacterDto character );
        Task<bool> UpdateCharacterAsync(int id, UpdateCharacterDto character);
        Task<bool> DeleteCharacterAsync(int id);
    }
}
