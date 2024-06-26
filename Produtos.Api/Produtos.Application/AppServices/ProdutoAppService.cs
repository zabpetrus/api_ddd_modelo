using AutoMapper;
using Flunt.Notifications;
using Microsoft.Extensions.Logging;
using Produtos.Application.Interfaces;
using Produtos.Application.AppServices._Base;
using Produtos.Application.ViewModels;
using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Interfaces._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Application.AppServices
{
    public class ProdutoAppService : AppServiceBase<Produto>, IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoService produtoService, ILogger<ProdutoAppService> logger, IMapper mapper)
            : base(produtoService)
        {
            _produtoService = produtoService;
            _logger = logger;
            _mapper = mapper;
        }

        public IReadOnlyCollection<Notification> Notifications => throw new NotImplementedException();

        public bool Invalid => throw new NotImplementedException();

        public bool Valid => throw new NotImplementedException();

        public ProdutoViewModel GetByUpc(string upc)
        {
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(_produtoService.ObterProdutoPorUpc(upc));
            return produtoViewModel;     // _produtoService.ObterProdutoPorUpc(upc);
        }

        public bool AlterarStatus(ProdutoViewModel pedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public bool AtivarProduto(int id)
        {
            throw new NotImplementedException();
        }

        public bool AtivarProduto(long id)
        {
            throw new NotImplementedException();
        }

        public void Create(ProdutoViewModel pedido)
        {
            throw new NotImplementedException();
        }

        public Task<ProdutoViewModel> Create(ProdutoCreateViewModel pedidoViewModel)
        {
            throw new NotImplementedException();
        }

        public bool DesativarProduto(int id)
        {
            throw new NotImplementedException();
        }

        public bool DesativarProduto(long id)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel ObterProdutoPorAutor(string fornecedor)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> ObterProdutoPorCategoria(string categoria)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel ObterProdutoPorFornecedor(string fornecedor)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel ObterProdutoPorNome(string nome)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel ObterProdutoPorSku(string sku)
        {
            throw new NotImplementedException();
        }

        public ProdutoViewModel ObterProdutoPorUpc(string upc)
        {
            var produtoViewModel = _mapper.Map<ProdutoViewModel>(_produtoService.ObterProdutoPorUpc(upc));
            return produtoViewModel;
        }

        public IEnumerable<ProdutoViewModel> ObterProdutosPorPedidoId(string pedidoId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProdutoViewModel> ObterProdutosPorTipo(int IdTipo)
        {
            throw new NotImplementedException();
        }
    }
}
