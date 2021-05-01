using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.AbstractFactory;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.AbstractFactory
{
    public class AbstractFactoryRepo<T> : IAbstractFactory<T> where T : class
    {
        private readonly IAbstractFactoryA<T> RepoA;
        private readonly IAbstractFactoryB<T> RepoB;

        public AbstractFactoryRepo(
            IAbstractFactoryA<T> _RepoA,
            IAbstractFactoryB<T> _RepoB)
        {
            this.RepoA = _RepoA;
            this.RepoB = _RepoB;
        }

        public IAbstractFactoryA<T> CreateA()
        {
            if (RepoA == null)
                return new AbstractFactoryA_Repository<T>();
            else
                return this.RepoA;
        }

        public IAbstractFactoryB<T> CreateB()
        {
            if (RepoA == null)
                return new AbstractFactoryB_Repository<T>();
            else
                return RepoB;
        }
    }
}
