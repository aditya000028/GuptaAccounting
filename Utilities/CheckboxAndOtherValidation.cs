using GuptaAccounting.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuptaAccounting.Utilities
{
    public class CheckboxAndOtherValidation : ValidationAttribute
    {
        readonly object TRUE = true;
        string[] _alltheOtherProperty;

        public CheckboxAndOtherValidation(params string[] alltheOthersProperty)
        {
            _alltheOtherProperty = alltheOthersProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var errorMessage = FormatErrorMessage((validationContext.DisplayName));

            bool IsOtherNull = false;
            bool IsAnyCheckboxChecked = false;

            if (_alltheOtherProperty?.Count() > 0 != true)
            {
                return new ValidationResult(errorMessage);
            }

            var otherPropertyInfo = validationContext.ObjectType.GetProperty(nameof(Client.Other));
            if (otherPropertyInfo != null)
            {
                object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                if (otherPropertyValue == null || string.IsNullOrEmpty(otherPropertyValue.ToString()))
                {
                    IsOtherNull = true;
                }
            }

            for (var i = 0; i < _alltheOtherProperty.Length; ++i)
            {
                var prop = _alltheOtherProperty[i];
                var propertyInfo = validationContext.ObjectType.GetProperty(prop);
                if (propertyInfo == null)
                {
                    continue;
                }

                object propertyValue = propertyInfo.GetValue(validationContext.ObjectInstance, null);
                if (Equals(TRUE, propertyValue))
                {
                    IsAnyCheckboxChecked = true;
                }
            }

            if (IsOtherNull && !IsAnyCheckboxChecked)
                return new ValidationResult(errorMessage);
            else
                return ValidationResult.Success;

        }
    }
}
