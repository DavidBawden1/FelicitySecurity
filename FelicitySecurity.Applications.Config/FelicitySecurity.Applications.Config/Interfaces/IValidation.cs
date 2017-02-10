using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FelicitySecurity.Applications.Config.Interfaces
{
    /// <summary>
    /// The IValidation interface provides: checks for valid input then applies an exception and an error message 
    /// </summary>
    public interface IValidation 
    {
        /// <summary>
        /// Determines whether or not the input is valid
        /// </summary>
        bool IsValid { get; }

        /// <summary>
        ///  Throws an exception when invalid input is given
        /// </summary>
        ValidationResult Validate(object value, CultureInfo cultureInfo);

        /// <summary>
        /// The Validation error message 
        /// </summary>
        string ErrorMessage { get; }
    }
}
