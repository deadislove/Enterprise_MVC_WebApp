using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Composite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Composite
{
    public class CompositeRepo<T> : IComposite<T> where T : class
    {
        private readonly IGenericTypeRepository<T> repo;

        public CompositeRepo(IGenericTypeRepository<T> _repo)
        {
            this.repo = _repo;
        }

        public Task<T> GetById(int? id)
        {
            if (id != 0)
            {
                return Task.Run(() => this.repo.GetById(id.Value));
            }
            else
                throw new NotImplementedException();
        }
    }
}
