using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Builder;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Builder
{
    public class Director<T> : IDisposable where T : class
    {
        private readonly IBuilder<T> builder;

        public Director(IBuilder<T> _builder)
        {
            this.builder = _builder;
        }

        public IEnumerable<T> DefaultResult()
        {
            return builder.GetAll().Result;
        }

        public IEnumerable<T> Combine()
        {
            List<T> sourceList = new List<T> { builder.GetById(1).Result as T };
            List<T> targetList = new List<T> { builder.GetById(2).Result as T };
            return builder.Complate(sourceList, targetList).Result;
        }

        public IEnumerable<T> AntiCombine()
        {
            List<T> sourceList = new List<T> { builder.GetById(2).Result as T };
            List<T> targetList = new List<T> { builder.GetById(1).Result as T };
            return builder.Complate(sourceList, targetList).Result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
