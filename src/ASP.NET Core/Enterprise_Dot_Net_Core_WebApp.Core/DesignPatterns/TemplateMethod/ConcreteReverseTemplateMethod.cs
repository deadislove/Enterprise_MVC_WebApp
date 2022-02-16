using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.TemplateMethod
{
    public class ConcreteReverseTemplateMethod<T> : TemplateAbstract<T> where T : class
    {
        private IDataExtension _dataExtension;

        public ConcreteReverseTemplateMethod(IGenericTypeRepository<T> repo) : base(repo)
        {
            _dataExtension = new DataExtensionDefault();
        }

        protected override void RequestOperationDefault(object obj)
        {
            _obj = (from source in obj as List<T>
                    select source).ToList();
        }

        protected override void RequestOperationSort(object obj)
        {
            _obj = (from source in obj as List<T>
                    orderby _dataExtension.GetDynamicSortProperty(source, "ID") descending
                    select source).ToList();
        }
    }
}
