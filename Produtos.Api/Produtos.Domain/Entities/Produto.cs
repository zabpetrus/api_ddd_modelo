using Produtos.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Produtos.Domain.Entities
{
    [Table("INVENT_CD")]
    public class Produto : Entity
    {
        /// <summary>
        /// Nome do produto
        /// </summary>
        /// 
        //[Column("upc")]
        //public string upc { get; set; }
        ///// <summary>
        ///// Nome do produto
        ///// </summary>
        ///// 
        //[Column("tipoprod")]
        //public string tipoprod { get; set; }
        ///// <summary>
        ///// Nome do produto
        ///// </summary>
        ///// 
        //[Column("Pais")]
        //public string Pais { get; set; }
        ///// <summary>
        ///// Nome do produto
        ///// </summary>
        ///// 
 
        /// <summary>
        /// Nome do produto
        /// </summary>
        /// 
        [Column("artist")]
        public string artist { get; set; }

        [Column("title")]
        public string title { get; set; }


        /// <summary>
        /// 
        /// </summary>
        [Column("sell")]
        public decimal? sell { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("rel_date")]
        public DateTime? rel_date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Column("DISC_DATE")]
        public DateTime? DISC_DATE { get; set; }


    }
}
