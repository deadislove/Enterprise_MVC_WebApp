using Enterprise_MVC_WebApplication.Core.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_MVC_WebApplication.Infra.Repositories
{
    public class TransactionRepository<T> : ITransactionRepository<T> where T : class
    {
        private TestEntities dbContext = new TestEntities();

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        public Task<IEnumerable<T>> GetAll()
        {
            var tran = dbContext.Database.BeginTransaction();

            try
            {
                var obj = dbContext.Set<T>().ToList() as IEnumerable<T>;
                tran.Commit();
                return Task.Run(() => obj);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return null;
            }
            finally
            {
                tran.Dispose();
            }
        }
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id">int32</param>
        /// <returns> T </returns>
        public Task<T> GetById(int id)
        {
            var tran = dbContext.Database.BeginTransaction();

            try
            {
                if (id != 0)
                {
                    var obj = dbContext.Set<T>().Find(id) as T;
                    tran.Commit();
                    return Task.Run(() => obj);
                }
                else
                    return null;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return null;
            }
            finally
            {
                tran.Dispose();
            }
        }
        /// <summary>
        /// Create new data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task Create(T entity)
        {
            var tran = dbContext.Database.BeginTransaction();

            try
            {
                dbContext.Set<T>().Add(entity);
                dbContext.SaveChanges();
                tran.Commit();
                return Task.FromResult<bool>(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return Task.FromResult<bool>(false);
            }
            finally
            {
                tran.Dispose();
            }
        }
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task Update(T entity)
        {
            var tran = dbContext.Database.BeginTransaction();

            try
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
                tran.Commit();
                return Task.FromResult<bool>(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return Task.FromResult<bool>(false);
            }
            finally
            {
                tran.Dispose();
            }
        }
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task Delete(T entity)
        {
            var tran = dbContext.Database.BeginTransaction();

            try
            {
                dbContext.Entry(entity).State = EntityState.Deleted;
                dbContext.SaveChanges();
                tran.Commit();
                return Task.FromResult<bool>(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return Task.FromResult<bool>(false);
            }
            finally
            {
                tran.Dispose();
            }

        }
    }
}
