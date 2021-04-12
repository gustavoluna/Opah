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
    public class EnderecoRepositoriyMock : IEnderecoRepositoryAsync
    {

        public ClienteRepositoriyMock _clienterepository;
        public ClienteEnderecoRepositoriyMock _clientEenderecoRepositoryAsync;
        public EnderecoRepositoriyMock _enderecoRepository;

        public EnderecoRepositoriyMock()
        {
            //_clienterepository = new ClienteRepositoriyMock();
            //_clientEenderecoRepositoryAsync = new ClienteEnderecoRepositoriyMock();
            //_enderecoRepository = new EnderecoRepositoriyMock();
        }

        public async Task<Endereco> AddAsync(Endereco entity)
        {
            Endereco end = new Endereco();
            end.IdEndereco = 1;

            return end;
        }

        public Task DeleteAsync(Endereco entity)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Endereco>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IList<Endereco>> GetAllAsync(Expression<Func<Endereco, bool>> predicate, params string[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Endereco>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<Endereco> RetornarEndereco(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Endereco entity)
        {
            throw new NotImplementedException();
        }
    }
}
