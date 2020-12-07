using System;
using System.Collections.Generic;
using System.Text;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface
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
