using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }
        public int CurrentPage { get; set; }
        public int TotalProducts { get; set; }
        public int TotalPages { get; set; }

        public ProductsViewModel(IEnumerable<Produto> produtos, int currentPage, int totalProducts, int totalPages) 
        {
            Produtos = produtos;
            CurrentPage = currentPage;
            TotalProducts = totalProducts;
            TotalPages = totalPages;
        }

        public ProductsViewModel() { }
    }
}
