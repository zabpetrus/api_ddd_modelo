using Flunt.Notifications;
using Produtos.Application.Interfaces._Base;
using Produtos.Application.ViewModels;
using Produtos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produtos.Application.Interfaces
{
    public interface IProdutoAppService : IAppServiceBase<Produto>
    {
        public IReadOnlyCollection<Notification> Notifications { get; }
        bool Invalid { get; }
        bool Valid { get; }

        IEnumerable<ProdutoViewModel> ObterProdutoPorCategoria(string categoria);
        ProdutoViewModel ObterProdutoPorUpc(string upc);
        ProdutoViewModel ObterProdutoPorSku(string sku);
        ProdutoViewModel ObterProdutoPorNome(string nome);
        ProdutoViewModel ObterProdutoPorFornecedor(string fornecedor);
        ProdutoViewModel ObterProdutoPorAutor(string fornecedor);
        Task<ProdutoViewModel> Create(ProdutoCreateViewModel pedidoViewModel);
        bool AlterarStatus(ProdutoViewModel pedidoViewModel);
        bool DesativarProduto(long id);
        bool AtivarProduto(long id);
    }
}
