using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeRateController : ControllerBase
    {
        const string HTTP_CLIENT_NAME = "EXCHANGE_RATE_CLIENT";
        const string EXCHANGE_RATE_URL_SETTING = "ExchangeRates:Url";

        private readonly ILogger<ExchangeRateController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ExchangeRateController(
            ILogger<ExchangeRateController> logger, 
            IHttpClientFactory httpClientFactory,
            IConfiguration configuration)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient(HTTP_CLIENT_NAME);
            _config = configuration;
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
            var url = _config[EXCHANGE_RATE_URL_SETTING];
            var streamTask = _httpClient.GetStreamAsync(url);
            var rates = await JsonSerializer.DeserializeAsync<ExchangeRatesResponse>(await streamTask);

            // The result from the API are in the format:
            // { 'USD': { code: 'USD', rate: 1.00 }}
            // We don't need the key here because the value contains the currency code
            var results = rates.bpi.Select(r => r.Value);

            return results;
        }
    }
}
