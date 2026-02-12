using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace Test_project.Models
{
    public class MinimumNumericCountAttribute : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int _minCount = 3;
            var input = value as string;

            if (string.IsNullOrEmpty(input))
            {
                return ValidationResult.Success;
            }

            
            int digitCount = input.Count(c => char.IsDigit(c));

            if (digitCount >= _minCount)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult(ErrorMessage ?? $"The field must contain at least {_minCount} numbers.");
        }
    }

    public class StrictEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string email = value as string;

            if (string.IsNullOrWhiteSpace(email))
            {
                return ValidationResult.Success; 
            }

            try
            {
                
                var addr = new MailAddress(email);
                bool hasDotInDomain = addr.Host.Contains(".");
            


                if (addr.Address == email && hasDotInDomain)
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("The email format is invalid.");
            }
            catch
            {
                return new ValidationResult(ErrorMessage ?? "Invalid email address format");
            }
        }
    }
}
