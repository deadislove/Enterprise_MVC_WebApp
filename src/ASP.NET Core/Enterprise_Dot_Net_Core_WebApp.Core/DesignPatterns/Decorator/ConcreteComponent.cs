using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Newtonsoft.Json;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Decorator
{
    public class ConcreteComponent<T> : Component<T>, IDisposable where T : class
    {
        protected IGenericTypeRepository<T> _igenericTypeRepository;

        public ConcreteComponent(IGenericTypeRepository<T> GenericTypeRepository)
        {
            this._igenericTypeRepository = GenericTypeRepository;
        }

        public override string ReadJsonData(int? id)
        {
            try
            {
                if (_igenericTypeRepository != null && id != null)
                    return JsonConvert.SerializeObject(_igenericTypeRepository.GetById(id.Value).Result);
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                return $"Concretecomponent -err: {ex.Message}";
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
