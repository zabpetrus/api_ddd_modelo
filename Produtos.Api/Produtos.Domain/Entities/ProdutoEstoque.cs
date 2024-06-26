using Produtos.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Domain.Entities
{
    public class ProdutoEstoque : Entity
    {
        public int Id { get; set; }

        /// <summary>
        /// Quantidade disponível
        /// </summary>
        public int Quantidade { get; set; }

        /// <summary>
        /// Referências do produto
        /// </summary>
        public long IdProduto { get; set; }
        public virtual Produto Produto { get; set; }

        /// <summary>
        /// Referências do local do estoque
        /// </summary>
        public int IdLocalEstoque { get; set; }
        public virtual LocalEstoque LocalEstoque { get; set; }

        protected ProdutoEstoque() { /* Required by EF */ }

        public ProdutoEstoque(Produto produto, LocalEstoque localEstoque)
        {
            Produto = produto;
            IdProduto = produto.CodFullText;

            LocalEstoque = localEstoque;
            IdLocalEstoque = IdLocalEstoque;
        }
    }
}
