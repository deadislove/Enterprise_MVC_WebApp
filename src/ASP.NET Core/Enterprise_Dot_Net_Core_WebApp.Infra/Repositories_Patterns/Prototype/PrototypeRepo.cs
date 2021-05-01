using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Prototype;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Prototype
{
    public class PrototypeRepo<T> : IPrototype<T> where T : class
    {
        private IGenericTypeRepository<T> repo;
        

        public PrototypeRepo(IGenericTypeRepository<T> _repo)
        {
            this.repo = _repo;
        }

        public T Prototype_GetById(int id) => repo.GetById(id).Result as T;             
    }    
}
