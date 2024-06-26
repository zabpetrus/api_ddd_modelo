using Produtos.Application.Interfaces._Base;
using Produtos.Domain.Entities._Base;
using Produtos.Domain.Interfaces._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Application.AppServices._Base
{
    public class AppServiceBase<TEntity> : IAppServiceBase<TEntity> where TEntity : Entity
    {
        protected readonly IServiceBase<TEntity> _serviceBase;

        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public virtual TEntity GetById(long id)
        {
            return _serviceBase.GetById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public virtual void Update(TEntity obj)
        {
            _serviceBase.Update(obj);
        }

        public virtual void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }
    }
}
