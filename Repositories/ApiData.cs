using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using currencycalc.Models;

namespace currencycalc.Repositories
{
    public class ApiData : IApiData
    {
        private readonly HttpClient httpClient;
        
        public ApiData(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<ExchangeRate> GetData(string currency, string hostURL)
        {
            var exchangeRate = new ExchangeRate();

            try
            {
                var responseString = await httpClient.GetStringAsync(hostURL + currency);

                exchangeRate = Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeRate>(responseString);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return exchangeRate;
        }
        
//         public async Task<ExchangeRate> GetData(string currency, string hostURL)
//         {
//             var exchangeRate = new ExchangeRate();

//             HttpClientHandler handler = new HttpClientHandler();

//             using (var httpClient = new HttpClient(handler))
//             {
//                 httpClient.DefaultRequestHeaders.Accept.Clear();
//                 httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                 using (var response = await httpClient.GetAsync(hostURL + currency))
//                 {
//                     try
//                     {
//                         string apiResponse = await response.Content.ReadAsStringAsync();

//                         exchangeRate = Newtonsoft.Json.JsonConvert.DeserializeObject<ExchangeRate>(apiResponse); 
//                     }
//                     catch (Exception ex)
//                     {
//                         throw new Exception(ex.Message);
//                     }
//                 }
//             }

//             return exchangeRate;
//         }

        // avoid calling the API twice
        public List<string> GetCurrencies()
        {
            return new List<string>
            {
                "EUR",
                "AED",
                "ARS",
                "AUD",
                "BGN",
                "BRL",
                "BSD",
                "CAD",
                "CHF",
                "CLP",
                "CNY",
                "COP",
                "CZK",
                "DKK",
                "DOP",
                "EGP",
                "FJD",
                "GBP",
                "GTQ",
                "HKD",
                "HRK",
                "HUF",
                "IDR",
                "ILS",
                "INR",
                "ISK",
                "JPY",
                "KRW",
                "KZT",
                "MVR",
                "MXN",
                "MYR",
                "NOK",
                "NZD",
                "PAB",
                "PEN",
                "PHP",
                "PKR",
                "PLN",
                "PYG",
                "RON",
                "RUB",
                "SAR",
                "SEK",
                "SGD",
                "THB",
                "TRY",
                "TWD",
                "UAH",
                "USD",
                "UYU",
                "ZAR"
            };
        }
    }
}
