using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces.Repository._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Interfaces.Repository
{
    public interface IProdutoRepository : IRepositoryBase<Produto>
    {
        Produto ObterProdutoPorUpc(string upc);
        IEnumerable<Produto> ObterProdutoPorUpc(IEnumerable<string> upcs);
        IEnumerable<Produto> ObterProdutosPorSku(string sku);
    }
}
