using Produtos.Infra.Data.Context;
using Produtos.Infra.Data.EntityFramework.Context;
using Produtos.Infra.Data.UnitWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Infra.Data.EntityFramework.UnitWork
{
    public class UnitWork : BaseUnitWork
    {
        public UnitWork(ProdutosContext context)
            : base((IDatabaseContext)context)
        {
        }
    }
}
