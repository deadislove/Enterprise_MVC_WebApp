using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.State;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.State;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns.BehavioralPatterns.State
{
    public class StateServices<T> : IStateServices<T> where T : class
    {
        private bool disposedValue;
        private object obj;
        private IGenericTypeRepository<T> repo;
        private IState_Context<T> state_Context;

        public StateServices(IGenericTypeRepository<T> _repo)
        {
            repo = _repo;
            DataInitialization();
            ServicesInitialization();
        }

        private void DataInitialization()
        {
            obj = repo.GetAll().Result;
        }

        private void ServicesInitialization()
        {
            state_Context = new State_Context<T>(new ConcreteState<T>());
        }

        public void Execute(out Tuple<IEnumerable<T>, IEnumerable<T>> ReturnObj)
        {
            try
            {
                // First request
                state_Context.Request(obj);
                var FirstResponse = state_Context.Response();
                // Second request
                state_Context.AnotherRequest(obj);
                List<T> SecondResponse = new List<T>();
                foreach (var Item in state_Context.Response())
                {
                    SecondResponse.Add(Item);
                }

                ReturnObj = Tuple.Create(FirstResponse, SecondResponse.AsEnumerable());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }
        #region Dispose pattern
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~StateServices()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
