using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Shared.Helpers
{
    public sealed class MinimumAgeAttribute : ValidationAttribute
    {
        private int _minimumAge;

        public MinimumAgeAttribute(int minimumAge)
        {
            _minimumAge = minimumAge;
            ErrorMessage = "You must be someone at least {1} years of age";
        }

        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date.AddYears(_minimumAge) < DateTime.Now;
            }

            return false;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, _minimumAge);
        }
    }
}
