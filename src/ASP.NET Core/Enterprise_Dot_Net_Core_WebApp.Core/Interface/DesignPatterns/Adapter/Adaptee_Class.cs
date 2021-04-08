using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Adapter
{
    public class Adaptee_Class<T> where T : class
    {
        public IEnumerable<T> CopyToObject(List<T> obj)
        {
            List<T> result = new List<T>();
            result.AddRange(obj);
            result.AddRange(obj);

            return result.ToList();
        }
    }
}
