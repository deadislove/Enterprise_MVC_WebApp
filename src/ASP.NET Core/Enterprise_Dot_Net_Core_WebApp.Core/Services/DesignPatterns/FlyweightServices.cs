using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Flyweight;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Flyweight;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns
{
    public class FlyweightServices
    {
        private readonly IFlyweight<Enterprise_MVC_Core> repo;

        private FlyweightFactory flyweightFactory;

        public FlyweightServices(IFlyweight<Enterprise_MVC_Core> _repo)
        {
            this.repo = _repo;
            flyweightFactory = new FlyweightFactory(repo);
        }

        public void GetFactory(out FlyweightFactory ReturnObj)
        {
            ReturnObj = this.flyweightFactory;
        }

        public void GetKey(out List<string> Result)
        {
            Result = flyweightFactory.ListFlyweights().ToList();
        }

        public void AddElement(FlyweightFactory _flyweightFactory, Enterprise_MVC_Core elements, out string AddResult)
        {
            var flyweight = _flyweightFactory.GetFlyweight(new Enterprise_MVC_Core
            {
                ID = elements.ID,
                Name = elements.Name,
                Age = elements.Age
            });

            flyweight.Operation(elements, out AddResult);
        }

        public void Result(string InputResult, out List<FlyweightsDto> obj, ref List<FlyweightsDto> refObj)
        {
            flyweightFactory.GetCurrentList(out List<Enterprise_MVC_Core> list);
            if (refObj.Count() == 0)
            {
                obj = new List<FlyweightsDto>
                {
                    new FlyweightsDto{
                        Result = InputResult,
                        GetList = list
                    }
                };
            }
            else
            {
                obj = refObj;
                obj.Add(new FlyweightsDto
                {
                    Result = InputResult,
                    GetList = list
                });
            }
        }

        public void Result(string InputResult, out List<FlyweightsDto> obj)
        {
            flyweightFactory.GetCurrentList(out List<Enterprise_MVC_Core> list);

            obj = new List<FlyweightsDto>
            {
                new FlyweightsDto
                {
                    Result = InputResult,
                    GetList = list
                }
            };
                
        }
    }
}
