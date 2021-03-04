using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Builder
{
    public class BuilderRepo<T> : IBuilder<T> where T : class
    {
        private readonly IGenericTypeRepository<T> repo;

        public BuilderRepo(IGenericTypeRepository<T> _repo)
        {
            this.repo = _repo;
        }

        public Task<IEnumerable<T>> GetAll()
        {
            return Task.Run(() => repo.GetAll() as IEnumerable<T>);
        }

        public Task<T> GetById(int id)
        {
            return Task.Run(async () => await repo.GetById(id) as T);
        }

        public Task<IEnumerable<T>> Complate(List<T> source, List<T> target)
        {
            return Task.Run(() => source.Concat(target) as IEnumerable<T>);
        }
    }
}
