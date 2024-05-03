using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFoodAPI.DAL;
using TacoFastFoodAPI.Models;

namespace TacoFastFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private DrinksRepository _drinksRepository;

        public DrinksController(DrinksRepository drinksRepository)
        {
            _drinksRepository = drinksRepository;
        }

        [HttpGet]
        public IActionResult GetAllDrinks(string? SortByCost = null)
        {
            List<Drink> drinks = _drinksRepository.GetAllDrinks();
            if (SortByCost == "ascending")
            {
                drinks = drinks.OrderBy(d => d.Cost).ToList();
            }
            else if (SortByCost == "descending")
            {
                drinks = drinks.OrderByDescending(d => d.Cost).ToList();
            }
            return Ok(drinks);
        }

        [HttpGet("{id}")]
        public IActionResult GetDrinkById(int id)
        {
            Drink drink = _drinksRepository.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }

        [HttpPost]
        public IActionResult AddDrink([FromBody] DrinkCreationDto drinkDto)
        {
            Drink drink = new Drink
            {
                Name = drinkDto.Name,
                Cost = drinkDto.Cost,
                Slushie = drinkDto.Slushie,
            };

            _drinksRepository.AddDrink(drink);
            return CreatedAtAction("GetDrinkById", new { id = drink.Id }, drink);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDrink(int id)
        {
            Drink drink = _drinksRepository.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound();
            }
            _drinksRepository.DeleteDrinkById(id);
            return NoContent();
        }
    }
}
