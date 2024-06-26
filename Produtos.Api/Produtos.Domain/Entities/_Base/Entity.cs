using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Domain.Entities._Base
{
    public class Entity : Notifiable
    {
        //public long Id { get; set; }
        //public DateTime DataInclusao { get; set; }
        //public DateTime DataAlteracao { get; set; }
        //[Column("upc")]
        public string upc { get; set; }
        /// <summary>
        /// Nome do produto
        /// </summary>
        /// 
        //[Column("tipoprod")]
        public int tipoprod { get; set; }
        /// <summary>
        /// Nome do produto
        /// </summary>
        /// 
        //[Column("Pais")]
        public int Pais { get; set; }
        /// <summary>
        /// Nome do produto
        /// </summary>
        /// 
        //[Column("Origem")]
        public string Origem { get; set; }

    }
}
