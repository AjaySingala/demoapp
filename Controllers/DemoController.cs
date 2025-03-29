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

        // Bad Factorial.
        private int Factorial(int number)
        {
            if (number < 0) return -1; // Poor handling of negative input
            if (number == 0) return 1;

            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
                if (result == 0) return -1; // Poor handling of overflow
            }
            return result;
        }
    }
}
