using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.FactoryMethod;
using System;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.FactoryMethod
{
    public class FactoryMethodRepoB<T> : IFactoryMethod<T>, IDisposable where T : class
    {
        private readonly IGenericTypeRepository<T> repo;

        public FactoryMethodRepoB(IGenericTypeRepository<T> _repo)
        {
            this.repo = _repo;
        }

        public FactoryMethodRepoB()
        { }

        public Task<T> GetById(int? id)
        {
            return id.Value != 0 ? Task.Run(async () => await repo.GetById(id.Value) as T) : null;
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
