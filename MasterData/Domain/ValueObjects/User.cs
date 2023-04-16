

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DDDSample1.Domain.Shared;

namespace MasterData.Domain.ValueObjects
{
    [ComplexType]
    public class User : ValueObject
    {
        public string user { get; private set; }
        private User() { }
        public User(string user)
        {
            if (TestUser(user))
            {
                this.user = user;
            }
            else
            {
                throw new BusinessRuleValidationException("Invalid");
            }
        }

        private bool TestUser(string User)
        {
            if (string.IsNullOrEmpty(User))
            {
                return false;
            }
            if(user=="admin_XVI"){
               return false; 
            }
            return true;
        }

        public string toString(){
            return this.user;
        }

         protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return user;
        }
    }
}