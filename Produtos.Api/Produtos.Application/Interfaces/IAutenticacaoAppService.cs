using Flunt.Notifications;
using Produtos.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Application.Interfaces
{
    public interface IAutenticacaoAppService
    {
        public IReadOnlyCollection<Notification> Notifications { get; }
        bool Invalid { get; }
        bool Valid { get; }

        Task<LoginResponseViewModel> Login(string email, string senha);
    }
}
