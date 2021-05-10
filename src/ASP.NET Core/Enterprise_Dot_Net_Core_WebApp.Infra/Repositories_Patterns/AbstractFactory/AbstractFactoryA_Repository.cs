using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.AbstractFactory;
using Enterprise_Dot_Net_Core_WebApp.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.AbstractFactory
{
    public class AbstractFactoryA_Repository<T> : IAbstractFactoryA<T>, IDisposable where T : class
    {
        private readonly DemoDbContext dbContext;

        public AbstractFactoryA_Repository(DemoDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public AbstractFactoryA_Repository()
        { }

        #region Check db connection
        /// <summary>
        /// Abstract Factory A - Check dbcontext is true
        /// </summary>
        /// <returns></returns>
        public Task<bool> Get()
        {
            try
            {
                if (dbContext != null)
                {
                    var o = dbContext.Set<T>().ToList();
                    return Task.FromResult(true);
                }
                else
                    return Task.FromResult(false);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
            finally
            {
                Dispose();
            }
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Abstract Factory A - GetAll()
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        public Task<IEnumerable<T>> GetAll()
        {
            try
            {
                var obj = dbContext.Set<T>().ToList() as IEnumerable<T>;
                return Task.FromResult(obj);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return null;
            }
            finally
            {
                Dispose();
            }
        }
        #endregion

        #region GetByID
        /// <summary>
        /// Abstract Factory A - GetByID
        /// </summary>
        /// <param name="id">int?</param>
        /// <returns>T</returns>
        public Task<T> GetByID(int? id)
        {
            try
            {
                var obj = dbContext.Set<T>().Find(id.Value) as T;
                return Task.FromResult(obj);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return null;
            }
            finally
            {
                Dispose();
            }
        }
        #endregion

        #region Create
        /// <summary>
        /// Abstract Factory A - Create()
        /// </summary>
        /// <param name="entity">Entity model class</param>
        /// <returns>Task.FromResult(true/flase)</returns>
        public Task Create(T entity)
        {
            try
            {
                dbContext.Set<T>().Add(entity);
                dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return Task.FromResult(false);
            }
            finally
            {
                Dispose();
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Abstract Factory A - Update()
        /// </summary>
        /// <param name="entity">Entity model class</param>
        /// <returns>Task.FromResult(true/flase)</returns>
        public Task Update(T entity)
        {
            try
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return Task.FromResult(false);
            }
            finally
            {
                Dispose();
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Abstract Factory A - Delete()
        /// </summary>
        /// <param name="entity">Entity model class</param>
        /// <returns>Task.FromResult(true/flase)</returns>
        public Task Delete(T entity)
        {
            try
            {
                dbContext.Entry(entity).State = EntityState.Deleted;
                dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return Task.FromResult(false);
            }
            finally
            {
                Dispose();
            }
        }
        #endregion

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
