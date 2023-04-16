/*
using System.Collections.Generic;
using System.Threading.Tasks;
using DDDSample1.Domain.Employees;

using DDDSample1.Domain.Shared;
using MasterData.Domain.ValueObjects;

using Xunit;

namespace TesteUnitMasterD
{
    public class FuncionarioTests
    {


         public string Name  = "Jose Santos";
         
        
         public string WrongName  = "";
        
        public Job_PositionType Job_Position =new Job_PositionType("1");

        public EmailType UserEmail{ get; private set; }

        public PhoneNumberType UserPhoneNumber{ get; private set; }

        public string Password { get;  private set; }
       
        public bool Active{ get;  private set; }

        private string Name = "Jose Santos";
        private string nomeErrado = "";
        private Data dataNascimento = new Data("1986-09-29");
        private string dataNascimentoInv = "1986-09";
        private Texto funcao = new Texto("Devoloper");
        private string funcaoErrada = "";
        private NIF nNIF = new NIF("826349576");
        private BI nBI = new BI("37412359");

        private string nNIFErrado = "82634956";
        private string nBIErrado = "3742359";
        private SegurancaSocial segurancaSocial = new SegurancaSocial("65465484632");
        private string segurancaSocialErrado = "6546548432";
        private Password password = new Password();
        private Email email = new Email("susana@email.com");
        private string emailIncorreto = "susana_email.com";
        private TipoRetencao tipoRetencao = TipoRetencao.naoCasado;
        private float salario = 2500;
        private float salarioInv = 0;
        private int dependentes = 0;
        private float subAlimentacao = (float)15.6;
        private string dta = "1986-09-29";
        private int ferias = 22;

        [Fact]
        public void FuncionarioConstructor()
        {
            Funcionario funcionario = new Funcionario(nome.texto, dta, funcao.texto, nNIF.nif, nBI.nBI, segurancaSocial.segurancaSocial, tipoRetencao.ToString(), email.email, salario, subAlimentacao, dependentes, ferias);
            Assert.NotNull(funcionario);
            Assert.Equal(funcionario.nome.texto, this.nome.texto);
            Assert.Equal(funcionario.dataNascimento.data, this.dataNascimento.data);
            Assert.Equal(funcionario.funcao.texto, this.funcao.texto);
            Assert.Equal(funcionario.nNIF.nif, this.nNIF.nif);
            Assert.Equal(funcionario.nBI.nBI, this.nBI.nBI);
            Assert.Equal(funcionario.segurancaSocial.segurancaSocial, this.segurancaSocial.segurancaSocial);
            Assert.Equal(funcionario.tipoRetencao.ToString(), this.tipoRetencao.ToString());
            Assert.Equal(funcionario.email.email, this.email.email);
            Assert.Equal(funcionario.subAlimentacao, this.subAlimentacao);
            Assert.Equal(funcionario.dependentes, this.dependentes);
            Assert.Equal(funcionario.ferias, this.ferias);
        }
        [Fact]
        public void ShouldFuncionarioDontValidateEmail()
        {

            Assert.Throws<BusinessRuleValidationException>(() => new Funcionario(nome.texto, dta, funcao.texto, nNIF.nif, nBI.nBI, segurancaSocial.segurancaSocial, tipoRetencao.ToString(), emailIncorreto, salario, subAlimentacao, dependentes, ferias));
        }
        [Fact]
        public void ShouldFuncionarioDontValidateNIF()
        {

            Assert.Throws<BusinessRuleValidationException>(() => new Funcionario(nome.texto, dta, funcao.texto, nNIFErrado, nBI.nBI, segurancaSocial.segurancaSocial, tipoRetencao.ToString(), email.email, salario, subAlimentacao, dependentes, ferias));
        }
        [Fact]
        public void ShouldFuncionarioDontValidateBI()
        {

            Assert.Throws<BusinessRuleValidationException>(() => new Funcionario(nome.texto, dta, funcao.texto, nNIF.nif, nBIErrado, segurancaSocial.segurancaSocial, tipoRetencao.ToString(), email.email, salario, subAlimentacao, dependentes, ferias));
        }
        [Fact]
        public void ShouldFuncionarioDontValidateNSegdSocial()
        {

            Assert.Throws<BusinessRuleValidationException>(() => new Funcionario(nome.texto, dta, funcao.texto, nNIF.nif, nBI.nBI, segurancaSocialErrado, tipoRetencao.ToString(), email.email, salario, subAlimentacao, dependentes, ferias));
        }
        [Fact]
        public void ShouldFuncionarioDontValidateNomeVazio()
        {

            Assert.Throws<BusinessRuleValidationException>(() => new Funcionario(nomeErrado, dta, funcao.texto, nNIF.nif, nBI.nBI, segurancaSocialErrado, tipoRetencao.ToString(), email.email, salario, subAlimentacao, dependentes, ferias));
        }
        [Fact]
        public void ShouldFuncionarioDontValidateFuncaoVazia()
        {

            Assert.Throws<BusinessRuleValidationException>(() => new Funcionario(nome.texto, dta, funcaoErrada, nNIF.nif, nBI.nBI, segurancaSocialErrado, tipoRetencao.ToString(), email.email, salario, subAlimentacao, dependentes, ferias));
        }
        [Fact]
        public void ShouldFuncionarioDontValidateDataInvalida()
        {

            Assert.Throws<BusinessRuleValidationException>(() => new Funcionario(nome.texto, dataNascimentoInv, funcao.texto, nNIF.nif, nBI.nBI, segurancaSocialErrado, tipoRetencao.ToString(), email.email, salario, subAlimentacao, dependentes, ferias));
        }
        [Fact]
        public void ShouldFuncionarioDontValidateSalarioInvalido()
        {

            Assert.Throws<BusinessRuleValidationException>(() => new Funcionario(nome.texto, dataNascimentoInv, funcao.texto, nNIF.nif, nBI.nBI, segurancaSocialErrado, tipoRetencao.ToString(), email.email, salarioInv, subAlimentacao, dependentes, ferias));
        }
    }
}*/