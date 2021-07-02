using System;
using System.Collections.Generic;

namespace api
{
    public class ExchangeRatesResponse {
        public Dictionary<string, ExchangeRate> bpi { get; set; }    
    }

    public class ExchangeRate
    {
        public string code { get; set; }
        public string rate { get; set; }
    }
}
