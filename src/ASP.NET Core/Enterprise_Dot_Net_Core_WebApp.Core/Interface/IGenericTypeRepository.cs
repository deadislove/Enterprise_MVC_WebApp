using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface
{
    public interface IGenericTypeRepository<T> where T: class
    {
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Async GetAll
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        Task<IEnumerable<T>> AsyncGetAll();

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="predicate">Where conditions</param>
        /// <returns>T</returns>
        Task<T> Find(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Async Find
        /// </summary>
        /// <param name="predicate">Where conditions</param>
        /// <returns>T</returns>
        Task<T> AsyncFind(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Get information by ID
        /// </summary>
        /// <param name="id">int32</param>
        /// <returns></returns>
        Task<T> GetById(int id);
        /// <summary>
        /// Async Get information by ID
        /// </summary>
        /// <param name="id">int32</param>
        /// <returns></returns>
        Task<T> AsyncGetById(int id);

        /// <summary>
        /// Create new data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        Task Create(T entity);
        /// <summary>
        /// Async create new data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        Task AsyncCreate(T entity);
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        Task Update(T entity);
        /// <summary>
        /// Async update data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        Task AsyncUpdate(T entity);
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        Task Delete(T entity);
        /// <summary>
        /// Async delete data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        Task AsyncDelete(T entity);

        /// <summary>
        /// Row count
        /// </summary>
        /// <param name="predicate">Where conditions</param>
        /// <returns>Row count number.</returns>
        Task<int> RowCount(Func<T, bool> predicate);
        /// <summary>
        /// Row count
        /// </summary>
        /// <param name="predicate">Where conditions</param>
        /// <returns>Row count number.</returns>
        Task<int> AsyncRowCount(Func<T, bool> predicate);

        /// <summary>
        /// Database save change.
        /// </summary>
        /// <returns></returns>
        Task SaveChange();

        /// <summary>
        /// Database async save change.
        /// </summary>
        /// <returns></returns>
        Task SaveChangeAsync();

    }
}
