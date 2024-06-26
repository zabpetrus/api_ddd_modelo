using Produtos.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Produtos.Infra.CrossCutting.Security.Helpers;
using Flunt.Validations;
using Flunt.Notifications;

namespace Produtos.Domain.Entities
{
    public class Usuario : Entity
    {
        public int Id { get; set; }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public bool Ativo { get; private set; }
        public ICollection<UsuarioPerfil> Perfis { get; set; }

        protected Usuario() { /* Required By EF */ }

        public Usuario(string nome, string email, string senha, bool ativo, IEnumerable<Perfil> perfis)
        {
            Nome = nome;
            Email = email;
            Senha = MD5Helper.Encrypt(senha);
            Ativo = ativo;

            if (perfis != null && perfis.Any())
            {
                Perfis = new List<UsuarioPerfil>();

                foreach (var perfil in perfis)
                {
                    Perfis.Add(new UsuarioPerfil(Id, perfil.Id));
                }
            }

            AddNotifications(new Contract()
              .Requires()
              .IsNotNull(nome, "Usuario.Nome", "Nome não informado")
              .IsNotNull(email, "Usuario.Email", "E-mail não informado")
              .IsNotNull(senha, "Usuario.Senha", "Senha não informada")
              .IsNotNull(perfis, "Usuario.Perfis", "Perfil não informado")
            );
        }

        public Usuario(IReadOnlyCollection<Notification> notifications)
        {
            AddNotifications(notifications);
        }
    }
}
