using Opah.Application.DTOs;
using Opah.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Opah.Application.Interfaces
{
    public interface IEnderecoService
    {
        Task DeletaEndereco(IList<ClienteEndereco> obj);
    }
}
