using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        // Definição da dependencia para o 'DbContext'
        private readonly SalesWebMvcContext _context;

        // Método construtor para realizar a injeção de dependencia do 'DbContext'
        public SellerService(SalesWebMvcContext context)
        {
            _context = context;
        }

        // Retorna uma lista do banco de dados contendo todos os vendedores
        public List<Seller> FindAll()
        {
            // Operação para retornar do banco de dados todos os vendedores em uma lista (Esta operação é uma operação sincrona)
            // Em outras palavras acessa a fonte de dados relacionada a tabela de vendedores e converte isto em uma lista
            return _context.Seller.ToList();
        }
    }
}