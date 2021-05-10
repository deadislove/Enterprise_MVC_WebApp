using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Composite
{
    public class Composite : Component, IDisposable
    {

        protected List<object> children = new List<object>();

        public override void Add(object obj)
        {
            this.children.Add(obj);
        }

        public override void Remove(object obj)
        {
            this.children.Remove(obj);
        }

        public override object Operation(int? id) 
        {
            List<object> Result = new List<object>();

            foreach (object objItem in this.children)
            {
                Result.Add(objItem);
            }

            return Result;
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
