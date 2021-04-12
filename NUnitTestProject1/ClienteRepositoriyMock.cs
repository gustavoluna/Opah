using Opah.Application.DTOs;
using Opah.Application.Interfaces;
using Opah.Application.Interfaces.Repositories;
using Opah.Domain.Entities;
using Opah.Infrastructure.Persistence.Contexts;
using Opah.Infrastructure.Shared.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTestProject1
{
    public class ClienteRepositoriyMock : IClienteRepositoryAsync
    {

        public ClienteRepositoriyMock _clienterepository;
        public ClienteEnderecoRepositoriyMock _clientEenderecoRepositoryAsync;
        public EnderecoRepositoriyMock _enderecoRepository;

        public ClienteRepositoriyMock()
        {
            //_clienterepository = new  ClienteRepositoriyMock();
            //_clientEenderecoRepositoryAsync = new ClienteEnderecoRepositoriyMock();
            //_enderecoRepository = new EnderecoRepositoriyMock();            
        }


        public async Task<Cliente> AddAsync(Cliente entity)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = 1;
            return cliente;
        }

        public void AtualizaCliente(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Cliente>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Cliente>> GetAllAsync(Expression<Func<Cliente, bool>> predicate, params string[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = 1;
            return cliente;
        }

        public Task<IReadOnlyList<Cliente>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<Cliente> InsereCliente(Cliente obj)
        {
            Cliente cliente = new Cliente();

            cliente.Email = "Fabiano2@gmail.com";
            cliente.DataNascimento = DateTime.Now;
            cliente.Cod_Empresa = "1";
            cliente.Telefone = "119846565";
            cliente.Cpf = "123456";
            cliente.IdCliente = obj.IdCliente;
            cliente.Nome = "Fabiano";
            

            return cliente;
        }

        public async Task<Cliente> RetornarCliente(int IdCliente)
        {
            Cliente cliente = new Cliente();
            cliente.IdCliente = 1;
            return cliente;
        }

        public async Task<List<Cliente>> RetornarClientes(string CodEmpresa, string Nome, string Cpf, string idCidade, string UF)
        {
            List<Cliente> listaCliente = new List<Cliente>();

            Cliente cliente = new Cliente();
            cliente.IdCliente = 1;

            listaCliente.Add(cliente);

            Cliente cliente2 = new Cliente();
            cliente2.IdCliente = 2;
            listaCliente.Add(cliente2);

            return listaCliente;
        }

        public async Task<bool> RetornarCpfCadastrado(string Cpf, string CodEmpresa)
        {
            bool ret = true;
            string cpf_ = "123456";
            string CodEmpresa_ = "1";

            if (Cpf == cpf_ && CodEmpresa_ == CodEmpresa)
                ret = false;

            return ret;
        }

        public Task UpdateAsync(Cliente entity)
        {
            throw new NotImplementedException();
        }
    }
}
