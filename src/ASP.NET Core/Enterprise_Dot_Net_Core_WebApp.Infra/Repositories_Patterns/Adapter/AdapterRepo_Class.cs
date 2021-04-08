using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Adapter;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Adapter
{
    public class AdapterRepo_Class<T> : Adaptee_Class<T> ,IAdapter_Class<T> where T : class
    {        
        private readonly IGenericTypeRepository<T> repo;

        public AdapterRepo_Class(IGenericTypeRepository<T> _repo)
        {            
            this.repo = _repo;
        }

        public IEnumerable<T> GetRequest(Adaptee_Class<T> adaptee_Class)
        {
            try
            {
                List<T> obj = repo.GetAll().Result as List<T>;

                if (obj.Count != 0)
                    return CopyToObject(obj);
                else
                    return new List<T>();
            }
            catch (Exception e)
            {
                return new List<T>();
            }
        }
    }
}
