using Opah.Application.DTOs;
using Opah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Opah.Application.Interfaces
{
    public interface IClienteService
    {

        Task<Cliente> InsereCliente(ClienteRequest cliente);
        Task<Cliente> RetornarCliente(int IdCliente);

        void AlterarCliente(Cliente obj);

        Task DeletaCliente(int IdCliente);
        Task<List<Cliente>> RetornarClientes(string CodEmpresa, string Nome, string Cpf, string idCidade, string UF);
    }
}
