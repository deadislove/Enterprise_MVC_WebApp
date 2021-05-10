using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.AbstractFactory;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Infra.Repositories_Patterns.AbstractFactory
{
    public class AbstractFactoryRepo<T> : IAbstractFactory<T>, IDisposable where T : class
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

        /// <summary>
        /// Create a abstract factory A.
        /// </summary>
        /// <returns></returns>
        public IAbstractFactoryA<T> CreateA()
        {
            try
            {
                if (RepoA == null)
                    return new AbstractFactoryA_Repository<T>();
                else
                    return this.RepoA;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        /// <summary>
        /// Create a abstract factory B.
        /// </summary>
        /// <returns></returns>
        public IAbstractFactoryB<T> CreateB()
        {
            try
            {
                if (RepoB == null)
                    return new AbstractFactoryB_Repository<T>();
                else
                    return RepoB;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
