using FunFactAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FunFactAPI.Controllers
{
    [Route("api/classify-number")]
    [ApiController]
    public class ClassifierController : ControllerBase
    {
        private readonly HttpClient _numbersHttpClient;
        public ClassifierController(IHttpClientFactory httpClientFactory)
        {

            _numbersHttpClient = httpClientFactory.CreateClient("NumbersAPIClient");

        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return BadRequest(new ErrorResponse
                {
                    number = null,
                    error = true
                });
            }
            if (!int.TryParse(number, out int result))
            {
                return BadRequest(new ErrorResponse
                {
                    number = "alphabet",
                    error = true
                });
            }

            var value = int.Parse(number);
            var primeStatus = isPrime(value);
            var evenStatus = isEven(value);
            var digitSum = GetDigitSum(value);
            var digitSumStatus = digitSum == -1 ? (int?)null : digitSum;
            var perfectNumberStatus = isPerfectNumber(value);
            var armstrongStatus = isArmstrong(value);
            string funFact = "";

            var properties = new string[] { };
            properties = (armstrongStatus, evenStatus) switch
            {
                (true, true) => new[] { "armstrong", "even" },
                (true, false) => new[] { "armstrong", "odd" },
                (false, true) => new[] { "even" },
                (false, false) => new[] { "odd" }
            };

            var request = await _numbersHttpClient.GetAsync($"{number}/math");
            if (request.IsSuccessStatusCode)
            {
                var response = await request.Content.ReadAsStringAsync();
                funFact = response;
            }

            var responseModel = new SuccessResponse
            {
                number = Convert.ToInt32(number),
                is_prime = primeStatus,
                is_perfect = perfectNumberStatus,
                properties = properties,
                digit_sum = digitSumStatus,
                fun_fact = funFact
            };

            return Ok(responseModel);
        }

        private bool isEven(int number)
        {
            return number % 2 == 0;
        }
        private bool isPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
        private int GetDigitSum(int number)
        {
            if (number < 0) return -1;
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;

        }
        private bool isArmstrong(int number)
        {
            if (number < 0) return false;
            int sum = 0;
            int temp = number;
            while (temp != 0)
            {
                int remainder = temp % 10;
                sum += remainder * remainder * remainder;
                temp /= 10;
            }
            return sum == number;
        }
        private bool isPerfectNumber(int number)
        {
            if(number < 0) return false;
            int sum = 0;
            for (int i = 1; i < number; i++)
            {
                if (number % i == 0)
                {
                    sum += i;
                }
            }
            return sum == number;
        }
    }
}
