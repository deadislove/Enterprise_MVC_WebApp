using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Composite
{
    public interface IComposite<T> where T :  class
    {
        Task<T> GetById(int? id);
    }
}
