using System.Linq.Expressions;
using OnlineOrder.Domain.Helpers.Models;

namespace OnlineOrder.Domain.Repositories;

public interface IGenericRepository<TEntity> where TEntity : IAggregateRoot
{
    Task<TEntity> AddAsync(TEntity entity);

    Task<TEntity> RemoveAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);
    
    Task<TEntity?> GetByIdAsync(object id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<IEnumerable<TEntity>> GetAllAsync<TProperty>(Expression<Func<TEntity, TProperty>> include);


    Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);


    Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams);


    Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams,
        Expression<Func<TEntity, bool>>? predicate);

    Task<QueryResult<TEntity>> GetOrderedPageQueryResultAsync(QueryObjectParams queryObjectParams,
        IQueryable<TEntity> query);

    Task<QueryResult<TEntity>> GetPageAsync(QueryObjectParams queryObjectParams,
        List<Expression<Func<TEntity, object>>> includes);

    Task<QueryResult<TEntity>> GetPageAsync<TProperty>(QueryObjectParams queryObjectParams,
        Expression<Func<TEntity, bool>> predicate, List<Expression<Func<TEntity, TProperty>>>? includes = null);
}