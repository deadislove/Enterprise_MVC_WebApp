using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns
{
    public class PrivateDataClassServices
    {
        IGenericTypeRepository<Enterprise_MVC_Core> repo;
        private PrivateDataClass privateDataClass;

        public PrivateDataClassServices(IGenericTypeRepository<Enterprise_MVC_Core> _repo)
        {
            repo = _repo;
        }

        public PrivateDataClass GetById(int id)
        {
            var obj = repo.GetById(id).Result;
            privateDataClass = new PrivateDataClass(obj.ID, obj.Name, obj.Age.Value);
            return privateDataClass;
        }
    }
}
