using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Infra.CrossCutting.Security.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAuthentication(string nome, string email);
    }
}
