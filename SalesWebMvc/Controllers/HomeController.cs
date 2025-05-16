using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    // Todo controlador herda da classe 'Controller'
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action (Ação) para retornar uma View (Pagina) referente a pagina principal
        public IActionResult Index()
        {
            return View();
        }

        // Action (Ação) para retornar uma View (Pagina) com as informações sobre
        public IActionResult About()
        {
            // Atribui um valor a uma determinada chave especificada do dicionário
            ViewData["Message"] = "Salles Web MVC App from C# Course";
            ViewData["Professor"] = "Nelio Alves";

            return View();
        }

        // Action (Ação) para retornar uma View (Pagina) com as informações de contato
        public IActionResult Contact()
        {
            // Atribui um valor a uma determinada chave especificada do dicionário
            ViewData["Message"] = "Your contact page.";

            return View();

        }

        // Action (Ação) para retornar uma View (Pagina) com as informações de privacidade
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