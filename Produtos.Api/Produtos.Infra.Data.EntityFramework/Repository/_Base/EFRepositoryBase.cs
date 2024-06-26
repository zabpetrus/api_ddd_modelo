using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entities;
using Produtos.Domain.Entities._Base;
using Produtos.Domain.Interfaces;
using Produtos.Domain.Interfaces.Repository._Base;
using Produtos.Infra.CrossCutting.Pagination;
using Produtos.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Produtos.Infra.Data.EntityFramework.Repository
{
    public class EFRepositoryBase<TDatabaseContext, TEntity> : IRepositoryBase<TEntity>
        where TEntity : Entity
        where TDatabaseContext : DbContext
    {
        protected readonly Microsoft.EntityFrameworkCore.DbSet<TEntity> DbSet;

        protected readonly TDatabaseContext _databaseContext;

        public EFRepositoryBase(TDatabaseContext context)
        {
            this._databaseContext = context;
        }

        /// <summary>
        /// Obtém um objeto por identificador
        /// </summary>
        /// <param name="id">Identificador do objeto (chave primária no banco)</param>
        public virtual TEntity GetById(object id)
        {
            return _databaseContext.Set<TEntity>().Find(id);
        }

        /// <summary>
        /// Obtém um objeto por identificador
        /// </summary>
        /// <param name="id">Identificador do objeto (chave primária no banco)</param>
        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _databaseContext.Set<TEntity>().FindAsync(id);
        }

        /// <summary>
        /// Obtém uma query baseada no filtro passado
        /// </summary>
        /// <example>Get(e => e.Enable == true)</example>
        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return _databaseContext.Set<TEntity>().AsNoTracking().Where(filter);
        }

        /// <summary>
        /// Obtém a quantidade de registros existentes a partir do filtro passado
        /// </summary>
        /// <example>Count(e => e.Enable == true)</example>
        public virtual int Count(Expression<Func<TEntity, bool>> filter)
        {
            return _databaseContext.Set<TEntity>().AsNoTracking().Where(filter).Count();
        }

        /// <summary>
        /// Obtém a quantidade de registros existentes a partir do filtro passado
        /// </summary>
        /// <example>await Count(e => e.Enable == true)</example>
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Task.FromResult(_databaseContext.Set<TEntity>().AsNoTracking().Where(filter).Count());
        }

        /// <summary>
        /// Obtém a quantidade de registros existentes a partir do filtro passado
        /// </summary>
        /// <example>Get(e => e.Enable == true, 1, 10)</example>
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize)
        {
            Expression<Func<TEntity, bool>> sortFilter = e => e.upc != "";
            return _databaseContext.Set<TEntity>().AsNoTracking().Where(filter).OrderBy(sortFilter).Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .ToList();
        }

        public virtual PagedList<TEntity> Paginate(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize)
        {
            var items = Get(filter, pageNumber, pageSize);
            var totalItems = Count(filter);
            return new PagedList<TEntity>(items, pageNumber, pageSize, totalItems);
        }

        /// <summary>
        /// Obtém uma query baseada no filtro passado
        /// </summary>
        /// <example>await GetAsync(e => e.Enable == true)</example>
        protected virtual async Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Task.FromResult(_databaseContext.Set<TEntity>().AsNoTracking().Where(filter));
        }

        /// <summary>
        /// Obtém a lista de todos os registros cadastrados
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return _databaseContext.Set<TEntity>().AsNoTracking().ToList();
        }

        /// <summary>
        /// Adiciona uma entidade ao contexto do banco
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        public virtual void Create(TEntity entity)
        {
            _databaseContext.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Adiciona um conjunto de entidades ao contexto do banco
        /// </summary>
        /// <param name="entities">Entidades</param>
        public virtual void CreateMultiples(IEnumerable<TEntity> entities)
        {
            _databaseContext.Set<TEntity>().AddRange(entities);
        }

        /// <summary>
        /// Atualiza o estado de uma entidade no contexto do banco
        /// </summary>
        /// <param name="entity">Entidade</param>   
        public virtual void Update(TEntity entity)
        {
            _databaseContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Atualiza o estado de um conjunto de entidades no contexto do banco
        /// </summary>
        /// <param name="entities">Entidades</param>
        public virtual void UpdateMultiples(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Update(entity);
            }
        }

        /// <summary>
        /// Remove uma entidade do contexto do banco
        /// </summary>
        /// <param name="entity">Entidade</param>
        public virtual void Delete(TEntity entity)
        {
            _databaseContext.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Remove um conjunto de entidades do contexto do banco
        /// </summary>
        /// <param name="entities">Entidades</param>
        public virtual void DeleteMultiples(IEnumerable<TEntity> entities)
        {
            _databaseContext.Set<TEntity>().RemoveRange(entities);
        }
    }
}
