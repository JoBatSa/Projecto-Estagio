using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Customers;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

using Moq;
using Xunit;


namespace MasterDataTest
{
    public class CustomerServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private Mock<ICustomerRepository> _introductionRepositoryMock = new Mock<ICustomerRepository>();

        private List<Customer> listCustomers = new List<Customer>();

        private List<string> company = new List<string>(){"Amazons","Terrazons"};

        private List<string> name = new List<string>(){"Jose Santos","Carlos Santos"};
        private List<string> email = new List<string>(){"jsantosa@mail.com","csantosa@mail.com"};
        private List<string> phone = new List<string>(){"+357951825654", "+357951825653"};

         private List<int> nif = new List<int>(){505123987, 505123954};
        private List<string> password = new List<string>(){"qwerty","azerty"};

        [Fact]
        public async Task TestdAddAsync()
        {
            Customer customer = new Customer(company[0],name[0], email[0], phone[0],nif[0], password[0]);

            this._introductionRepositoryMock.Setup(repo => repo.AddAsync(customer)).ReturnsAsync(customer);

            var _introductionService = new CustomerService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.AddAsync(new CustomerDto{Company=company[0],Name=name[0], CustomerEmail =email[0],CustomerPhoneNumber =  phone[0],Nif=nif[0], Password = password[0]});

            Assert.Equal(this.company[0], intro.Company);
            Assert.Equal(this.name[0], intro.Name);
            Assert.Equal(this.email[0], intro.CustomerEmail);
            Assert.Equal(this.phone[0], intro.CustomerPhoneNumber);
            Assert.Equal(this.nif[0], intro.Nif);
            Assert.Equal(this.password[0], intro.Password);
        }

        [Fact]
        public async Task TestGetAllAsync()
        {
        
            listCustomers.Add(new Customer(company[0],name[0], email[0], phone[0],nif[0], password[0]));
            listCustomers.Add(new Customer(company[1],name[1], email[1], phone[1],nif[1], password[1]));
           
            this._introductionRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(listCustomers);

            var _introductionService = new CustomerService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetAllAsync();
       
            int i =0;
            int con= name.Count;
             while ((i < (con)))
             {
                Assert.Equal(this.company[i], list[i].Company);
                Assert.Equal(this.name[i], list[i].Name);
                Assert.Equal(this.email[i], list[i].CustomerEmail);
                Assert.Equal(this.phone[i], list[i].CustomerPhoneNumber);
                Assert.Equal(this.nif[i], list[i].Nif);
                i++;
            }
        }


        [Fact]
        public async Task TestGetByIdAsync()
        {
                     
            Customer customer = new Customer(company[0],name[0], email[0], phone[0],nif[0], password[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(customer.Id)).ReturnsAsync(customer);

            var _introductionService = new CustomerService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.GetByIdAsync(customer.Id);

            Assert.Equal(this.company[0], intro.Company);
            Assert.Equal(this.name[0], intro.Name);
            Assert.Equal(this.email[0], intro.CustomerEmail);
            Assert.Equal(this.phone[0], intro.CustomerPhoneNumber);
            Assert.Equal(this.nif[0], intro.Nif);
           
        }

        [Fact]
        public async Task TestGetByCompanyAsync()
        {
                      
            Customer customer = new Customer(company[0],name[0], email[0], phone[0],nif[0], password[0]);
          
            this._introductionRepositoryMock.Setup(repo => repo.GetByCompanyAsync(customer.Company)).ReturnsAsync(listCustomers);

            var _introductionService = new CustomerService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetByCompanyAsync(customer.Company);
            int i =0;
            int con= list.Count;
             while ((i < (con)))
             {
                Assert.Equal(this.company[i], list[i].Company);
                Assert.Equal(this.name[i], list[i].Name);
                Assert.Equal(this.email[i], list[i].CustomerEmail);
                Assert.Equal(this.phone[i], list[i].CustomerPhoneNumber);
                Assert.Equal(this.nif[i], list[i].Nif);
                i++;
            }
             
         }


        [Fact]
        public async Task TestUpdateAsync()
        {
           
            Customer customer = new Customer(company[0],name[0], email[0], phone[0],nif[0], password[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(customer.Id)).ReturnsAsync(customer);

            var _introductionService = new CustomerService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.UpdateAsync(new CustomerDto{Id = customer.Id.AsGuid(),Company=company[1],Name=name[0], CustomerEmail =email[0],CustomerPhoneNumber =  phone[0],Nif=nif[0], Password = password[0]});

            Assert.Equal(this.company[1], intro.Company);
            Assert.Equal(this.name[0], intro.Name);
            Assert.Equal(this.email[0], intro.CustomerEmail);
            Assert.Equal(this.phone[0], intro.CustomerPhoneNumber);
            Assert.Equal(this.nif[0], intro.Nif);
           
         }

    }
}