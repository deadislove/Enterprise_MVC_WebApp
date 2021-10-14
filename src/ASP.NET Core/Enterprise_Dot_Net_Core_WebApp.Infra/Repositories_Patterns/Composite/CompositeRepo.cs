using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Composite;
using System;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Composite
{
    public class CompositeRepo<T> : IComposite<T>, IDisposable where T : class
    {
        private readonly IGenericTypeRepository<T> repo;

        public CompositeRepo(IGenericTypeRepository<T> _repo)
        {
            this.repo = _repo;
        }

        public Task<T> GetById(int? id)
        {
            try
            {
                if (id != 0)
                {
                    return Task.Run(() => this.repo.GetById(id.Value));
                }
                else
                    throw new NotImplementedException();
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
