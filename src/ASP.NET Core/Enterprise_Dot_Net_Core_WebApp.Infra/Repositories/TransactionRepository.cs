using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories
{
    public class TransactionRepository<T> : ITransactionRepository<T> where T : class
    {
        private readonly DemoDbContext dbContext;

        #region Default
        /// <summary>
        /// Default
        /// </summary>
        /// <param name="_dbContext"></param>
        public TransactionRepository(DemoDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }
        #endregion

        #region GetAll
        /// <summary>
        /// Get All
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

                try
                {
                    tran.Rollback();
                }
                catch (Exception e2)
                {
                    Debug.WriteLine("Commit Exception Type: {0}", e2.GetType());
                    Debug.WriteLine("Message: {0}", e2.Message);
                }
            }
            finally
            {
                tran.Dispose();
            }
            return null;
        }
        #endregion

        #region Get by ID
        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id">int32</param>
        /// <returns> T </returns>
        public Task<T> GetById(int id)
        {
            if (id != 0)
            {
                var tran = dbContext.Database.BeginTransaction();

                try
                {
                    var obj = dbContext.Set<T>().Find(id) as T;
                    tran.Commit();

                    return Task.Run(() => obj);
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                    Debug.WriteLine("Message: {0}", e.Message);

                    try
                    {
                        tran.Rollback();
                    }
                    catch (Exception e2)
                    {
                        Debug.WriteLine("Commit Exception Type: {0}", e2.GetType());
                        Debug.WriteLine("Message: {0}", e2.Message);
                    }

                    return null;
                }
                finally
                {
                    tran.Dispose();
                }
            }
            return null;
        }
        #endregion

        #region Create
        /// <summary>
        /// Create data information
        /// </summary>
        /// <param name="entity"></param>
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

                try
                {
                    tran.Rollback();
                }
                catch (Exception e2)
                {
                    Debug.WriteLine("Commit Exception Type: {0}", e2.GetType());
                    Debug.WriteLine("Message: {0}", e2.Message);
                }

                return Task.FromResult<bool>(false);
            }
            finally
            {                
                tran.Dispose();                
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Update data information
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public Task Update(T entity)
        {
            var tran = dbContext.Database.BeginTransaction();

            try
            {
                dbContext.Entry<T>(entity).State = EntityState.Modified;
                dbContext.SaveChanges();
                tran.Commit();
                return Task.FromResult<bool>(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);

                try
                {
                    tran.Rollback();
                }
                catch (Exception e2)
                {
                    Debug.WriteLine("Commit Exception Type: {0}", e2.GetType());
                    Debug.WriteLine("Message: {0}", e2.Message);
                }

                return Task.FromResult<bool>(false);
            }
            finally
            {
                tran.Dispose();                
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
            var tran = dbContext.Database.BeginTransaction();

            try
            {
                dbContext.Entry<T>(entity).State = EntityState.Deleted;
                dbContext.SaveChanges();
                tran.Commit();
                return Task.FromResult<bool>(true);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Commit Exception Type: {0}", e.GetType());
                Debug.WriteLine("Message: {0}", e.Message);

                try
                {
                    tran.Rollback();
                }
                catch (Exception e2)
                {
                    Debug.WriteLine("Commit Exception Type: {0}", e2.GetType());
                    Debug.WriteLine("Message: {0}", e2.Message);
                }

                return Task.FromResult<bool>(false);
            }
            finally
            {
                tran.Dispose();                
            }
        }
        #endregion
    }
}
