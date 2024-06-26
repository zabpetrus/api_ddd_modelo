﻿using Produtos.Domain.Entities._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Interfaces._Base
{
    public interface IServiceBase<TEntity> where TEntity : Entity
    {
        void Add(TEntity obj);
        TEntity GetById(long id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}