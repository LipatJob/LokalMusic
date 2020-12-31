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
        private IList<ValidationRule> rules;


        public ValidationHelper(IValidator validator, ServerValidateEventArgs args)
        {
            this.validator = validator;
            this.args = args;
            this.rules = new List<ValidationRule>();
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
                if(rule.Command() == false)
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
        public Func<bool> Command;
        public string ErrorMessage;

        public ValidationRule(Func<bool> command, string errorMessage)
        {
            Command = command;
            ErrorMessage = errorMessage;
        }
    }

}