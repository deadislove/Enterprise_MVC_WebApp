using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.NullObject;
using Enterprise_Dot_Net_Core_WebApp.Core.DTOs.DesginPatterns.NullObject;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.NullObject;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.NullObject
{
    public class NullObjServices : INullObject
    {
        public NullObjServices() { }

        public Tuple<IEnumerable<string>> Operation()
        {
            Tuple<IEnumerable<string>> ResutTuple;
            List<string> Item = new List<string>();

            NullObjectDto nullObjectDto = new NullObjectDto();
            EntityDto entityDto = new EntityDto();

            // Record method 1 result
            Item.Add(JsonConvert.SerializeObject(entityDto, Formatting.Indented));
            // Record method 2 result
            entityDto = nullObjectDto.entityDto ?? new IsNullEntityDto();
            Item.Add(JsonConvert.SerializeObject(entityDto, Formatting.Indented));
            // Record method 3 result
            entityDto = nullObjectDto.entityDto ?? new IsNullObject<EntityDto>(new object[] { 1, "Default value by method 2", 1 }).Instance;
            Item.Add(JsonConvert.SerializeObject(entityDto, Formatting.Indented));

            ResutTuple = Tuple.Create(Item as IEnumerable<string>);
            return ResutTuple;
        }
    }
}
