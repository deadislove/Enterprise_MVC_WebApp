using System;
using System.ComponentModel.DataAnnotations;

namespace Enterprise_Dot_Net_Core_WebApp.SharedKernel.DataValidation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class DataValidationAttribute : ValidationAttribute
    {
        private readonly string _targetName;

        public DataValidationAttribute() : base("{0} value can't empty.")
        {
        }

        public DataValidationAttribute(string targetFieldName)
        {
            _targetName = targetFieldName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessage = ErrorMessageString;
            var sourceType = value.GetType();
            var sourceName = validationContext.MemberName;

            if (sourceType == typeof(IComparable))
            {
                throw new ArgumentException("value has not implemented IComparable interface");
            }

            var sourceValue = (IComparable)value;
            var comparisonPropertyInfo = validationContext.ObjectType.GetProperty(_targetName);
            if (comparisonPropertyInfo == null)
            {
                throw new ArgumentException("Comparison property with this name not found");
            }

            var targetValue = comparisonPropertyInfo.GetValue(validationContext.ObjectInstance);
            var targetType = targetValue.GetType();
            if (targetType == typeof(IComparable))
            {
                throw new ArgumentException("Comparison property has not implemented IComparable interface");
            }

            if (!ReferenceEquals(sourceType, targetType))
            {
                throw new ArgumentException("The properties types must be the same");
            }

            // verify Rule

            if (!string.IsNullOrEmpty(_targetName))
            {
                // When the end date less than the start date, the validation will be failed.
                if (sourceValue.CompareTo((IComparable)targetValue) < 0)
                {
                    ErrorMessage = $"{_targetName} property must be less than the {sourceName} property";
                    return new ValidationResult(ErrorMessage, new[] { _targetName, sourceName });
                }
            }
            else
            {
                // When the object is string type and empty, the validation will be failed.
                string val = (string)value;

                bool valid = string.IsNullOrEmpty(val);

                return new ValidationResult(base.FormatErrorMessage(validationContext.MemberName)
                , new string[] { validationContext.MemberName });
            }

            return ValidationResult.Success;
        }
    }
}
