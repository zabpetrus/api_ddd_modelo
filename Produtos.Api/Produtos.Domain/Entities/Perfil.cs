using Produtos.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Domain.Entities
{
    public class Perfil : Entity
    {
        public int Id { get; set; }

        public int Codigo { get; private set; }
            public string Descricao { get; private set; }
            public bool Ativo { get; private set; }

            //public ICollection<UsuarioPerfil> Usuarios { get; private set; }

            protected Perfil() { /* Required by EF */ }
        
    }
}
