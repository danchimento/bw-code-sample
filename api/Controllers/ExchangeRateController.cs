using System;
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
        private static readonly HttpClient client = new HttpClient();

        private readonly ILogger<ExchangeRateController> _logger;

        public ExchangeRateController(ILogger<ExchangeRateController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<ExchangeRate>> Get()
        {
            var streamTask = client.GetStreamAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
            var rates = await JsonSerializer.DeserializeAsync<ExchangeRatesResponse>(await streamTask);

            var results = new List<ExchangeRate> {
                rates.bpi.USD,
                rates.bpi.EUR,
            };

            return results;
        }
    }
}
