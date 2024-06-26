using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Interfaces
{
    public interface IProdutoService : IServiceBase<Produto>
    {
        Produto ObterProdutoPorUpc(string upc);
        IEnumerable<Produto> ObterProdutosPorSku(string sku);
        IEnumerable<Produto> ObterProdutoPorUpc(IEnumerable<string> upcs);
    }
}
