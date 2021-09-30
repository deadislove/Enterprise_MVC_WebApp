using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.FactoryMethod;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.FactoryMethod;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.FactoryMethod
{
    public class ConcreteA<T> : Creator<T>, IDisposable where T : class
    {
        private readonly IFactoryMethod<T> repo;

        public ConcreteA(IFactoryMethod<T> _repo)
        {
            this.repo = _repo;
        }

        public override IFactoryMethod<T> Repo()
        {
            try
            {
                if (repo == null)
                    return new FactoryMethodRepoA<T>();
                else
                    return this.repo;
            }
            catch (Exception ex)
            {
                return new FactoryMethodRepoA<T>();
            }
            finally
            {
                Dispose();
            }
        }

        public string From_Info() => "From ConcreteA class.";

        public new void Dispose() => GC.SuppressFinalize(this);
    }
}
