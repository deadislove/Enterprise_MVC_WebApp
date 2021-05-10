using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Decorator
{
    public class ConcreteDecoratorNotification<T> : Decorator<T>, IDisposable where T : class, new()
    {
        public ConcreteDecoratorNotification(Component<T> comp) : base(comp)
        { }

        public override string ReadJsonData(int? id)
        {
            SendMessageToFB(base.ReadJsonData(id.Value));
            SendMessageToLine(base.ReadJsonData(id.Value));
            // Add other behavior.
        
            return base.ReadJsonData(id);
        }

        /// <summary>
        /// Send messages to FB.
        /// </summary>
        /// <param name="Messages">String</param>
        /// <returns></returns>
        private static bool SendMessageToFB(string Messages)
        {
            try
            {
                if (!string.IsNullOrEmpty(Messages))
                {
                    // Execute the Facebook API post
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Send messages to Line.
        /// </summary>
        /// <param name="Messages">String</param>
        /// <returns></returns>
        private static bool SendMessageToLine(string Messages)
        {
            if (!string.IsNullOrEmpty(Messages))
            {
                // Execute the Line API Post
                return true;
            }
            else
                return false;
        }

        public new void Dispose() => GC.SuppressFinalize(this);
    }
}
