using System.Collections.Generic;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {
        // Dados utilizados na tela de cadastro de vendedores
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}