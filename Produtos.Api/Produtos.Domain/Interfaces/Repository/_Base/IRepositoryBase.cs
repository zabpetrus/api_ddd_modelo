using Produtos.Domain.Entities._Base;
using Produtos.Infra.CrossCutting.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Produtos.Domain.Interfaces.Repository._Base
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        #region ReadOnly methods
        TEntity GetById(object id);
        Task<TEntity> GetByIdAsync(object id);
        int Count(Expression<Func<TEntity, bool>> filter);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize);
        PagedList<TEntity> Paginate(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize);
        IEnumerable<TEntity> GetAll();

        #endregion

        #region WriteOnly methods
        void Create(TEntity entity);
        void CreateMultiples(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateMultiples(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteMultiples(IEnumerable<TEntity> entities);
        #endregion
    }
}
