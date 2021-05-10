using Enterprise_Dot_Net_Core_WebApp.Core.Interface.DesignPatterns.Composite;
using System;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.Composite
{
    public class CompositeElement<T> : Composite, IDisposable where T : class
    {
        private readonly IComposite<T> repo;

        public CompositeElement(IComposite<T> _repo) {
            this.repo = _repo;
        }

        public override object Operation(int? id)
        {
            return this.repo.GetById(id).Result;
        }

        public override bool IsComposite() => false;

        public new void Dispose() => GC.SuppressFinalize(this);
    }
}
