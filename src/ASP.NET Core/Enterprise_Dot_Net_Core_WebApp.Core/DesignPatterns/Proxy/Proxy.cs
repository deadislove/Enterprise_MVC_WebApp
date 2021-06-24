using Enterprise_Dot_Net_Core_WebApp.Core.DTOs;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Proxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Proxy
{
    public class Proxy<T> : IProxy<T> where T: class
    {
        private IGenericTypeRepository<T> _repo;
        private List<Messages> LogMsgList = new List<Messages>();
        private List<T> CollectionResult = new List<T>();

        public Proxy(IGenericTypeRepository<T> repo)
        {
            this._repo = repo;
        }

        public List<T> Request(Requests requests)
        {
            if (this.CheckAccess(requests))
            {
                LoggingProxy("Checking access prior to firing a request object. ");

                var obj = (dynamic)null;

                if (requests.Id != null || requests.Id != 0)
                {
                    LoggingProxy("Check request.");
                    obj = _repo.GetById(requests.Id.Value).Result;
                    CollectionResult.Add(obj);
                    LoggingProxy("Response object.");
                    return CollectionResult;
                }
                else
                {
                    obj = _repo.GetAll().Result;

                    return obj;
                }
            }
            else
            {
                LoggingProxy("Access Failed");
                return new List<T>();
            }               
        }

        public void LoadLoggingInfo(out List<Messages> returnObj)
        {
            returnObj = LogMsgList;
        }

        private bool CheckAccess(Requests requests)
        {
            if (requests.Username == "local" && requests.Password == "123")
                return true;
            else
                return false;
        }

        private void LoggingProxy(string Msg)
        {
            LogMsgList.Add(new Messages() { Message = Msg });
        }
    }
}
