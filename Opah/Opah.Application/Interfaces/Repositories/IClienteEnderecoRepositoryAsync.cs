using Opah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Opah.Application.Interfaces.Repositories
{
    public interface IClienteEnderecoRepositoryAsync : IGenericRepositoryAsync<ClienteEndereco>
    {
        Task<List<ClienteEndereco>> RetornarEnderecoPorCliente(string IdCliente);

        void Adicionar(ClienteEndereco clienteEndereco);
        Task<bool> ValidarEnderecoCliente(string cpf, string TipoEndereco);
        
    }
}
