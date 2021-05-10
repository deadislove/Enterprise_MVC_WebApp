using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Adapter;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.Adapter
{
    public class AdapterRepo_Obj<T> : IAdapter_Obj<T>, IDisposable where T : class
    {
        private readonly Adaptee_Obj<T> adaptee;
        private readonly IGenericTypeRepository<T> repo;

        public AdapterRepo_Obj(IGenericTypeRepository<T> _repo)
        {
            this.adaptee = new Adaptee_Obj<T>();
            this.repo = _repo;
        }

        public IEnumerable<T> GetRequest()
        {
            try
            {
                List<T> obj = repo.GetAll().Result as List<T>;

                if (obj.Count != 0)
                    return this.adaptee.CopyToObject(obj);
                else
                    return new List<T>();
            }
            catch (Exception e)
            {
                return new List<T>();
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
