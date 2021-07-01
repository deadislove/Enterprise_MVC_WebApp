using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Filter
{
    public interface IFilter<T> where T : class
    {
        List<T> MeetCriteria(List<T> obj, dynamic Target = (dynamic)null);
    }
}
