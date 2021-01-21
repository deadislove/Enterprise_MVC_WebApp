using Enterprise_MVC_WebApplication.Core.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Enterprise_MVC_WebApplication.Infra.Repositories
{
    public class TransactionScopeRepository<T> : ITransactionScopeRepository<T> where T:class
    {
        private TestEntities dbContext = new TestEntities();

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns>IEnumerable<T></returns>
        public Task<IEnumerable<T>> GetAll()
        {
            var tranScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            try
            {
                var obj = dbContext.Set<T>().ToList() as IEnumerable<T>;
                tranScope.Complete();
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
                tranScope.Dispose();
            }
        }
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id">int32</param>
        /// <returns> T </returns>
        public Task<T> GetById(int id)
        {
            var tranScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            try
            {
                var obj = dbContext.Set<T>().Find(id) as T;
                tranScope.Complete();
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
                tranScope.Dispose();
            }
        }
        /// <summary>
        /// Create new data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task Create(T entity)
        {
            var tranScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            try
            {
                dbContext.Set<T>().Add(entity);
                dbContext.SaveChanges();
                tranScope.Complete();
                return Task.FromResult<bool>(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return null;
            }
            finally
            {
                tranScope.Dispose();
            }
        }
        /// <summary>
        /// Update data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task Update(T entity)
        {
            var tranScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            try
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
                tranScope.Complete();
                return Task.FromResult<bool>(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return null;
            }
            finally {
                tranScope.Dispose();
            }
        }
        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task Delete(T entity)
        {
            var tranScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            try
            {
                dbContext.Entry(entity).State = EntityState.Deleted;
                dbContext.SaveChanges();
                tranScope.Complete();
                return Task.FromResult<bool>(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);
                return Task.FromResult<bool>(false);
            }
            finally {
                tranScope.Dispose();
            }
        }
    }
}
