using Flunt.Notifications;
using Produtos.Application.Interfaces;
using Produtos.Application.ViewModels;
using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces.Service;
using Produtos.Infra.CrossCutting.Security.Models;
using Produtos.Infra.CrossCutting.Security.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Application.AppServices
{
    public class AutenticacaoAppService : Notifiable, IAutenticacaoAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly ITokenService _tokenService;

        public AutenticacaoAppService(IUsuarioService usuarioService, ITokenService tokenService)
        {
            _usuarioService = usuarioService;
            _tokenService = tokenService;
        }

        public async Task<LoginResponseViewModel> Login(string email, string senha)
        {
            var usuario = await _usuarioService.Login(email, senha).ConfigureAwait(false);

            if (usuario == null)
                return await Task.FromResult<LoginResponseViewModel>(null).ConfigureAwait(false);

            if (usuario.Invalid)
            {
                AddNotifications(usuario);
                return await Task.FromResult<LoginResponseViewModel>(null).ConfigureAwait(false);
            }

            // Mapeia as proporiedades internas
            var result = new LoginResponseViewModel(usuario);
            if (usuario.Invalid)
            {
                AddNotifications(usuario);
                // Se for inválido, devolve o objeto mapeado com os erros de notificações para serem devolvidos para o front
                return await Task.FromResult(result).ConfigureAwait(false);
            }

            // Obtendo a lista de perfis para enviar para o token
            //var perfilList = new List<Infra.CrossCutting.Enums.Perfil>();
            //foreach (var perfil in usuario.Perfis)
            //{
            //    perfilList.Add((Infra.CrossCutting.Enums.Perfil)perfil.Perfil.Codigo);
            //}

            // Gerando o token
            var token = await _tokenService.GenerateTokenAuthentication(usuario.Nome, usuario.Email).ConfigureAwait(false);
            result.Token = new TokenViewModel()
            {
                Token = token,
                Schema = "Bearer"
            };

            return await Task.FromResult(result).ConfigureAwait(false);
        }

        private Token GetToken(Usuario usuario)
        {
            var token = new Token();
            token.DataExpiracao = DateTime.Now.AddDays(3);
            token.Id = usuario.Id;

            //if (usuario.Perfis != null && usuario.Perfis.Any())
            //{
            //    if (token.Perfis == null) token.Perfis = new List<Infra.CrossCutting.Enums.Perfil>();

            //    var perfis = usuario.Perfis.Select(p => p.Perfil.Codigo).ToList();

            //    foreach (var perfil in perfis)
            //    {
            //        token.Perfis.Add((Infra.CrossCutting.Enums.Perfil)perfil);
            //    }
            //}

            return token;
        }
    }
}
