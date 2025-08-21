using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        // Definição da dependencia para o 'DbContext'
        private readonly SalesWebMvcContext _context;

        // Método construtor para realizar a injeção de dependencia do 'DbContext'
        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        
        // Método para retornar os departamentos ordenados por nome por meio do uso de LINQ
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
