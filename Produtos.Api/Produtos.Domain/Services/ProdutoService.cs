using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Services
{
    public class ProdutoService : ServiceBase<Produto>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto ObterProdutoPorUpc(string upc)
        {
            return _produtoRepository.ObterProdutoPorUpc(upc);
        }

        public IEnumerable<Produto> ObterProdutoPorUpc(IEnumerable<string> upcs)
        {
            return _produtoRepository.ObterProdutoPorUpc(upcs);
        }

        public IEnumerable<Produto> ObterProdutosPorSku(string sku)
        {
            throw new NotImplementedException();
        }
    }
}
