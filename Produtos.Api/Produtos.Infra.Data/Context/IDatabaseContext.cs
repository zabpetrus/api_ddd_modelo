﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Infra.Data.Context
{
    public interface IDatabaseContext
    {
        int SaveChanges();
    }
}
