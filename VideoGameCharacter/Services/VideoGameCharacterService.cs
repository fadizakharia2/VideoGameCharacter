using Microsoft.EntityFrameworkCore;
using VideoGameCharacter.Data;
using VideoGameCharacter.Dtos;
using VideoGameCharacter.Models;

namespace VideoGameCharacter.Services
{
    public class VideoGameCharacterService(AppDbContext context) : IVideoGameCharacterService
    {
        public async Task<CharacterResponseDto> AddCharacterAsync(CreateCharacterDto character)
        {
            var newChar = new Character()
            {
                Name = character.Name,
                Game = character.Game,
                Role = character.Role
            };
            context.Characters.Add(newChar);
            await context.SaveChangesAsync();
            return new CharacterResponseDto()
            {
                Id = newChar.Id,
                Name = newChar.Name,
                Game = newChar.Game,
                Role = newChar.Role
            };
        }

        public async Task<bool> DeleteCharacterAsync(int id)
        {
            var foundChar = await context.Characters.FindAsync(id);
            if (foundChar != null)
            {
                context.Remove(foundChar);
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<CharacterResponseDto>> GetAllCharactersAsync() {
            return await context.Characters
         .Select(Character => new CharacterResponseDto()
         {
             Id = Character.Id,
             Game = Character.Game,
             Name= Character.Name,
             Role= Character.Role
         }).ToListAsync();
        }
        public async Task<CharacterResponseDto?> GetCharacterByIdAsync(int id)
        {
            return await context.Characters.Where(c=>c.Id==id).Select(
                Character => new CharacterResponseDto()
                {
                    Id = Character.Id,
                    Game = Character.Game,
                    Name = Character.Name,
                    Role = Character.Role
                }
                ).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateCharacterAsync(int id, UpdateCharacterDto character)
        {
            var foundChar= await context.Characters.FindAsync(id);
            if (foundChar != null)
            {
                foundChar.Name = character.Name;
                foundChar.Role = character.Role;
                foundChar.Game = character.Game;
                await context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
