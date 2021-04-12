using Opah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Opah.Application.Interfaces.Repositories
{
    public interface ICidadeRepositoryAsync : IGenericRepositoryAsync<Cidade>
    {
        Task<Cliente> ObterCidade(string IdCidade);
    }
}
