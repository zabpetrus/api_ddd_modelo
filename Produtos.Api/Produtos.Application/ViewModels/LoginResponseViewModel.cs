using Produtos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Application.ViewModels
{
    public class LoginResponseViewModel
    {
        public UsuarioViewModel Usuario { get; set; }
        public TokenViewModel Token { get; set; }

        public LoginResponseViewModel(Usuario usuario)
        {
            if (usuario == null) return;

            Usuario = new UsuarioViewModel(usuario);
        }
    }
}
