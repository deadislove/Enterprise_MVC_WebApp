using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.UnitOfWork;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.UnitOfWork
{
    public class UntiOfWorkRepositoryServices<T> : IUntiOfWorkRepository<T> where T : class
    {
        public IGenericTypeRepository<T> _pubRepo;
        
        public UntiOfWorkRepositoryServices(IGenericTypeRepository<T> repo)
        {
            _pubRepo = repo;
        }
    }
}
