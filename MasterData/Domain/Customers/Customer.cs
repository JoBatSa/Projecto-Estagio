using System;
using MasterData.Domain.ValueObjects;
using DDDSample1.Domain.Shared;
using DDDSample1.Domain.Customers;

namespace DDDSample1.Domain.Customers
{
    public class Customer : Entity<CustomerId>, IAggregateRoot
    {
     
        public string Company { get;  private set; }

        public string Name { get;  private set; }

        public EmailType CustomerEmail{ get; private set; }

        public PhoneNumberType CustomerPhoneNumber{ get; private set; }

        public int Nif { get;  private set; }

        public string Password { get;  private set; }

        public bool Active{ get;  private set; }

        public Job_PositionType CustPosition { get; private set; }


        public Customer()
        {
            this.Active = true;
        }

        public Customer(string company,string name, string customerEmail, string customerPhoneNumber,int nif, string password)
        {
            this.Id = new CustomerId(Guid.NewGuid());
            this.Company = company;
            this.Name = name;
            this.CustomerEmail=new EmailType(customerEmail);
            this.CustomerPhoneNumber=new PhoneNumberType(customerPhoneNumber);
            this.Nif= nif;
             this.Password=password;
            this.CustPosition = new Job_PositionType(100);
            this.Active = true;
        }

       

        public void ChangeDescription(string company)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the description to an inactive company.");
            this.Company = company;
        }

        
        public void MarkAsInative()
        {
            this.Active = false;
        }
    }
}
