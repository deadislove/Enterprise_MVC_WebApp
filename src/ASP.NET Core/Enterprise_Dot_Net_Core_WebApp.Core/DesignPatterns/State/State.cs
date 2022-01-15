namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.State
{
    public abstract class State<T> where T :class
    {
        protected State_Context<T> _context;

        public void SetContext(State_Context<T> context) => _context = context;

        public abstract void Handle(object obj);

        public abstract void AnotherHandle(object obj);
    }
}
