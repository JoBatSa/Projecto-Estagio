using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using DDDSample1.Domain.Shared;

namespace MasterData.Domain.ValueObjects
{
    [ComplexType]
    public class Password : ValueObject
    {
        public string texto { get; private set; }

        public Password()
        {
            this.texto = this.generatePassword();
        }
        public Password(string texto)


        {
            if (TestTexto(texto))
            {
                this.texto = texto;
            }
            else
            {
                throw new BusinessRuleValidationException("Invalid");
            }
        }

        private bool TestTexto(string texto)
        {

            if (string.IsNullOrEmpty(texto))
            {
                return false;
            }
            return true;
        }

        public string generatePassword()
        {
            var random = new Random();
            int passwordLength = 7;
            string CapitalLetters = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string SmallLetters = "qwertyuiopasdfghjklzxcvbnm";
            string Digits = "0123456789";
            string SpecialCharacters = "!@#$%^&*()-_=+<,>.";
            string allChar = CapitalLetters + SmallLetters + Digits + SpecialCharacters;

            var stringChars = new char[passwordLength];
            for (int i = 0; i < passwordLength; i++)
            {
                stringChars[i] = allChar[random.Next(allChar.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }

        public string toString()
        {
            return this.texto;
        }
            protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return texto;
        }
    }
}