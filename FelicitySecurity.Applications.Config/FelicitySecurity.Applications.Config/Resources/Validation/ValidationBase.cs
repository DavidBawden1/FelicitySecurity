using FelicitySecurity.Applications.Config.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FelicitySecurity.Applications.Config.Resources.Validation
{
    /// <summary>
    /// Applies a validation rule to all form control properties. Assures they cannot be empty or null.
    /// </summary>
    public class ValidationBase : IValidation
    {
        /// <summary>
        /// Returns a message for incorrect input
        /// </summary>
        public string ErrorMessage { get { return "You must supply a value!"; } }

        /// <summary>
        /// if true property is valid, false return error message
        /// </summary>
        public bool IsValid { get; }
        
        /// <summary>
        /// Validate the given email address. 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public virtual bool IsValidEmail(string email)
        {
            if (String.IsNullOrEmpty(email))
            {
                return false;
            }
            else
            {
                return Regex.IsMatch(email,
                  @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                  @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
                  RegexOptions.IgnoreCase);
            }    
        }

        /// <summary>
        /// Validates the given value for empty input.
        /// </summary>
        /// <param name="value">the value from the individual control</param>
        /// <param name="cultureInfo">the culture of the values. eg, dates should be UTC.</param>
        /// <param name="isValid">returns true if valid</param>
        /// <returns></returns>
        ValidationResult IValidation.Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(ErrorMessage);
            if (value == null && string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return result;
        }
    }
}
