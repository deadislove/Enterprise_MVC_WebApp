using System.Collections.Generic;

namespace Enterprise_MVC_WebApplication.Core.Interface
{
    public interface IEnterprise_MVC_CoreRepository
    {
        void Add(Enterprise_MVC_Core o);
        void Edit(Enterprise_MVC_Core o);
        void Remove(int ID);
        IEnumerable<Enterprise_MVC_Core> GetData();
        Enterprise_MVC_Core FindById(int ID);
    }
}
