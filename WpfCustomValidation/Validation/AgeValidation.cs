namespace WpfCustomValidation.Validation
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;

    public class AgeValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int age;
            if (Int32.TryParse(value.ToString(), out age))
                if (age >= 18 && age <= 120)
                    return new ValidationResult(true, null);
            return new ValidationResult(false, "Age must be greater or Equal than 18");
        }
    }
}
