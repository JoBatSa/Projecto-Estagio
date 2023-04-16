using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using DDDSample1.Domain.Shared;

namespace MasterData.Domain.ValueObjects
{

    [ComplexType]
    public class EmailType : ValueObject
    {

        public string Email { get; private set; }

        private EmailType() { } // EFCore needs for proper working

        public EmailType(string email)
        {

            if (email == null) throw new BusinessRuleValidationException("Email cant't be null!");

            email = email.ToLower();

            if (!IsValidEmail(email)) throw new BusinessRuleValidationException("Email is not Valid!");

            this.Email = email;
        }

        public static bool IsValidEmail(string email)
        {

            string emailRegexPattern = @"^(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|'(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*')@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])$";

            try
            {
                return Regex.IsMatch(email, emailRegexPattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

       protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Email;
        }

    }
}