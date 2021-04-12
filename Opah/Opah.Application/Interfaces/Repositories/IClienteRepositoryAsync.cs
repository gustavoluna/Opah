using Opah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Opah.Application.Interfaces.Repositories
{
    public interface IClienteRepositoryAsync : IGenericRepositoryAsync<Cliente>
    {        
        Task<Cliente> RetornarCliente(int IdCliente);
        Task<Cliente> InsereCliente(Cliente cliente);
        void AtualizaCliente(Cliente cliente);
        Task<bool> RetornarCpfCadastrado(string Cpf, string CodEmpresa);
        Task<List<Cliente>> RetornarClientes(string CodEmpresa, string Nome, string Cpf, string idCidade, string UF);
    }
}
