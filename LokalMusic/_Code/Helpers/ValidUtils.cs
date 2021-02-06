using System;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic._Code.Helpers
{
    public class ValidUtils
    {
        public static Func<bool> IsNotNull(object value)
        {
            return () => value != null;
        }

        // Range Comparators
        public static Func<bool> InRange(IComparable value, IComparable min, IComparable max)
        {
            return () => value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }

        public static Func<bool> IsMoreThan(IComparable value1, IComparable value2)
        {
            return () => value1.CompareTo(value2) > 0;
        }

        public static Func<bool> IsMoreThanEqualTo(IComparable value1, IComparable value2)
        {
            return () => value1.CompareTo(value2) >= 0;
        }

        public static Func<bool> IsLessThan(IComparable value1, IComparable value2)
        {
            return () => value1.CompareTo(value2) < 0;
        }

        public static Func<bool> IsLessThanEqualTo(IComparable value1, IComparable value2)
        {
            return () => value1.CompareTo(value2) >= 0;
        }

        public static Func<bool> IsValidPrice(string value)
        {
            decimal validDecimal;

            if (decimal.TryParse(value, out validDecimal))
            {
                return () => validDecimal.CompareTo((decimal)0) > 0;
            }
            else
                return () => false;
        }

        // String Comparators
        public static Func<bool> IsValidRegex(string value, string pattern, RegexOptions options = RegexOptions.None)
        {
            return () => Regex.Match(value, pattern, options).Success;
        }

        public static Func<bool> IsNotEmpty(string value)
        {
            return () => string.IsNullOrWhiteSpace(value) == false;
        }

        public static ValidationHelper CreatePasswordValidator(IValidator validator, ServerValidateEventArgs args, string password)
        {
            return new ValidationHelper(validator, args)
                .AddRule(
                    rule: IsNotEmpty(password),
                    errorMessage: "This is a required field")
                .AddRule(
                    rule: () => password.Length >= 5,
                    errorMessage: "Password must be at least 5 characters");
        }

        public static ValidationHelper CreateUsernameValidator(IValidator validator, ServerValidateEventArgs args, string username)
        {
            return new ValidationHelper(validator, args)
                .AddRule(
                    rule: IsNotEmpty(username),
                    errorMessage: "This is a required field")
                .AddRule(
                    rule: () => username.Length >= 5,
                    errorMessage: "Username must be at least 5 characters");
        }
    }
}