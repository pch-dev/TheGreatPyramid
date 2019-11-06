using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheGreatPyramid.Services;

namespace TheGreatPyramid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PyramidController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var reader = new Reader();
            var calculator = new Calculator();

            var rawData = reader.Read();

            calculator.Initialize(rawData);
            calculator.CalculatePyramidPath();
            calculator.CalculateMaxSum();

            var sum = calculator.MaxSum;

            return Ok(sum);
        }
    }
}
