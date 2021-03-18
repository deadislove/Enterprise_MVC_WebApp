namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface
{
    public interface IPrototype<T> where T : class
    {
        T Prototype_GetById(int id);
    }
}
