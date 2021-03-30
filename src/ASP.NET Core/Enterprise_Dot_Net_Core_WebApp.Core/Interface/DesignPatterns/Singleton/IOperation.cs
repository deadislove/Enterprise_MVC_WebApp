namespace Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Singleton
{
    public interface IOperation
    {
        string OperationId { get; }
    }

    public interface IOperationTransient : IOperation
    {
        new string OperationId();
    }
    public interface IOperationScoped : IOperation
    {
        new string OperationId();
    }
    public interface IOperationSingleton : IOperation
    {
        new string OperationId();
    }
}
