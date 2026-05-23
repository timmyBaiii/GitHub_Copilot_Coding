using Microsoft.AspNetCore.Mvc;

namespace SalesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private const decimal TaxRate = 0.05m;

        [HttpGet("{amount}")]
        public ActionResult<SalesResult> Get(decimal amount)
        {
            var result = CalculateSalesResult(amount);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<SalesResult> Post([FromBody] SalesRequest request)
        {
            if (request is null)
            {
                return BadRequest("Request body is required.");
            }

            var result = CalculateSalesResult(request.SalesAmount);
            return Ok(result);
        }

        private static SalesResult CalculateSalesResult(decimal salesAmount)
        {
            var salesTax = Math.Round(salesAmount * TaxRate, 2, MidpointRounding.AwayFromZero);
            return new SalesResult(salesAmount, salesTax);
        }
    }

    public record SalesRequest(decimal SalesAmount);
    public record SalesResult(decimal SalesAmount, decimal SalesTax);
}
