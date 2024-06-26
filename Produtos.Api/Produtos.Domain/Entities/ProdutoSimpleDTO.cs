using Produtos.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Produtos.Domain.Entities
{
    public class ProdutoSimpleDTO : Entity
    {
        public int Id { get; set; }

        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Fornecedor do produto
        /// </summary>
        public string Autor { get; set; }

        /// <summary>
        /// Fornecedor do produto
        /// </summary>
        public string Fornecedor { get; set; }
        /// <summary>
        /// Fabricante do item comprado
        /// </summary>
        public string Fabricante { get; private set; }

        /// <summary>
        /// Preço do produto
        /// </summary>
        public decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Identificador único do produto (Código de barra)
        /// </summary>
        public string Upc { get; set; }

        /// <summary>
        /// Identificador para Unidade de manutenção de estoque
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// Indica se o produto está ativo ou não para comercialização
        /// </summary>
        public bool Ativo { get; set; }

        ///// <summary>
        /////  Referências de tipo de produto utilzado pelo EF
        ///// </summary>
        //public long IdTipoProduto { get; set; }
        //public virtual TipoProduto TipoProduto { get; set; }

        /// <summary>
        /// Referências do estoque
        /// </summary>
        public virtual ICollection<ProdutoEstoque> Estoques { get; private set; }

        /// <summary>
        /// Referências dos itens de compra utilizadas pelo EF
        /// </summary>
        public virtual ICollection<Especificacoes> Especificacoes { get; set; }

        /// <summary>
        /// Referências dos itens de compra utilizadas pelo EF
        /// </summary>
        public virtual ICollection<Imagens> Imagens { get; set; }
        /// <summary>
        /// Referências dos itens de compra utilizadas pelo EF
        /// </summary>
        protected ProdutoSimpleDTO() { /* Required by EF */ }

        public ProdutoSimpleDTO(string nome, string autor, string fornecedor, decimal precoUnitario, string upc, string sku, bool ativo)
        {
            Nome = nome;
            Autor = autor;
            Fornecedor = fornecedor;
            PrecoUnitario = precoUnitario;
            Upc = upc;
            Sku = sku;
            Ativo = ativo;
        }

        public int GetEstoque()
        {
            if (Estoques == null || !Estoques.Any()) return 0;

            return Estoques.Sum(e => e.Quantidade);
        }
    }
}
