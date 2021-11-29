using Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Enterprise_Dot_Net_Core_WebApp.SharedKernel.Repositories
{
    public class DataValidation<T> : IDataValidation<T> where T : class
    {
        public bool Validate(T obj, out ICollection<ValidationResult> results)
        {
            if (obj is null)
                results = null;

            return GenericDataValidation<T>.Validate(obj, out results);
        }
    }

    internal class GenericDataValidation<T> where T : class
    {
        public static bool Validate(T obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }
    }
}
