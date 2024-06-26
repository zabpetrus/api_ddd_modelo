using Produtos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Application.ViewModels
{
    public class UsuarioViewModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public IList<PerfilViewModel> Perfis { get; set; }

        public UsuarioViewModel(Usuario usuario)
        {
            if (usuario == null) return;

            Id = usuario.Id;
            Nome = usuario.Nome;
            Email = usuario.Email;

            if (usuario.Perfis == null || !usuario.Perfis.Any()) return;

            Perfis = new List<PerfilViewModel>();

            foreach (var perfil in usuario.Perfis.Select(p => p.Perfil).ToList())
            {
                Perfis.Add(new PerfilViewModel(perfil));
            }
        }
    }
}
