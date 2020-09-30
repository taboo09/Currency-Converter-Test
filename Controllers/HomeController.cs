using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CurrencyCalc.Models;
using Microsoft.Extensions.Configuration;
using currencycalc.Repositories;
using currencycalc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CurrencyCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IApiData _apiRepository;

        public HomeController(IConfiguration configuration, IApiData apiRepository)
        {
            _apiRepository = apiRepository ?? throw new ArgumentNullException(nameof(apiRepository));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public IActionResult Index()
        {
            var exchangeModel = new ExchangeModel();

            ViewBag.Currencies = new SelectList(_apiRepository.GetCurrencies());
            
            return View(exchangeModel);
        }

        [HttpPost]
        [Route("Home")]
        public async Task<IActionResult> Convert(ExchangeModel exchangeModel)
        {
            var url = _configuration["URLS:HostURL"];

            var data = await _apiRepository.GetData(exchangeModel.SelectedCurrency, url);

            var convertionRate = data.Rates[exchangeModel.ConvertToCurrency];

            exchangeModel.Result = exchangeModel.InputValue * data.Rates[exchangeModel.ConvertToCurrency];

            ViewBag.Currencies = new SelectList(_apiRepository.GetCurrencies());

            return View("Index", exchangeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
