using System;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class DepartmentsController : Controller
    {
        // Action (Ação) para retornar uma View (Pagina) referente aos departamentos
        public IActionResult Index()
        {
            // Instancia uma lista de departamentos
            List<Department> list = new List<Department>();

            // Adiciona 2 elementos a lista de departamentos
            list.Add(new Department { Id = 1, Name = "Eletronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });

            // Os dados que são passados por parametro no método 'View' são os dados que o controlador envia para a view
            return View(list);
        }
    }
}