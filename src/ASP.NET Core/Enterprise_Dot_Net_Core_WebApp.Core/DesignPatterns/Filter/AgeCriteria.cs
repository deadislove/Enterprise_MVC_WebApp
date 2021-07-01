using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Filter;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Filter
{
    public class AgeCriteria<T> : IFilter<T> where T : class
    {
        public List<T> MeetCriteria(List<T> obj, dynamic Target = null)
        {
            return obj.Where(i => i.GetType().GetProperty("ID").GetValue(i, null).Equals(Target)).ToList();
        }
    }
}
