using IconCargoPriceCalculator.Models.Request;
using IconCargoPriceCalculator.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IconCargoPriceCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceCalculatorController : ControllerBase
    {
        private readonly IPriceCalculatorRepository _priceCalculatorRepository;
        public PriceCalculatorController(IPriceCalculatorRepository priceCalculatorRepository)
        {
            _priceCalculatorRepository = priceCalculatorRepository;
        }

        
        // POST api/<PriceCalculatorController>
        [HttpPost("CalculatePrice")]
        [Authorize]
        public IActionResult Post([FromBody] InputRequest inputRequest)
        {
            var x = new InputRequest();
            if(inputRequest == null || inputRequest == new InputRequest() || (inputRequest.Width == 0 && inputRequest.Height == 0 && inputRequest.Depth == 0 && inputRequest.Weight == 0 ))
            {
                return BadRequest("Invalid request parameters");
            }
            var result =  _priceCalculatorRepository.CalculateAndAdd(inputRequest).Result;

            return Ok(result);
        }
    }
}
