using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface
{
    public interface IBridge
    {
        Task<object> GetAll();
    }
}
