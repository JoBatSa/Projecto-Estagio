using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Customers;
using MasterData.Domain.ValueObjects;
using DDDSample1.Domain.Shared;

using Xunit;

namespace TesteUnitMasterD
{
    public class CustomerTests
    {

        private string company ="Amazons";

        private string name ="Jose Santos";

     
        public EmailType customerEmail= new EmailType("santos@outlook.com");

        public string wcustomerEmail= "santos§outlook.com";

        public string wcustomerEmailV= "";

        public PhoneNumberType customerPhoneNumber= new PhoneNumberType("+351963951753");
 
        string wcustomerPhoneNumberT ="+351321654B97";

         string wcustomerPhoneNumberTV ="";

        public int nif =505123987;

        public string password ="qwerty";

        /*  verificar que o objeto é criado com sucesso  atendendo as regras de negocio */
        [Fact]
        public void CustomerConstructor()
        {
            Customer customer = new Customer(company,name,customerEmail.Email,customerPhoneNumber.PhoneNumber,nif,password);
            Assert.NotNull(customer);
            Assert.Equal(customer.Name, this.name );
            Assert.Equal(customer.CustomerEmail.Email, this.customerEmail.Email);
            Assert.Equal(customer.CustomerPhoneNumber.PhoneNumber, this.customerPhoneNumber.PhoneNumber);
            Assert.Equal(customer.Password, this.password);            
        }
        /*  assegurar que não foi violada uma regra de negócio através do “BusinessRuleValidationException” inserindo um email incorreto ou campo vazio*/
         [Fact]
        public void TestEmailValidate()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Customer(company,name,wcustomerEmail,customerPhoneNumber.PhoneNumber,nif,password));
            Assert.Throws<BusinessRuleValidationException>(() => new Customer(company,name,wcustomerEmailV,customerPhoneNumber.PhoneNumber,nif,password));
        }

        /*  assegurar que não foi violada uma regra de negócio através do “BusinessRuleValidationException” inserindo um campo vazio ou um numero invalido*/
        [Fact]
        public void TestPhoneValidate()
        {
            Assert.Throws<BusinessRuleValidationException>(() => new Customer(company,name,customerEmail.Email,wcustomerPhoneNumberT,nif,password));
            Assert.Throws<BusinessRuleValidationException>(() => new Customer(company,name,customerEmail.Email,wcustomerPhoneNumberTV,nif,password));
        }

    }  
    
}