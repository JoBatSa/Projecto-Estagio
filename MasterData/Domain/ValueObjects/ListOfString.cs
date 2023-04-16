namespace MasterData.Domain.ValueObjects
{
    public class ListOfString
    {
        public string frase { get;  private set; }


        private ListOfString() { } // EFCore needs for proper working



         public ListOfString(string listOfString) {
           this.frase= listOfString;

            
        }

        public override string ToString()
        {
            return base.ToString();
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