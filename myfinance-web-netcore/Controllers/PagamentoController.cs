using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers
{
    public class PagamentoController : Controller
    {
        private readonly ILogger<PagamentoController> _logger;

        public PagamentoController(ILogger<PagamentoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var PagamentoModel = new PagamentoModel();
            ViewBag.Lista = PagamentoModel.ListaPagamento();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}