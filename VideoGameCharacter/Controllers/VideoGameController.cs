using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameCharacter.Models;
using VideoGameCharacter.Services;

namespace VideoGameCharacter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController(IVideoGameCharacterService service) : ControllerBase
    {
      
        [HttpGet]
        public async Task<ActionResult<List<Character>>> GetCharacters()
        {
            return Ok(await service.GetAllCharactersAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharactersById(int id)
        {
            var character = await service.GetCharacterByIdAsync(id);
                        if (character is null)
                return NotFound();
                        return Ok(character);
        }
    }
}
