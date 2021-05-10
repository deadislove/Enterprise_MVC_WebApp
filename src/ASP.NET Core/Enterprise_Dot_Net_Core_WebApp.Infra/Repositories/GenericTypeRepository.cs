using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Infra.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories
{
    public class GenericTypeRepository<T> : IGenericTypeRepository<T>, IDisposable where T:class
    {
        private readonly DemoDbContext dbContext;

        /// <summary>
        /// Default
        /// </summary>
        /// <param name="_dbContext">DBcontext</param>
        public GenericTypeRepository(DemoDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }


        /// <summary>
        /// Get All information.
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return Task.Run(() => dbContext.Set<T>().ToList() as IEnumerable<T>);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Async Get All information.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<T>> AsyncGetAll()
        {
            try
            {
                return await Task.Run(() => dbContext.Set<T>().ToList() as IEnumerable<T>);
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Find data by where conitions.
        /// </summary>
        /// <param name="predicate">Where conditions</param>
        /// <returns>T</returns>
        public Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return Task.Run(() => dbContext.Set<T>().Where(predicate).FirstOrDefault());
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Async Find data by where conitions.
        /// </summary>
        /// <param name="predicate">Where conditions</param>
        /// <returns>T</returns>
        public async Task<T> AsyncFind(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await Task.Run(() => dbContext.Set<T>().Where(predicate).FirstOrDefault());
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Get by ID
        /// </summary>
        /// <param name="id">int32</param>
        /// <returns> T </returns>
        public Task<T> GetById(int id)
        {
            try
            {
                if (id != 0)
                {
                    return Task.Run(() => dbContext.Set<T>().Find(id) as T);
                }
                else
                    throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Async Get By ID.
        /// </summary>
        /// <param name="id">int32</param>
        /// <returns> T </returns>
        public async Task<T> AsyncGetById(int id)
        {
            try
            {
                if (id != 0)
                    return await Task.Run(() => dbContext.Set<T>().Find(id) as T);
                else
                    throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Create new data.
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task Create(T entity)
        {
            try
            {
                dbContext.Set<T>().Add(entity);
                return Task.Run(() => dbContext.SaveChanges());
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Async Create new data.
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public async Task AsyncCreate(T entity)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;
            try
            {                
                await Task.Run(() => dbContext.Set<T>().AddAsync(entity: entity, cancellationToken: token));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                await dbContext.SaveChangesAsync();
                source.Dispose();
                Dispose();
            }
        }

        /// <summary>
        /// Update data.
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task Update(T entity)
        {
            try
            {
                dbContext.Entry<T>(entity).State = EntityState.Modified;
                //dbContext.SaveChanges();
                SaveChange();
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Async Update data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task AsyncUpdate(T entity)
        {
            try
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                dbContext.SaveChangesAsync();
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Delete data
        /// </summary>
        /// <param name="entity">entity model class</param>
        /// <returns></returns>
        public Task Delete(T entity)
        {
            try
            {
                dbContext.Entry<T>(entity).State = EntityState.Deleted;
                return Task.Run(() => dbContext.SaveChanges());
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Async Delete data
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AsyncDelete(T entity)
        {
            try
            {
                dbContext.Entry<T>(entity).State = EntityState.Deleted;
                await Task.Run(() => dbContext.SaveChangesAsync());
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Row count
        /// </summary>
        /// <param name="predicate">Where conditions</param>
        /// <returns>int32</returns>
        public Task<int> RowCount(Func<T, bool> predicate)
        {
            try
            {
                return Task.Run(() => dbContext.Set<T>().Where(predicate).Count());
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Async Row count
        /// </summary>
        /// <param name="predicate">Where conditions</param>
        /// <returns>int32</returns>
        public async Task<int> AsyncRowCount(Func<T, bool> predicate)
        {
            try
            {
                return await Task.Run(() => dbContext.Set<T>().Where(predicate).Count());
            }
            catch (Exception ex)
            {
                return await Task.FromResult((dynamic)null);
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Save Change
        /// </summary>
        /// <returns></returns>
        public Task SaveChange()
        {
            try
            {
                dbContext.SaveChanges();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.CompletedTask;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Async Save Change
        /// </summary>
        /// <returns></returns>
        public Task SaveChangeAsync()
        {
            try
            {
                dbContext.SaveChangesAsync();
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                return Task.CompletedTask;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
