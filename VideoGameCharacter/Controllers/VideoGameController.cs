using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacter.Dtos;
using VideoGameCharacter.Models;
using VideoGameCharacter.Services;

namespace VideoGameCharacter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(IVideoGameCharacterService service) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<List<CharacterResponseDto>>> GetCharacters()
        {
            return Ok(await service.GetAllCharactersAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterResponseDto>> GetCharactersById(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
            if (character is null)
                return NotFound();
            return Ok(character);
        }

        // --- create ---
        [HttpPost]
        public async Task<ActionResult<CharacterResponseDto>> AddCharacter(CreateCharacterDto character)
        {
            var newCharacter = await service.AddCharacterAsync(character);
            return CreatedAtAction(nameof(GetCharactersById), new { id = newCharacter.Id }, newCharacter);

        }
        [HttpPut]
        public async Task<ActionResult> UpdateCharacter(int id, UpdateCharacterDto character)
        {
            var updated = await service.UpdateCharacterAsync(id, character);
            if (!updated)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacter(int id)
        {
            var deleted = await service.DeleteCharacterAsync(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
