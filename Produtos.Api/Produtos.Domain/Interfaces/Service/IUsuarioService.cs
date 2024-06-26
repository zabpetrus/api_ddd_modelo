using Produtos.Domain.Entities;
using Produtos.Domain.Interfaces._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Interfaces.Service
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Task<Usuario> Login(string email, string senha);

        Task<Usuario> Create(Usuario usuario);
    }
}
