using Produtos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Application.ViewModels
{
    public class ProdutoCreateViewModel
    {
        /// <summary>
        /// Id do produto
        /// </summary>
        private int ID { get; set; }

        /// <summary>
        /// nome do produto
        /// </summary>
        private string Nome { get; set; }

        /// <summary>
        /// nome do Autor ou Fornecedor
        /// </summary>
        private string Autor { get; set; }

        /// <summary>
        /// nome do Autor ou Fornecedor
        /// </summary>
        private string Fornecedor { get; set; }

        /// <summary>
        /// Email do comprador
        /// </summary>
        private decimal PrecoUnitario { get; set; }

        /// <summary>
        /// Comprador* (Tirar dúvidas com o André)
        /// </summary>
        private string Upc { get; set; }

        /// <summary>
        /// Telefone do comprador
        /// </summary>
        private string Sku { get; set; }

        /// <summary>
        /// Moeda
        /// </summary>
        private int Estoque { get; set; }

        /// <summary>
        /// Impostos sobre itens
        /// </summary>
        private bool Ativo { get; set; }

        /// <summary>
        /// Ativo/Inativo
        /// </summary>
        private bool Enable { get; set; }

        private double Cost { get; set; }
        private double Length { get; set; }
        private string Description { get; set; }
        private double Weight { get; set; }
        private string Ean { get; set; }
        private double Price { get; set; }
        private int Qty { get; set; }
        private string Name { get; set; }
        private string nbm { get; set; }
        private double Width { get; set; }
        private double Promotional_Price { get; set; }
        private string Brand { get; set; }
        private string Staus { get; set; }
        private double Height { get; set; }
        /// <summary>
        /// Referências do estoque
        /// </summary>
        public virtual ICollection<ProdutoEstoque> Estoques { get; set; }

        /// <summary>
        /// Referências dos itens de compra utilizadas pelo EF
        /// </summary>
        public virtual ICollection<Especificacoes> Especificacoes { get; set; }

        /// <summary>
        /// Referências dos itens de compra utilizadas pelo EF
        /// </summary>
        public virtual ICollection<Imagens> Imagens { get; set; }

    }
}
    