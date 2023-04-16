using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Employees;
using MasterData.Domain.ValueObjects;
using DDDSample1.Domain.Shared;

using Xunit;

namespace TesteUnitMasterD
{
    public class EmployeeTests
    {
       
        private string name ="Jose Santos";

        public Job_PositionType job_Position = new Job_PositionType(1);

        public int wjob_Position = 6;

        public EmailType userEmail= new EmailType("santos@outlook.com");

        public string wuserEmail= "santos§outlook.com";

        public string wuserEmailV= "";

        public PhoneNumberType userPhoneNumber= new PhoneNumberType("+351963951753");
 
        string wuserPhoneNumberT ="+351951S34987";

          string wuserPhoneNumberTV ="";

        public string password ="qwerty";
        /*  verificar que o objeto é criado com sucesso  atendendo as regras de negocio */
        [Fact]
        public void EmployeeConstructor()
        {
            Employee employee = new Employee(name,job_Position.job_Position,userEmail.Email,userPhoneNumber.PhoneNumber,password);
            Assert.NotNull(employee);
            Assert.Equal(employee.Name, this.name );
            Assert.Equal(employee.Job_Position.job_Position, this.job_Position.job_Position);
            Assert.Equal(employee.UserEmail.Email, this.userEmail.Email);
            Assert.Equal(employee.UserPhoneNumber.PhoneNumber, this.userPhoneNumber.PhoneNumber);
            Assert.Equal(employee.Password, this.password);            
        }
        /*  assegurar que não foi violada uma regra de negócio através do “BusinessRuleValidationException” inserindo uma posiçao que nao existe*/
        [Fact]
        public void TestJobValidate()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Employee(name,wjob_Position,userEmail.Email,userPhoneNumber.PhoneNumber,password));
        }
         /*  assegurar que não foi violada uma regra de negócio através do “BusinessRuleValidationException” inserindo um email incorreto ou campo vazio*/
         [Fact]
        public void TestEmailValidate()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Employee(name,job_Position.job_Position,wuserEmail,userPhoneNumber.PhoneNumber,password));
            Assert.Throws<BusinessRuleValidationException>(() => new Employee(name,job_Position.job_Position,wuserEmailV,userPhoneNumber.PhoneNumber,password));
        }
         /*  assegurar que não foi violada uma regra de negócio através do “BusinessRuleValidationException” inserindo um campo vazio ou um numero invalido*/
        [Fact]
        public void TestPhoneValidate()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Employee(name,job_Position.job_Position,userEmail.Email,wuserPhoneNumberT,password));
            Assert.Throws<BusinessRuleValidationException>(() => new Employee(name,job_Position.job_Position,userEmail.Email,wuserPhoneNumberTV,password));
        }


    }  
    
}