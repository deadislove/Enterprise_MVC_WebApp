﻿using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Facade;
using System;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Facade
{
    public class FacadeSubsystem1<T> : IDisposable where T : class
    {
        protected IFacade<T> repo;

        private string DefaultString { get; } = $"Facade subsystem 1 initiation";
        private int? ObjId { get; } = 1;

        public FacadeSubsystem1(IFacade<T> _repo)
        {
            this.repo = _repo;
        }

        public async Task<T> Operation(int? id)
        {
            try
            {
                id = id ?? ObjId;
                return await repo.GetById(id.Value);
            }
            catch (Exception ex)
            {
                return Task.FromResult((dynamic)null);
            }
            finally
            {
                Dispose(true);
            }
        }

        public Task<string> OperationInitiation() => Task.FromResult(DefaultString);

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~FacadeSubsystem1()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
