using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns
{
    public class FlyweightsDto
    {
        public List<Enterprise_MVC_Core> GetList { get; set; } = new List<Enterprise_MVC_Core>();
        public string Result { get; set; } = string.Empty;
    }
}
