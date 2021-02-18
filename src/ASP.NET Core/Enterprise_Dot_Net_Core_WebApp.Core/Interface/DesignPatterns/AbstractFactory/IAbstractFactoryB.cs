using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.AbstractFactory
{
    public interface IAbstractFactoryB<T> where T : class
    {
        /// <summary>
        /// Abstract Factory A - Check dbcontext is true
        /// </summary>
        /// <returns></returns>
        Task<bool> Get();

        /// <summary>
        /// Abstract Factory A - GetAll()
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        Task<IEnumerable<T>> GetAll();

        /// <summary>
        /// Abstract Factory A - GetByID
        /// </summary>
        /// <param name="id">int?</param>
        /// <returns>T</returns>
        Task<T> GetByID(int? id);

        /// <summary>
        /// Abstract Factory A - Create()
        /// </summary>
        /// <param name="entity">Entity model class</param>
        /// <returns>Task.FromResult(true/flase)</returns>
        Task Create(T entity);

        /// <summary>
        /// Abstract Factory A - Update()
        /// </summary>
        /// <param name="entity">Entity model class</param>
        /// <returns>Task.FromResult(true/flase)</returns>
        Task Update(T entity);

        /// <summary>
        /// Abstract Factory A - Delete()
        /// </summary>
        /// <param name="entity">Entity model class</param>
        /// <returns>Task.FromResult(true/flase)</returns>
        Task Delete(T entity);
    }
}
