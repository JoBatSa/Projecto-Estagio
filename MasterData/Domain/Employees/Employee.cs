using System;
using DDDSample1.Domain.Employees;


using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;


namespace DDDSample1.Domain.Employees
{
    public class Employee : Entity<EmployeeId>, IAggregateRoot {

             
        public string Name { get;  private set; }
         
        public Job_PositionType Job_Position { get; private set; }

        public EmailType UserEmail{ get; private set; }

        public PhoneNumberType UserPhoneNumber{ get; private set; }

        public string Password { get;  private set; }
       
        public bool Active{ get;  private set; }

        public Employee()
        {
            this.Active = true;
        }


       


        public Employee( string name, int job_Position, string userEmail, string userPhoneNumber, string password) {
            this.Id = new EmployeeId(Guid.NewGuid());
            this.Name = name;
            this.Job_Position= new Job_PositionType(job_Position);
            this.UserEmail=new EmailType(userEmail);
            this.UserPhoneNumber=new PhoneNumberType(userPhoneNumber);
            this.Password=password;

            this.Active = true;

           
        }

        public void ChangeJobPosition(int job_Position)
        {
            if (!this.Active)
                throw new BusinessRuleValidationException("It is not possible to change the job position to an inactive worker.");
            this.Job_Position = new Job_PositionType(job_Position);
        }
        public void MarkAsInative()
        {
            this.Active = false;
        }

  
    }
}