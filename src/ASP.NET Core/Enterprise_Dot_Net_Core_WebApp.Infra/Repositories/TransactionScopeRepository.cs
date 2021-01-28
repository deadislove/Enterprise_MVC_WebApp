using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories
{
    public class TransactionScopeRepository<T> : ITransactionScopeRepository<T> where T : class
    {
        private readonly DemoDbContext dbContext;

        #region Default
        /// <summary>
        /// Default
        /// </summary>
        /// <param name="_dbContext"></param>
        public TransactionScopeRepository(DemoDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Get All information.
        /// </summary>
        /// <returns></returns>
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
            }
            finally
            {
                tranScope.Dispose();
            }
            return null;
        }
        #endregion

        #region Get by ID
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id">int32</param>
        /// <returns></returns>
        public Task<T> GetById(int id)
        {
            if (id != 0)
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
                finally {
                    tranScope.Dispose();
                }
            }

            return null;
        }
        #endregion

        #region Create
        /// <summary>
        /// Create data  information.
        /// </summary>
        /// <param name="entity"></param>
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
                return Task.FromResult<bool>(false);
            }
            finally
            {
                tranScope.Dispose();
            }            
        }
        #endregion

        #region Update
        /// <summary>
        /// Update data information.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Update(T entity)
        {
            var tranScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            try
            {
                dbContext.Entry<T>(entity).State = EntityState.Modified;
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
            finally
            {
                tranScope.Dispose();                
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete data information
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Delete(T entity)
        {
            var tranScope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });

            try
            {
                dbContext.Entry<T>(entity).State = EntityState.Deleted;
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
            finally
            {
                tranScope.Dispose();                
            }
        }
        #endregion
    }
}
