using System;
using System.Collections.Generic;

namespace currencycalc.Models
{
    public class ExchangeRate
    {
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public int Time_last_updated { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }
}