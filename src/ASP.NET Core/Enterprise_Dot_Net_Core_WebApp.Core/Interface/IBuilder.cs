using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface
{
    public interface IBuilder<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Complate(List<T> t1, List<T> t2);
    }
    
    /*
    public interface IBuilder<T> where T :class
    {
        void BuildPartA();
    }

    public class BuilderRepo<T> : IBuilder<T> where T : class
    {
        private SubRepositroy<T> _product = new SubRepositroy<T>();

        // A fresh builder instance should contain a blank product object, which
        // is used in further assembly.
        public BuilderRepo()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._product = new SubRepositroy<T>();
        }

        public void BuildPartA()
        {
            this._product.Add("PartA1");
        }

        public SubRepositroy<T> GetProduct()
        {
            SubRepositroy<T> result = this._product;

            this.Reset();

            return result;
        }
    }

    public class SubRepositroy<T> where T : class
    {
        private readonly List<T> _parts = new List<T>();

        public void Add(string part)
        {
            this._parts.Add(part as T);
        }

        public string ListParts()
        {
            string str = string.Empty;

            for (int i = 0; i < this._parts.Count; i++)
            {
                str += this._parts[i] + ", ";
            }

            str = str.Remove(str.Length - 2); // removing last ",c"

            return "Product parts: " + str + "\n";
        }
    }


    public class Director<T> where  T : class
    {
        private IBuilder<T> _builder;

        public IBuilder<T> Builder
        {
            set { _builder = value; }
        }

        // The Director can construct several product variations using the same
        // building steps.
        public void BuildMinimalViableProduct()
        {
            this._builder.BuildPartA();
        }

        public void BuildFullFeaturedProduct()
        {
            this._builder.BuildPartA();
        }
    }
    */
}
