using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntiLedTask.ViewModels
{
    /// <summary>
    /// Валидация строки на содержание пробелов.
    /// </summary>
    public sealed class SpaceStringValidator : ValidationAttribute
    {
        #region consts
        private const string defaultErrorMessage = "Строка содержит пробелы.";
        #endregion

        #region .ctor
        public SpaceStringValidator() : base(defaultErrorMessage) { }
        public SpaceStringValidator(string errorMessage) : base(errorMessage) { }
        public SpaceStringValidator(Func<string> errorMessageAccessor) : base(errorMessageAccessor) { }
        #endregion

        #region IsValid
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string _str && _str != null)
            {
                if (_str.Contains(" ") == false)
                    return ValidationResult.Success;
            }
            return new(ErrorMessage);
        }
        #endregion
    }
}
