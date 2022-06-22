using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        private readonly ILogger<ExchangeRateController> _logger;
        private readonly HttpClient _httpClient;

        public ExchangeRateController(ILogger<ExchangeRateController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }
    }
}
