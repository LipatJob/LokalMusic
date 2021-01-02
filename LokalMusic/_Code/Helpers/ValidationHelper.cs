using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LokalMusic._Code.Helpers
{
    /// <summary>
    /// <code>
    /// new ValidationHelper()
    /// </code>
    /// </summary>
    public class ValidationHelper
    {
        private IList<ValidationRule> rules;
        private IValidator validator;
        private ServerValidateEventArgs args;

        public ValidationHelper(IValidator validator, ServerValidateEventArgs args)
        {
            this.rules = new List<ValidationRule>();
            this.validator = validator;
            this.args = args;
        }

        public ValidationHelper AddRules(params ValidationRule[] rulesToAdd)
        {
            foreach (var rule in rulesToAdd)
            {
                rules.Add(rule);
            }
            return this;
        }

        public ValidationHelper AddRule(ValidationRule rule)
        {
            rules.Add(rule);
            return this;
        }

        public ValidationHelper AddRule(Func<bool> rule, string errorMessage)
        {
            rules.Add(new ValidationRule(rule, errorMessage));
            return this;
        }

        public void Validate()
        {
            foreach (var rule in rules)
            {
                if (rule.rule() == false)
                {
                    args.IsValid = false;
                    validator.ErrorMessage = rule.ErrorMessage;
                    return;
                }
            }
            args.IsValid = true;
        }
    }

    public struct ValidationRule
    {
        public Func<bool> rule;
        public string ErrorMessage;

        public ValidationRule(Func<bool> rule, string errorMessage)
        {
            this.rule = rule;
            ErrorMessage = errorMessage;
        }
    }
}