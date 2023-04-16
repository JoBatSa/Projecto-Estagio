using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Employees;
using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

using Moq;
using Xunit;

namespace MasterDataTest
{
    public class EmployeeServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();
        private Mock<IEmployeeRepository> _introductionRepositoryMock = new Mock<IEmployeeRepository>();
        private List<Employee> listEmployees = new List<Employee>();
        private List<string> name = new List<string>(){"Jose Santos", "Carlos Santos"};
        private List<int> job_Position = new List<int>(){1,2};
        private List<string> email = new List<string>(){"jsantosa@mail.com","csantosa@mail.com"};
        private List<string> phone = new List<string>(){"+357951825654","+357951825653"};
        private List<string> password = new List<string>(){"qwerty","azerty"};


        /*  assegurar que foi adicionado um funcionario, se retornar a informaçao inserida passa no teste */
        [Fact]
        public async Task TestdAddAsync()
        {
                      
            Employee employee = new Employee(name[0], job_Position[0], email[0], phone[0], password[0]);

            this._introductionRepositoryMock.Setup(repo => repo.AddAsync(employee)).ReturnsAsync(employee);

            var _introductionService = new EmployeeService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.AddAsync(new EmployeeDto{Name=name[0],Job_Position= job_Position[0], UserEmail =email[0],UserPhoneNumber =  phone[0], Password = password[0]});

            Assert.Equal(this.name[0], intro.Name);
            Assert.Equal(this.job_Position[0], intro.Job_Position);
            Assert.Equal(this.email[0], intro.UserEmail);
            Assert.Equal(this.phone[0], intro.UserPhoneNumber);
            Assert.Equal(this.password[0], intro.Password);
        }


        /*  assegurar que retorna a lista completa de funcionarios que se retornar a informaçao inserida passa no teste */
        [Fact]
        public async Task TestGetAllAsync()
        {
            listEmployees.Add(new Employee(name[0], job_Position[0], email[0], phone[0], password[0]));
            listEmployees.Add(new Employee(name[1], job_Position[1], email[1], phone[1], password[1]));
           
            this._introductionRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(listEmployees);

            var _introductionService = new EmployeeService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetAllAsync();
       
            int i =0;
            int con= name.Count;
            while ((i < (con)))
             {
                Assert.Equal(this.name[i], list[i].Name);
                Assert.Equal(this.job_Position[i],list[i].Job_Position);
                Assert.Equal(this.email[i], list[i].UserEmail);
                Assert.Equal(this.phone[i], list[i].UserPhoneNumber);
                i++;
             }
         }

        /*  assegurar que retorna o funcionario pelo seu id */

        [Fact]
        public async Task TestGetByIdAsync()
        {
            Employee employee = new Employee(name[0], job_Position[0], email[0], phone[0], password[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(employee.Id)).ReturnsAsync(employee);

            var _introductionService = new EmployeeService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.GetByIdAsync(employee.Id);

            Assert.Equal(this.name[0], intro.Name);
            Assert.Equal(this.job_Position[0], intro.Job_Position);
            Assert.Equal(this.email[0], intro.UserEmail);
            Assert.Equal(this.phone[0], intro.UserPhoneNumber);
         
 
        }
         /*  assegurar que retorna o funcionario pelo seu nome,  */
        [Fact]
        public async Task TestGetByNameAsync()
        {
            Employee employee = new Employee(name[0], job_Position[0], email[0], phone[0], password[0]);

            listEmployees.Add(employee);

            this._introductionRepositoryMock.Setup(repo => repo.GetByNameAsync(employee.Name)).ReturnsAsync(listEmployees);

            var _introductionService = new EmployeeService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var list = await _introductionService.GetByNameAsync(employee.Name);
       
            int i =0;
            int con= list.Count;
            while ((i < (con)))
             {
                Assert.Equal(this.name[i], list[i].Name);
                Assert.Equal(this.job_Position[i],list[i].Job_Position);
                Assert.Equal(this.email[i], list[i].UserEmail);
                Assert.Equal(this.phone[i], list[i].UserPhoneNumber);
                i++;
             }
         }

        /*  assegurar que altera a posiçao do funcionario pretendido e retorna a informaçao alterada ,  */
        [Fact]
        public async Task TestUpdateAsync()
        {
            Employee employee = new Employee(name[0], job_Position[0], email[0], phone[0], password[0]);

            this._introductionRepositoryMock.Setup(repo => repo.GetByIdAsync(employee.Id)).ReturnsAsync(employee);

            var _introductionService = new EmployeeService(_unitOfWorkMock.Object, _introductionRepositoryMock.Object);

            var intro = await _introductionService.UpdateAsync(new EmployeeDto{Id = employee.Id.AsGuid(),Name=name[0],Job_Position= job_Position[1], UserEmail =email[0],UserPhoneNumber =  phone[0], Password = password[0],Active =employee.Active});

            Assert.Equal(this.name[0], intro.Name);
            Assert.Equal(this.job_Position[1], intro.Job_Position);
            Assert.Equal(this.email[0], intro.UserEmail);
            Assert.Equal(this.phone[0], intro.UserPhoneNumber);
           
         }

    }
}