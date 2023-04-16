using System;
using MasterData.Domain.ValueObjects;

namespace DDDSample1.Domain.Employees
{
    public class EmployeeDto
    {
         
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Job_Position {get;set;}

        public string UserEmail {get;set;}

        public string UserPhoneNumber {get;set;}

        public string Password { get; set; }

        public bool Active {get;set;}
    }
}