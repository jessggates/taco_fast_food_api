using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
