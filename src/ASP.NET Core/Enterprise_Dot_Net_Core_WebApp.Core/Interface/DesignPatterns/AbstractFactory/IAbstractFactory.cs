
namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.AbstractFactory
{
    public interface IAbstractFactory<T> where T : class
    {
        IAbstractFactoryA<T> CreateA();
        IAbstractFactoryB<T> CreateB();
    }

    //public interface IAbstractFactory<T> where T : class
    //{
    //    IAbstractFactoryRepositoryA<T> CreateA(T entity);

    //    IAbstractFactoryRepositoryB<T> CreateB(T entity);
    //}

    // Create Repository class in the Core project. New folder Name = "Patterns_Repo"
    //class Repository<T> : IAbstractFactory<T> where T : class
    //{
    //    public IAbstractFactoryRepositoryA<T> CreateA(T entity)
    //    {
    //        return new AbstractFactoryRepositoryA<T>();
    //    }

    //    public IAbstractFactoryRepositoryB<T> CreateB(T entity)
    //    {
    //        return new AbstractFactoryRepositoryB<T>();
    //    }
    //}

    //Create Interface class files in the Core proejct. New folder Name = "Patterns_Interface"
    //public interface IAbstractFactoryRepositoryA<T> where T:class
    //{
    //    bool Create(T entity);
    //}

    //public interface IAbstractFactoryRepositoryB<T> where T : class
    //{
    //    bool Create(T entity);
    //}

    // Create repository class files in the Infra project. New folder name = "Pattern_Repositories"
    //class AbstractFactoryRepositoryA<T> : IAbstractFactoryRepositoryA<T> where T : class
    //{

    //    public bool Create(T entity) => true;
    //}

    //class AbstractFactoryRepositoryB<T> : IAbstractFactoryRepositoryB<T> where T : class
    //{
    //    public bool Create(T entity) => true;
    //}
}
