using Enterprise_Dot_Net_Core_WebApp.SharedKernel.DataValidation;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DTOs
{
    public class RequestObj
    {
        public int ID { get; set; }
        [DataValidation]
        public string Name { get; set; }
    }
}
