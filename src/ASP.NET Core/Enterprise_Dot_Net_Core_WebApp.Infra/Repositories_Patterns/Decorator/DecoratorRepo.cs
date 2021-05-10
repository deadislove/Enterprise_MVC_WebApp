using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Decorator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Decorator
{
    public class DecoratorRepo<T> : IDecorator<T>, IDisposable where T : class
    {
        private IGenericTypeRepository<T> _igenericTypeRepository;

        public DecoratorRepo(IGenericTypeRepository<T> GenericTypeRepository)
        {
            this._igenericTypeRepository = GenericTypeRepository;
        }

        public Task<T> GetById(int? id)
        {
            try
            {
                return _igenericTypeRepository.GetById(id.Value);
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
