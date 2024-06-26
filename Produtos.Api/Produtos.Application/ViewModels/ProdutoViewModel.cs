using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Application.ViewModels
{
    public class ProdutoViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string AutorFornecedor { get; set; }
        public decimal PrecoUnitario { get; set; }
        public string Sku { get; set; }
        public int Estoque { get; set; }
        public bool Ativo { get; set; }

        public string upc { get; set; }
        public string tipoprod { get; set; }
        public string Pais { get; set; }
        public string Origem { get; set; }
        public string IdOrigem { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string label_abbr { get; set; }

        public string catalog { get; set; }
        public string configuration { get; set; }
        public int? formato { get; set; }
        public string music_cat { get; set; }
        public string music_subcat { get; set; }
        public decimal? sell { get; set; }
        public DateTime? rel_date { get; set; }
        public DateTime? DISC_DATE { get; set; }
        public string spcl_ord { get; set; }
        public bool habilitado { get; set; }
        public string promocoes { get; set; }
        public decimal? precopro { get; set; }
        public DateTime? datainipro { get; set; }
        public DateTime? datafimpro { get; set; }
        public int prontaentrega { get; set; }
        public string detalhe { get; set; }
        public int PESO { get; set; }
        public string imagem { get; set; }
        public string FotoManual { get; set; }
        public string? obs { get; set; }
        public string CODIGOUNICO { get; set; }
        public Byte[]? atualizaindice { get; set; }
        public string? prazo { get; set; }
        public string? atendimento { get; set; }
        public string? LANGUAGE { get; set; }
        public string? COUNTRY { get; set; }
        public bool? Deletado { get; set; }
        public bool? exclusive { get; set; }
        public bool? classico { get; set; }
        public bool OST { get; set; }
        public int? IndImagem { get; set; }
        public bool? IndRaridade { get; set; }
        public bool? nacartist { get; set; }
        public string MajorLabel { get; set; }
        public int? indpesquisado { get; set; }
        public string? console { get; set; }
        public string? prodnum { get; set; }
        public bool? noamazon { get; set; }
        public int PESO_CDPOINT { get; set; }
        public bool? NOEBAY { get; set; }
        public bool? NOEBAYTEMP { get; set; }
        public DateTime? NOEBAYTEMPDATA { get; set; }
        public bool? NoAmazonManual { get; set; }
        public bool? NoEbayManual { get; set; }
        public int? indprevenda { get; set; }
        public bool? NoBuscaPe { get; set; }
        public DateTime? NoBuscaPeData { get; set; }
        public int? IndSOH { get; set; }
        public bool? NOEBAYOVERRIDE { get; set; }
        public bool? NoAmazonOverride { get; set; }
        public bool? NOTCPDISTSHOP { get; set; }
        public bool? NOTCPDISTSHOPOVERRIDE { get; set; }
        public bool? NOTCPDISTSHOPMANUAL { get; set; }
        public string? flag_thumbnail { get; set; }
        public long CodFullText { get; set; }
        public bool? noYahoo { get; set; }
        public string? Codigo13Digitos { get; set; }

        //public long IdTipoProduto { get; set; }
        //public virtual TipoProduto TipoProduto { get; set; }

        //public virtual ICollection<ProdutoEstoque> Estoques { get; private set; }
        //public virtual ICollection<Especificacoes> Especificacoes { get; set; }
        //public virtual ICollection<Imagens> Imagens { get; set; }
        //public virtual ICollection<Variacoes> Variacoes { get; set; }
    }
}
