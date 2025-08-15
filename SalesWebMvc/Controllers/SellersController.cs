using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        // Definição de dependencia para o 'SellerService'
        private readonly SellerService _sellerService;

        // Método construtor para realizar a injeção de dependencia da classe 'SellerService'
        // para que seja possivel utilizar os métodos existentes na classe de serviço
        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        // O Controlador acessa o 'Model' pega o dado na lista e encaminha estes dados para a view
        public IActionResult Index()
        {
            // Vai retornar uma lista de 'Sellers' (vendedores)
            var list = _sellerService.FindAll();
            // Vai gerar um IActionResult contendo essa lista passada como parametro
            return View(list);
        }

        // Retorna a view correspondente a ação create
        public IActionResult Create()
        {
            return View();
        }

        // 'Notation' para indicar que esta ação é uma ação de 'POST'
        [HttpPost]
        // 'Notation' para prevenir ataques 'Cross-Site Request Forgery' (CSRF)
        [ValidateAntiForgeryToken]
        // Método 'Create' para inserir um vendedor no banco de dados e redirecionar para a pagina inicial da aplicação
        public IActionResult Create(Seller seller)
        {
            // Insere o vendedor criado
            _sellerService.Insert(seller);
            // Redireciona para a ação 'Index' que seria para a pagina principal
            return RedirectToAction(nameof(Index));
        }
    }
}