using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces.Repository;
using Produtos.Infra.CrossCutting.Pagination;
using Produtos.Infra.Data.EntityFramework.Context;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Produtos.Infra.Data.EntityFramework.Repository
{
    public class ProdutoRepository : EFRepositoryBase<ProdutosContext, Produto>, IProdutoRepository
    {
        public ProdutoRepository(ProdutosContext context)
            : base(context)
        {
        }


        public Produto ObterProdutoPorUpc(string upc)
        {
            return _databaseContext.Produtos.FirstOrDefault(c => c.upc == upc);
        }

        public IEnumerable<Produto> ObterProdutoPorUpc(IEnumerable<string> upcs)
        {
            return _databaseContext.Produtos.Where(p => upcs.Contains(p.upc)).ToList();
        }

        public IEnumerable<Produto> ObterProdutosPorSku(string sku)
        {
            var pUpc = sku.Substring(startIndex: sku.Length - 13, 13);
            return _databaseContext.Produtos.Where(c => c.upc == pUpc).ToList();
        }
    }
}
