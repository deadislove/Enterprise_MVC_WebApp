using Enterprise_Dot_Net_Core_WebApp.Core.Interface;
using System.Collections.Generic;
using System.Linq;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface;
using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Repositories;

namespace Enterprise_Dot_Net_Core_WebApp.Core.DesignPatterns.TemplateMethod
{
    public class ConcreteSortTemplateMethod<T> : TemplateAbstract<T> where T : class
    {
        private IDataExtension _dataExtension;

        public ConcreteSortTemplateMethod(IGenericTypeRepository<T> repo) : base(repo)
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
                    orderby _dataExtension.GetDynamicSortProperty(source, "ID") ascending
                    select source).ToList();
        }

        protected override void HookDefault()
        {
            var t = (from source in _obj as List<T>
                     orderby _dataExtension.GetDynamicSortProperty(source, "ID") ascending
                     select source).ToList().FirstOrDefault();
        }
    }
}
