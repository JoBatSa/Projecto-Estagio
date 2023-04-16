using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DDDSample1.Domain.Shared;

namespace MasterData.Domain.ValueObjects
{
    [ComplexType]
    public class Text : ValueObject
    {
        public string text { get; private set; }
        private Text() { }
        public Text(string text)
        {
            if (TestText(text))
            {
                this.text = text;
            }
            else
            {
                throw new BusinessRuleValidationException("Invalid");
            }
        }
        private bool TestText(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }
            return true;
        }

        public string toString(){
            return this.text;
        }

         protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return text;
        }
    }
}