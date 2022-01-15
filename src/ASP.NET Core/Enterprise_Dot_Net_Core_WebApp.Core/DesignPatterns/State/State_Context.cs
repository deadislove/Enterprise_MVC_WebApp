using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.BehavioralPatterns.State;
using System;
using System.Collections.Generic;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.State
{
    public class State_Context<T> : IState_Context<T> where T : class
    {
        private bool disposedValue;

        private State<T> _state = null;

        public IEnumerable<T> Result { get; set; }

        public State_Context(State<T> state) => TransitionTo(state);

        public void Request(Object obj)
        {
            _state.Handle(obj);
        }

        public void AnotherRequest(object obj = null)
        {
            if (obj is null)
                return;

            _state.AnotherHandle(obj);
        }

        public IEnumerable<T> Response()
        {
            return Result;
        }

        public void TransitionTo(State<T> state)
        {
            _state = state;
            _state.SetContext(this);
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
        // ~State_Context()
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
