using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

using DDDSample1.Domain.Shared;





namespace MasterData.Domain.ValueObjects{

    [ComplexType]
    public class PhoneNumberType : ValueObject {
        
        public string PhoneNumber{ get; private set; }

        private PhoneNumberType(){} // EFCore needs for proper working

        public PhoneNumberType(string phoneNumber) {

            if (phoneNumber == null) throw new BusinessRuleValidationException("Phone number cant't be null!");

            if(!IsValidPhoneNumber(phoneNumber)) throw new BusinessRuleValidationException("Phone number is not Valid!");

            this.PhoneNumber = phoneNumber;
        }

        public static bool IsValidPhoneNumber(string phoneNumber) {

            string phoneNumberRegexPattern = @"^(\+|00)[0-9]{3}[0-9]{4,11}$";

            try {
                return Regex.IsMatch(phoneNumber, phoneNumberRegexPattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            } catch (RegexMatchTimeoutException) {
                return false;
            }
        }
 protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return PhoneNumber;
        }

    }
}