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

        /// <summary>
        /// Fetches rates
        /// </summary>
        /// <note>
        /// Exceptions will bubble up to the client.
        /// No error handling required because no exception is expected.
        /// </note>
        /// <returns>
        /// A collection or exchange rates
        /// </returns>
        [HttpGet]
        public async Task<IEnumerable<ExchangeRate>> Get()
        {
            var streamTask = _httpClient.GetStreamAsync("https://api.coindesk.com/v1/bpi/currentprice.json");
            var rates = await JsonSerializer.DeserializeAsync<ExchangeRatesResponse>(await streamTask);

            // The result from the API are in the format:
            // { 'USD': { code: 'USD', rate: 1.00 }}
            // We don't need the key here because the value contains the currency code
            var results = rates.bpi.Select(r => r.Value);

            return results;
        }
    }
}
