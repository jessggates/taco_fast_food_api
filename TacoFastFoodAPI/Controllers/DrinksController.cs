using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TacoFastFoodAPI.DAL;

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
    }
}
