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

namespace Produtos.Infra.Data.Repository
{
    public abstract class RepositoryBase<TContext, TEntity> : IRepositoryBase<TEntity>
           where TContext : IDatabaseContext
           where TEntity : Entity
    {
        protected TContext _context;

        public RepositoryBase(TContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Obtém um objeto por identificador
        /// </summary>
        /// <param name="id">Identificador do objeto (chave primária no banco)</param>
        public abstract TEntity GetById(object id);

        /// <summary>
        /// Obtém um objeto por identificador
        /// </summary>
        /// <param name="id">Identificador do objeto (chave primária no banco)</param>
        public abstract Task<TEntity> GetByIdAsync(object id);

        /// <summary>
        /// Obtém uma query baseada no filtro passado
        /// </summary>
        /// <example>Get(e => e.Enable == true)</example>
        public abstract IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Obtém a quantidade de registros existentes a partir do filtro passado
        /// </summary>
        /// <example>Count(e => e.Enable == true)</example>
        public abstract int Count(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Obtém a quantidade de registros existentes a partir do filtro passado
        /// </summary>
        /// <example>await Count(e => e.Enable == true)</example>
        public abstract Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Obtém uma lista de registros existentes a partir do filtro passado
        /// </summary>
        /// <example>Get(e => e.Enable == true, 1, 10)</example>
        public abstract IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize);

        /// <summary>
        /// Obtém a lista paginada de registros existentes a partir do filtro passado
        /// </summary>
        public abstract PagedList<TEntity> Paginate(Expression<Func<TEntity, bool>> filter, int pageNumber, int pageSize);

        /// <summary>
        /// Obtém a lista de todos os registros cadastrados
        /// </summary>
        public abstract IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Obtém uma query baseada no filtro passado
        /// </summary>
        /// <example>await GetAsync(e => e.Enable == true)</example>
        protected abstract Task<IQueryable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

        /// <summary>
        /// Adiciona uma entidade ao contexto do banco
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        public abstract void Create(TEntity entity);

        /// <summary>
        /// Adiciona um conjunto de entidades ao contexto do banco
        /// </summary>
        /// <param name="entities">Entidades</param>
        public abstract void CreateMultiples(IEnumerable<TEntity> entities);

        /// <summary>
        /// Atualiza o estado de uma entidade no contexto do banco
        /// </summary>
        /// <param name="entity">Entidade</param>
        public abstract void Update(TEntity entity);

        /// <summary>
        /// Atualiza o estado de um conjunto de entidades no contexto do banco
        /// </summary>
        /// <param name="entities">Entidades</param>
        public abstract void UpdateMultiples(IEnumerable<TEntity> entities);

        /// <summary>
        /// Remove uma entidade do contexto do banco
        /// </summary>
        /// <param name="entity">Entidade</param>
        public abstract void Delete(TEntity entity);

        /// <summary>
        /// Remove um conjunto de entidades do contexto do banco
        /// </summary>
        /// <param name="entities">Entidades</param>
        public abstract void DeleteMultiples(IEnumerable<TEntity> entities);
    }
}
