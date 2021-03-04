using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.FactoryMethod
{
    public abstract class Creator<T> where T : class
    {
        public abstract IFactoryMethod<T> Repo();

        public Task<T> GetByID_Creator(int id)
        {
            var obj = Repo();
            return Task.Run(() => obj.GetById(id).Result as T);
        }
    }

    //class Client
    //{
    //    private IFactoryMethod<string> repo;

    //    public Client(IFactoryMethod<string> _repo)
    //    {
    //        this.repo = _repo;
    //    }
    //    public void Main()
    //    {
    //        var o = new ConcreteCreatorA<string>(repo);
    //        Console.WriteLine(o.SomeOperation());
    //    }
    //}


    //public abstract class Creator<T> where T : class
    //{
    //    public abstract IFactoryMethod<T> FactoryMethod();

    //    public string SomeOperation()
    //    {
    //        var product = FactoryMethod();
    //        var result = "Creator: The same creator's code has just worked with "
    //            + product.Operation();

    //        return result;
    //    }
    //}

    //class ConcreteCreatorA<T> : Creator<T> where T : class
    //{
    //    private IFactoryMethod<T> repo;
    //    public ConcreteCreatorA(IFactoryMethod<T> _repo)
    //    {
    //        this.repo = _repo;
    //    }


    //    public override IFactoryMethod<T> FactoryMethod()
    //    {
    //        if (repo == null)
    //            return new FactoryMethodA<T>();
    //        else
    //            return this.repo;
    //    }
    //}

    //class ConcreteCreatorB<T> : Creator<T> where T : class
    //{
    //    public override IFactoryMethod<T> FactoryMethod()
    //    {
    //        return new FactoryMethodB<T>();
    //    }
    //}

    //public interface IFactoryMethod<T> where T : class
    //{
    //    string Operation();
    //}

    //public class FactoryMethodA<T> : IFactoryMethod<T> where T : class
    //{
    //    private string str;

    //    public FactoryMethodA(string _str)
    //    {
    //        this.str = _str;
    //    }

    //    public FactoryMethodA()
    //    { }

    //    public string Operation()
    //    {
    //        return "{Result of ConcreteProduct1}";
    //    }
    //}

    //class FactoryMethodB<T> : IFactoryMethod<T> where T : class
    //{
    //    public string Operation()
    //    {
    //        return "{Result of ConcreteProduct2}";
    //    }
    //}
}
