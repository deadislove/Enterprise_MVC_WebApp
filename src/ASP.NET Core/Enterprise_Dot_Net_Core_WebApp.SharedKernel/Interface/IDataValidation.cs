using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Enterprise_Dot_Net_Core_WebApp.SharedKernel.Interface
{
    public interface IDataValidation<T> where T : class
    {
        bool Validate(T obj, out ICollection<ValidationResult> results);
    }
}
