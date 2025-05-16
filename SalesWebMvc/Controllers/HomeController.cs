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

        // Action (A��o) para retornar uma View (Pagina) referente a pagina principal
        public IActionResult Index()
        {
            return View();
        }

        // Action (A��o) para retornar uma View (Pagina) com as informa��es sobre
        public IActionResult About()
        {
            // Atribui um valor a uma determinada chave especificada do dicion�rio
            ViewData["Message"] = "Salles Web MVC App from C# Course";
            ViewData["Professor"] = "Nelio Alves";

            return View();
        }

        // Action (A��o) para retornar uma View (Pagina) com as informa��es de contato
        public IActionResult Contact()
        {
            // Atribui um valor a uma determinada chave especificada do dicion�rio
            ViewData["Message"] = "Your contact page.";

            return View();

        }

        // Action (A��o) para retornar uma View (Pagina) com as informa��es de privacidade
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