using System;

namespace api
{
    public class ExchangeRatesResponse {
        public ExchangeRates bpi { get; set; }    
    }

    public class ExchangeRates
    {
        public ExchangeRate USD { get; set; }
        public ExchangeRate GBP { get; set; }
        public ExchangeRate EUR { get; set; }
    }

    public class ExchangeRate
    {
        public string code { get; set; }
        public string rate { get; set; }
    }
}
