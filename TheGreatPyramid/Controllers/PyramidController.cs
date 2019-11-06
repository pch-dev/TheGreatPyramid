using Microsoft.AspNetCore.Mvc;
using System;
using TheGreatPyramid.Services.Interface;

namespace TheGreatPyramid.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PyramidController : ControllerBase
    {
        private readonly IPyramidValueCalculator pyramidValueCalculator;

        public PyramidController(IPyramidValueCalculator pyramidValueCalculator)
        {
            this.pyramidValueCalculator = pyramidValueCalculator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                pyramidValueCalculator.Execute();

                var result = pyramidValueCalculator.CalculationResult;

                return Ok(result);
            }
            catch(Exception exception)
            {
                return StatusCode(500, exception.ToString());
            }
        }
    }
}
