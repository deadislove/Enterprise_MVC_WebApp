using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Builder
{
    public class BuilderRepo<T> : IBuilder<T>, IDisposable where T : class
    {
        private readonly IGenericTypeRepository<T> repo;

        public BuilderRepo(IGenericTypeRepository<T> _repo)
        {
            this.repo = _repo;
        }

        public Task<IEnumerable<T>> GetAll()
        {
            try
            {
                return Task.Run(() => repo.GetAll() as IEnumerable<T>);
            }
            catch (Exception ex)
            {
                return Task.FromResult((dynamic)null);
            }
            finally
            {
                Dispose();
            }
        }

        public Task<T> GetById(int id)
        {
            try
            {
                return Task.Run(async () => await repo.GetById(id) as T);
            }
            catch (Exception ex)
            {
                return Task.FromResult((dynamic)null);
            }
            finally
            {
                Dispose();
            }
        }

        public Task<IEnumerable<T>> Complate(List<T> source, List<T> target)
        {
            try
            {
                return Task.Run(() => source.Concat(target) as IEnumerable<T>);
            }
            catch (Exception ex)
            {
                return Task.FromResult((dynamic)null);
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
