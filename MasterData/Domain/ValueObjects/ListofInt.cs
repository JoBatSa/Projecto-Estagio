using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasterData.Domain.ValueObjects
{
      [ComplexType]

    public class ListofInt: ValueObject
    {
        public int number { get;  private set; }


        private ListofInt() { } // EFCore needs for proper working



         public ListofInt(int listofInt) {
           this.number= listofInt;

            
        }

        public override string ToString()
        {
            return base.ToString();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}