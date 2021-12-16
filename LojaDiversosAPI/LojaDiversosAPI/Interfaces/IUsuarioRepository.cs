using LojaDiversosAPI.Domains;
using System;
using System.Collections.Generic;

namespace LojaDiversosAPI.Interfaces
{
    public interface IProductRepository
    {
        List<Product> Listar();

        Product BuscarPorId(Guid id);

        void Comprar(Guid id, int availableQuantity);

        void Adicionar(Product product);

        void Editar(Guid id, Product product);

        void Remover(Guid id);
    }
}
