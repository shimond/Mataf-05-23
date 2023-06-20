using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;

namespace LoggingAndMore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            this._logger = logger;
            _logger.LogInformation("Created");
        }

        [HttpGet]
        [OutputCache(Duration = 50)]
        public DateTime GetTime(int? value)
        {
            _logger.BeginScope("IN GET TIME METHOD"); 
            _logger.LogInformation("GetTime Invoked : " + value);
            _logger.LogInformation("GetTime Invoked : {value}", value);
            _logger.LogCritical("GetTime Invoked");
            return DateTime.Now;
        }
    }
}
