using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Flyweight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Flyweight
{
    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweight = new List<Tuple<Flyweight, string>>();
        IFlyweight<Enterprise_MVC_Core> repo;

        public FlyweightFactory(IFlyweight<Enterprise_MVC_Core> _repo)
        {
            this.repo = _repo;
            DataAccess();
        }

        private void DataAccess()
        {
            var obj = repo.GetList().Result;

            if (obj != null)
            {
                foreach (var item in obj)
                {
                    flyweight.Add(new Tuple<Flyweight, string>(new Flyweight(item), this.GetKey(item)));
                }
            }
        }

        private string GetKey(Enterprise_MVC_Core key)
        {
            List<string> elements = new List<string>
            {
                key.ID.ToString(),
                key.Name
            };

            return string.Join('_', elements);
        }

        public Flyweight GetFlyweight(Enterprise_MVC_Core sharedState)
        {
            string key = this.GetKey(sharedState);
            
            if (flyweight.Where(t => t.Item2 == key).Count() == 0)
                flyweight.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));

            return flyweight.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }

        public IEnumerable<string> ListFlyweights()
        {
            List<string> result = new List<string>();

            foreach (var item in flyweight)
            {
                result.Add(item.Item2);
            }

            return result;
        }

        public void GetCurrentList(out List<Enterprise_MVC_Core> flyweights)
        {
            List<Enterprise_MVC_Core> obj = new List<Enterprise_MVC_Core>();
            foreach (var item in flyweight.Select(t => t.Item1.sharedState))
            {
                obj.Add(item);
            }

            if (obj.Count > 0)
                flyweights = obj;
            else
                flyweights = new List<Enterprise_MVC_Core>();
        }
    }
}
