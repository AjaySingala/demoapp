using Microsoft.AspNetCore.Mvc;

namespace YourNamespace.Controllers // Replace 'YourNamespace' with your actual namespace
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        // Example GET action
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from MyController");
        }

        // Additional actions can be added here
        // GET demo/factorial/{number}
        [HttpGet("{factorial}/{number}")]
        public ActionResult<long> GetFactorial(int number)
        {
            try
            {
                // long result = Factorial(number);
                var result = Factorial(number);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Optimized Factorial.
        private long Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Factorial is not defined for negative numbers.");
            }

            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                checked // Detect overflow
                {
                    result *= i;
                }
            }
            return result;
        }
    }
}
