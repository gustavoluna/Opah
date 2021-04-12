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
    public class ClienteEnderecoRepositoriyMock : IClienteEnderecoRepositoryAsync
    {
        public ClienteRepositoriyMock _clienterepository;
        public ClienteEnderecoRepositoriyMock _clientEenderecoRepositoryAsync;
        public EnderecoRepositoriyMock _enderecoRepository;
        public ClienteEnderecoRepositoriyMock()
        {
            //_clienterepository = new ClienteRepositoriyMock();
            //_clientEenderecoRepositoryAsync = new ClienteEnderecoRepositoriyMock();
            //_enderecoRepository = new EnderecoRepositoriyMock();
        }

        public async Task<ClienteEndereco> AddAsync(ClienteEndereco entity)
        {
            ClienteEndereco cli = new ClienteEndereco();
            cli.IdClienteEndereco = 1;
            return cli;
        }

        public void Adicionar(ClienteEndereco clienteEndereco)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ClienteEndereco entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ClienteEndereco>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<ClienteEndereco>> GetAllAsync(Expression<Func<ClienteEndereco, bool>> predicate, params string[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public Task<ClienteEndereco> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<ClienteEndereco>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClienteEndereco>> RetornarEnderecoPorCliente(string IdCliente)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ClienteEndereco entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidarEnderecoCliente(string cpf, string TipoEndereco)
        {
            bool ret = true;

            string cpf_ = "9876554";
            string TipoEndereco_ = "1";

            if (cpf == cpf_ && TipoEndereco_ == TipoEndereco)
                ret = false;

            return ret;
        }
    }
}
