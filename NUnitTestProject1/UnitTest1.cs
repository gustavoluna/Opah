using Opah.Application.DTOs;
using Opah.Application.Interfaces;
using Opah.Infrastructure.Persistence.Contexts;
using Opah.Infrastructure.Shared.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Configuration;

namespace NUnitTestProject1
{
    public class Tests
    {
        private readonly IClienteService _clienteService;
        [SetUp]
        public void Setup()
        {
        }

        public Tests()
        {
            
        }

        [Test]
        public void TesteRetornar1Cliente()
        {
            var clienteRepository = new ClienteRepositoriyMock();
            var clienteEnderecoRepository = new ClienteEnderecoRepositoriyMock();
            var EnderecoRepository = new EnderecoRepositoriyMock();
            var _clienteService = new ClienteService(clienteRepository, clienteEnderecoRepository, EnderecoRepository);


            var cli = _clienteService.RetornarCliente(1);
            Assert.AreEqual(1, cli.Result.IdCliente);
        }

      
        
        [Test]
        public void TestClienteAdd()
        {

            var clienteRepository = new ClienteRepositoriyMock();
            var clienteEnderecoRepository = new ClienteEnderecoRepositoriyMock();
            var EnderecoRepository = new EnderecoRepositoriyMock();
            var _clienteService = new ClienteService(clienteRepository, clienteEnderecoRepository, EnderecoRepository);


            EnderecoRequest end = new EnderecoRequest();
            end.Tipo_Endereco = "1";
            end.IdCidade = 1;
            end.Rua = "rua1";
            end.Complemento = "ap1";
            end.Numero = "181";
            end.Bairro = "bairro";


            ClienteRequest cliente = new ClienteRequest();

            cliente.Email = "Fabiano2@gmail.com";
            cliente.DataNascimento = DateTime.Now;
            cliente.Cod_Empresa = "1";
            cliente.Telefone = "119846565";
            cliente.Cpf = "123546789";
            cliente.Nome = "Fabiano ";
            cliente.Endereco = end;
            var clie = _clienteService.InsereCliente(cliente).Result;
            Assert.IsNotNull(clie);
        }


        [Test]
        public void TestClienteAddCpfJaCadastrado()
        {

            var clienteRepository = new ClienteRepositoriyMock();
            var clienteEnderecoRepository = new ClienteEnderecoRepositoriyMock();
            var EnderecoRepository = new EnderecoRepositoriyMock();
            var _clienteService = new ClienteService(clienteRepository, clienteEnderecoRepository, EnderecoRepository);


            EnderecoRequest end = new EnderecoRequest();
            end.Tipo_Endereco = "1";
            end.IdCidade = 1;
            end.Rua = "rua1";
            end.Complemento = "ap1";
            end.Numero = "181";
            end.Bairro = "bairro";


            ClienteRequest cliente = new ClienteRequest();

            cliente.Email = "Fabiano2@gmail.com";
            cliente.DataNascimento = DateTime.Now;
            cliente.Cod_Empresa = "1";
            cliente.Telefone = "119846565";
            cliente.Cpf = "123456";
            cliente.Nome = "Fabiano ";
            cliente.Endereco = end;
            var clie = _clienteService.InsereCliente(cliente).Result;
            Assert.Null(clie);
        }

        [Test]
        public void TestClienteAddTipoEnderecoRepetido()
        {
            //validando tipo endereco repetido para o mesmo cpf

            var clienteRepository = new ClienteRepositoriyMock();
            var clienteEnderecoRepository = new ClienteEnderecoRepositoriyMock();
            var EnderecoRepository = new EnderecoRepositoriyMock();
            var _clienteService = new ClienteService(clienteRepository, clienteEnderecoRepository, EnderecoRepository);


            EnderecoRequest end = new EnderecoRequest();
            end.Tipo_Endereco = "1";
            end.IdCidade = 1;
            end.Rua = "rua1";
            end.Complemento = "ap1";
            end.Numero = "181";
            end.Bairro = "bairro";


            ClienteRequest cliente = new ClienteRequest();

            cliente.Email = "Fabiano6@gmail.com";
            cliente.DataNascimento = DateTime.Now;
            cliente.Cod_Empresa = "1";
            cliente.Telefone = "119846565";
            cliente.Cpf = "9876554";
            cliente.Nome = "Fabiano 6";
            cliente.Endereco = end;
            var clie = _clienteService.InsereCliente(cliente).Result;
            Assert.Null(clie);
        }

    }
}
