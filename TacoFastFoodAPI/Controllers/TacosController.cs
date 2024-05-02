using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using TacoFastFoodAPI.Models;
using TacoFastFoodAPI.DAL;

namespace TacoFastFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacosController : ControllerBase
    {
        private TacosRepository _tacosRepository;

        public TacosController(TacosRepository tacosRepository)
        {
            _tacosRepository = tacosRepository;
        }

        [HttpGet]
        public IActionResult GetAllTacos()
        {
            List<Taco> tacos = _tacosRepository.GetAllTacos();
            return Ok(tacos);
        }

        [HttpGet("{id}")]
        public IActionResult GetTacoById(int id)
        {
            Taco taco = _tacosRepository.GetTacoById(id);
            if (taco == null)
            {
                return NotFound();
            }
            return Ok(taco);
        }

        [HttpPost]
        public IActionResult AddTaco([FromBody] TacoCreationDto tacoDto) //gets the data from the body..can get from query, other places..etc.
        {
            Taco taco = new Taco
            {
                Name = tacoDto.Name,
                Cost = tacoDto.Cost,
                SoftShell = tacoDto.SoftShell,
                Chips = tacoDto.Chips
            };

            _tacosRepository.AddTaco(taco);
            return CreatedAtAction("GetTacoById", new { id = taco.Id }, taco);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteTaco(int id)
        {
            Taco taco = _tacosRepository.GetTacoById(id);
            if (taco == null)
            {
                return NotFound();
            }
            _tacosRepository.DeleteTacoById(id);
            return NoContent();
        }
    }
}
