using Opah.Application.Exceptions;
using Opah.Application.Interfaces.Repositories;
using Opah.Application.Wrappers;
using Opah.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Opah.Application.Features.Clientes.Queries.RetornarCliente
{
    public class RetornarClientePorIdQuery : IRequest<Response<Cliente>>
    {
        public int Id { get; set; }
        public class RetornarClientePorIdHandler : IRequestHandler<RetornarClientePorIdQuery, Response<Cliente>>
        {
            private readonly IClienteRepositoryAsync _ClienteRepository;
            public RetornarClientePorIdHandler(IClienteRepositoryAsync clienteRepository)
            {
                _ClienteRepository = clienteRepository;
            }
            public async Task<Response<Cliente>> Handle(RetornarClientePorIdQuery query, CancellationToken cancellationToken)
            {
                var cliente = await _ClienteRepository.GetByIdAsync(query.Id);
                if (cliente == null) throw new ApiException($"Cliente nao encontrado.");
                return new Response<Cliente>(cliente);
            }
        }
    }
}
