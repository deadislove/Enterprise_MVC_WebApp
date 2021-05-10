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
            try
            {
                return builder.GetAll().Result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Combine
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Combine()
        {
            try
            {
                List<T> sourceList = new List<T> { builder.GetById(1).Result as T };
                List<T> targetList = new List<T> { builder.GetById(2).Result as T };
                return builder.Complate(sourceList, targetList).Result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Anti Combine
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> AntiCombine()
        {
            try
            {
                List<T> sourceList = new List<T> { builder.GetById(2).Result as T };
                List<T> targetList = new List<T> { builder.GetById(1).Result as T };
                return builder.Complate(sourceList, targetList).Result;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
