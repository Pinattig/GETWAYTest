using Backend.Data;
using Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class ProductsService
    {
        public ProdutoDBContext context { get; set; }

        public ProductsService()
        {
            context = new ProdutoDBContext();
        }

        public ProductsViewModel GetMany(RequestProductsModel model)
        {
            IEnumerable<Produto> allProducts = null;
            if(model.OptionalFilterId != 0)
            {
                allProducts = context.Produtos.Where(x => x.Id == model.OptionalFilterId);
            }
            else
            {
                allProducts = context.Produtos.OrderBy(x => x.Nome);
                if (string.IsNullOrEmpty(model.OptionalFilterName))
                {
                    allProducts = allProducts.Where(x => x.Nome.Contains(model.OptionalFilterName));
                }
            }

            var countProducts = allProducts.Count();
            var numberOfPages = (int)Math.Ceiling((decimal) countProducts / model.ProductsPageCount);

            var requestProducts = allProducts.Skip(model.ProductsPageCount * (model.CurrentPage-1)).Take(model.ProductsPageCount);

            return new ProductsViewModel(requestProducts, model.CurrentPage, countProducts, numberOfPages);
        }

        public Produto GetOne(long produtoId)
        {
            return context.Produtos.FirstOrDefault(x => x.Id == produtoId);
        }

        public Produto Save(Produto produto)
        {
            if (produto.Id != 0)
            {
                context.Produtos.Update(produto);
            }
            else
            {
                context.Add(produto);
            }

            context.SaveChanges();
            return produto;
        }

        public void Delete(long produtoId)
        {
            var produto = context.Produtos.FirstOrDefault(x => x.Id == produtoId);
            context.Remove(produto);
            context.SaveChanges();
        }
    }
}
