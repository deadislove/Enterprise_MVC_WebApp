using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Decorator;
using Enterprise_Dot_Net_Core_WebApp.Core.Entities;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Services.DesignPatterns
{
    public class DecoratorServices
    {
        private IGenericTypeRepository<Enterprise_MVC_Core> _repo;

        public DecoratorServices(IGenericTypeRepository<Enterprise_MVC_Core> Repo)
        {
            this._repo = Repo;
        }

        public async Task<string> Notification(bool bSwitch,int? id, CancellationToken cancellationToken)
        {
            try
            {
                var Sample = new ConcreteComponent<Enterprise_MVC_Core>(_repo);
                var Messages = Sample.ReadJsonData(id.Value);

                ConcreteDecoratorNotification<Enterprise_MVC_Core> _concreteDecoratorNotification = new ConcreteDecoratorNotification<Enterprise_MVC_Core>(Sample);
                var MessageFB = _concreteDecoratorNotification.ReadJsonData(id.Value);

                return await Task.FromResult(MessageFB);
            }
            catch (Exception ex)
            {
                cancellationToken.ThrowIfCancellationRequested();
                return await Task.FromResult(ex.Message);
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
