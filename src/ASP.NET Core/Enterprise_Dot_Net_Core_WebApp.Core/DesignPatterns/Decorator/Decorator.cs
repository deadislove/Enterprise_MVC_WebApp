using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Decorator
{
    public class Decorator<T> : Component<T> where T : class
    {
        protected Component<T> _component;

        public Decorator(Component<T> Component) => this._component = Component;

        public void SetComponent(Component<T> Component) => this._component = Component;

        public override string ReadJsonData(int? id)
        {
            try
            {
                if (_component != null && id != null)
                    return _component.ReadJsonData(id.Value);
                else
                    return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            finally
            {
                Dispose();
            }
        }

        public void Dispose() => GC.SuppressFinalize(this);
    }
}
