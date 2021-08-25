using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Filter;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns
{
    public class FilterServices<T> where T :class
    {
        private IGenericTypeRepository<T> Repo;
        private NameCriteria<T> _nameCriteria;
        private AgeCriteria<T> _ageCriteria;
        private List<Messages> RecordMsg;

        public FilterServices(IGenericTypeRepository<T> _repo)
        {
            _nameCriteria = new NameCriteria<T>();
            _ageCriteria = new AgeCriteria<T>();
            RecordMsg = new List<Messages>();
            Repo = _repo;
        }

        public void Initialization(out List<T> returnObj, dynamic Target = (dynamic)null)
        {
            if (Target is null)
                returnObj = Repo.GetAll().Result as List<T>;
            else
            {
                List<T> obj = new List<T>
                {
                    Repo.GetById(Target)
                };

                returnObj = obj;
            }
        }

        public List<T> ObjectFilterForName(List<T> obj, dynamic Target = (dynamic)null)
            => _nameCriteria.MeetCriteria(obj, Target);

        public List<T> ObjectFilterForAge(List<T> obj, dynamic Target = (dynamic)null)
            => _ageCriteria.MeetCriteria(obj, Target);

        public void RecordMessages(string Msg)
        {
            if (!string.IsNullOrEmpty(Msg))
                RecordMsg.Add(
                    new Messages() {
                        Message = Msg
                    });
        }

        public List<Messages> LoadMessages()
            => RecordMsg;
    }
}
