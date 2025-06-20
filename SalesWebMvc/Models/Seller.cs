using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        // Associação com a classe Department 
        public Department Department { get; set; }
        // Associação com a classe SalesRecord e instanciação da lista de vendedores
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        // Construtor padrão
        public Seller()
        {
        }

        // Contrutor com argumentos
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        // Método para adicionar uma venda a lista
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        // Método para remover uma venda da lista
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        // Método para retornar o total de vendas de um vendedor em um determinado intervalo de datas
        public double TotalSales(DateTime initial, DateTime final)
        {
            // Utilização do Linq e expressões Lambda para filtrar os dados de um determinado periodo existentes em uma lista
            // e retornar o valor total da quantia dos vendas
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
} 