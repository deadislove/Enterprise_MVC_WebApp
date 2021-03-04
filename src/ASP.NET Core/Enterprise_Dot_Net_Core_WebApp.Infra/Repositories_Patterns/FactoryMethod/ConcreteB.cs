using Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.FactoryMethod;
using Enterprise_Dot_Net_Core_WebApp.Core.Interface;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.FactoryMethod
{
    public class ConcreteB<T> : Creator<T> where T : class
    {
        private readonly IFactoryMethod<T> repo;

        public ConcreteB(IFactoryMethod<T> _repo)
        {
            this.repo = _repo;
        }

        public override IFactoryMethod<T> Repo()
        {
            if (repo == null)
                return new FactoryMethodRepoB<T>();
            else
                return this.repo;
        }

        public string From_Info() => "From ConcreteB class.";
        
    }
}
