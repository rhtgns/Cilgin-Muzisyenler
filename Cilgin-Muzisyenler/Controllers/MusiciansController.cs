using Cilgin_Muzisyenler.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.JsonPatch;

namespace Cilgin_Muzisyenler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {

        private static List<Musician> musicianList = new List<Musician>
        {
            new Musician { Id = 1, Name = "Ahmet Çalgı", Profession = "Ünlü Çalgı Çalar", FunFact = "Her zaman yanlış nota çalar, ama çok eğlenceli" },
            new Musician { Id = 2, Name = "Zeynep Melodi", Profession = "Popüler Melodi Yazarı", FunFact = "Şarkıları yanlış anlaşılır ama çok popüler" }
        };
        [HttpGet]
        public ActionResult<IEnumerable<Musician>> GetMusicians()
        {
            return Ok(musicianList);
        }

        [HttpGet("{id}")]
        public ActionResult<Musician> GetMusicianById(int id)
        {
            var musician = musicianList.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound();
            }
            return Ok(musician);
        }
        [HttpPost]
        public ActionResult<Musician> AddMusician([FromBody] Musician newMusician)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            musicianList.Add(newMusician);
            return CreatedAtAction(nameof(GetMusicianById), new { id = newMusician.Id }, newMusician);
        }
        [HttpPut("{id}")]
        public ActionResult UpdateMusician(int id, [FromBody] Musician updatedMusician)
        {
            var musician = musicianList.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound();
            }
            musician.Name = updatedMusician.Name;
            musician.Profession = updatedMusician.Profession;
            musician.FunFact = updatedMusician.FunFact;
            return NoContent();
        }
        [HttpPatch("{id}")]
        public ActionResult PatchMusician(int id, [FromBody] JsonPatchDocument<Musician> patchDoc)
        {
            var musician = musicianList.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound();
            }

            // Apply the patch
            patchDoc.ApplyTo(musician);

            // ModelState kontrolü, güncellemeyi etkileyebilir
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent(); // Başarılı güncelleme
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMusician(int id)
        {
            var musician = musicianList.FirstOrDefault(m => m.Id == id);
            if (musician == null)
            {
                return NotFound();
            }
            musicianList.Remove(musician);
            return NoContent();
        }
    }
}
