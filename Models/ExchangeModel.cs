using System.Collections.Generic;

namespace currencycalc.Models
{
    public class ExchangeModel
    {
        public int InputValue { get; set; } = 0;
        public string SelectedCurrency { get; set; }
        public string ConvertToCurrency { get; set; }
        public decimal Result { get; set; } = 0M;
    }
}