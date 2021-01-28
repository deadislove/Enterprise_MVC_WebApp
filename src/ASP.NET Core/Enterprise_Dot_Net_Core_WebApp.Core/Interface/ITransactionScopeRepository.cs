using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface
{
    public interface ITransactionScopeRepository<T> where T : class
    {
        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        Task<IEnumerable<T>> GetAll();
        /// <summary>
        /// Get information by ID
        /// </summary>
        /// <param name="id">int32</param>
        /// <returns></returns>
        Task<T> GetById(int id);
        /// <summary>
        /// Create new data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        Task Create(T entity);
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        Task Update(T entity);
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        Task Delete(T entity);
    }
}
