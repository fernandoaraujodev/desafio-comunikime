using LojaDiversosAPI.Context;
using LojaDiversosAPI.Domains;
using LojaDiversosAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LojaDiversosAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _ctx;
        public ProductRepository()
        {
            _ctx = new ProductContext();
        }

        #region OTHERS
        public Product BuscarPorId(Guid id)
        {
            return _ctx.Products.Find(id);
        }

        public void Verificar(Product product)
        {
            if (product.Price <= 0)
                throw new Exception("O preço deve ser maior que 0");
            if (product.AvailableQuantity <= 0)
                throw new Exception("O estoque deve ser maior que 0");
        }

        public void Comprar(Guid id, int availableQuantity)
        {
            Product productTemp = BuscarPorId(id);

            if (productTemp == null)
                throw new Exception("Produto não encontrado");

            if (availableQuantity > productTemp.AvailableQuantity)
                throw new Exception("Estoque insuficiente");

            productTemp.AvailableQuantity = productTemp.AvailableQuantity - availableQuantity;

            if (productTemp.AvailableQuantity == 0)
            {
                _ctx.Products.Remove(productTemp);
            }
               
            _ctx.Products.Update(productTemp);
            _ctx.SaveChanges();
        }
        #endregion

        #region CRUD
        public List<Product> Listar()
        {
            return _ctx.Products.OrderBy(o => o.CreationDate).ToList();
        }

        public void Adicionar(Product product)
        {
            _ctx.Add(product);
            _ctx.SaveChanges();
        }

        public void Editar(Guid id, Product product)
        {
            Product ProductTemp = BuscarPorId(id);

            if (ProductTemp == null)
            {
                throw new Exception("Produto não encontrado");
            }
            else
            {

                Verificar(product);

                 ProductTemp.Name = product.Name;
                 ProductTemp.Description = product.Description;
                 ProductTemp.Price = product.Price;
                 ProductTemp.AvailableQuantity = product.AvailableQuantity;
                 ProductTemp.UrlImage = product.UrlImage;
                 ProductTemp.ChangeDate = product.ChangeDate;


                 _ctx.Products.Update(ProductTemp);
                 _ctx.SaveChanges();
            }
        }

        public void Remover(Guid id)
        {
            Product ProductTemp = BuscarPorId(id);

            if (ProductTemp == null)
            {
                throw new Exception("Produto não encontrado");
            }
            else
            {
                _ctx.Products.Remove(ProductTemp);
                _ctx.SaveChanges();
            }
           
        }
        #endregion

    }
}