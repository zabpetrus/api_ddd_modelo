using Flunt.Notifications;
using Produtos.Domain.Entities;
using Produtos.Domain.Entities._Base;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Interfaces._Base;
using Produtos.Domain.Interfaces.Repository._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Domain.Services
{
    public class ServiceBase<TEntity> : Notifiable, IServiceBase<TEntity> where TEntity : Entity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public void Add(TEntity obj)
        {
            _repository.Create(obj);
        }

        public TEntity GetById(long id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(TEntity obj)
        {
            _repository.Update(obj);
        }

        public void Remove(TEntity obj)
        {
            _repository.Delete(obj);
        }

        public TEntity GetById(string id)
        {
            return _repository.GetById(id);
        }
    }
}
