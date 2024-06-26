using Produtos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Application.ViewModels
{
    public class PerfilViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        public PerfilViewModel(Perfil perfil)
        {
            if (perfil == null) return;

            Codigo = perfil.Codigo;
            Descricao = perfil.Descricao;
        }
    }
}
