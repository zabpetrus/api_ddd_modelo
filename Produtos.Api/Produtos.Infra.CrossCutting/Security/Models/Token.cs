using Newtonsoft.Json;
using Produtos.Infra.CrossCutting.Security.Helpers;
using System;
using System.Collections.Generic;

namespace Produtos.Infra.CrossCutting.Security.Models
{
    public class Token
    {
        public long Id { get; set; }
        //public IList<Perfil> Perfis { get; set; }
        public DateTime DataExpiracao { get; set; }

        public Token()
        {

        }

        public Token(DateTime dataExpiracao, long id)
        {
            //this.Perfis = roles;
            this.DataExpiracao = dataExpiracao;
            this.Id = Id;
        }

        public string ToBase64()
        {
            var json = JsonConvert.SerializeObject(this);
            var aes = new AESHelper();
            return aes.EncryptString(json);
        }

        public static Token GetObject(string val)
        {
            var aes = new AESHelper();
            var jsonString = aes.DecryptString(val);
            return JsonConvert.DeserializeObject<Token>(jsonString);
        }
    }
}
