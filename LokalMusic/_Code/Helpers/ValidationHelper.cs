using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic._Code.Helpers
{
    public class ValidationHelper
    {
        private IValidator validator;
        private ServerValidateEventArgs args;
        private IList<(Func<bool> command, string message)> rules;


        public ValidationHelper(IValidator validator, ServerValidateEventArgs args)
        {
            this.validator = validator;
            this.args = args;
            this.rules = new List<(Func<bool> command, string message)>();
        }

        public ValidationHelper AddRules(params (Func<bool> command, string message)[] rulesToAdd)
        {
            foreach (var rule in rulesToAdd)
            {
                rules.Add(rule);
            }
            return this;
        }

        public ValidationHelper AddRule((Func<bool> command, string message) rule)
        {
            rules.Add(rule);
            return this;
        }

        public void Execute()
        {
            foreach (var rule in rules)
            {
                if(rule.command() == false)
                {
                    args.IsValid = false;
                    validator.ErrorMessage = rule.message;
                    return;
                }
            }
            args.IsValid = true;
        }

        public static Func<bool> NotNull(object value)
        {
            return () => value != null;
        }

        public static Func<bool> IsTrue<T>(bool value)
        {
            return () => value;
        }

        public static Func<bool> IsEqualTo<T>(T value1, T value2)
        {
            return () => value1.Equals(value2);
        }

        public static Func<bool> IsNotEqualTo<T>(T value1, T value2)
        {
            return () => !value1.Equals(value2);
        }

        public static Func<bool> I<T>(T value1, T value2)
        {
            return () => value1.Equals(value2);
        }

        public static Func<bool> InRange(IComparable value, IComparable min, IComparable max)
        {
            return () => value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0;
        }

        public static Func<bool> IsValidRegex(string value, string pattern, RegexOptions options = RegexOptions.None)
        {
            return () => Regex.Match(value, pattern, options).Success;
        }


    }

}