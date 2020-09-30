using System.Collections.Generic;
using System.Threading.Tasks;
using currencycalc.Models;

namespace currencycalc.Repositories
{
    public interface IApiData
    {
        Task<ExchangeRate> GetData(string currency, string hostURL);
        List<string> GetCurrencies();
    }
}