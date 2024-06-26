using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Entities
{
    public class UsuarioPerfil
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int PerfilId { get; set; }
        public Perfil Perfil { get; set; }

        protected UsuarioPerfil() { /* Required by EF */ }

        public UsuarioPerfil(int usuarioId, int perfilId)
        {
            UsuarioId = usuarioId;
            PerfilId = perfilId;
        }
    }
}
