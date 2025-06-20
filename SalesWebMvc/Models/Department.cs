using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesWebMvc.Models
{
    public class Department
    {
        // Definição de propriedades autoimplementadas
        public int Id { get; set; }
        public string Name { get; set; }
        // Associação com a classe Seller e instanciação da lista de vendedores de um departamento
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>();

        // Construtor padrão
        public Department() 
        {
        }

        // Construtor com argumentos
        public Department(int id, string name)
        {
            Id = id;
            Name = name;
        }

        // Método para adicionar um vendedor a lista de vendedores existentes em um departamento
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        // Método para retornar o total de vendas de todos os vendedores existentes em um departamento em um determinado intervalo de datas
        public double TotalSales(DateTime initial, DateTime final)
        {
            // Para cada vendedor da lista de vendedores de um departamento é chamado o método TotalSales
            // para retornar a soma dos valores das vendas de cada vendedor naquele periodo inicial e final
            // Após isto é feito uma soma desse resultado para ter a soma das vendas de todos os vendedores de um determinado departamento
            return Sellers.Sum(Seller => Seller.TotalSales(initial, final));
        }
    }
}