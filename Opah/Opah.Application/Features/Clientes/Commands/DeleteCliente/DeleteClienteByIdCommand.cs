using Opah.Application.Exceptions;
using Opah.Application.Interfaces.Repositories;
using Opah.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Opah.Application.Features.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteClienteByIdCommandHandler : IRequestHandler<DeleteClienteByIdCommand, Response<int>>
        {
            private readonly IClienteRepositoryAsync _clienteRepository;
            private readonly IClienteEnderecoRepositoryAsync _clienteEnderecoRepository;
            private readonly IEnderecoRepositoryAsync _EnderecoRepository;
            public DeleteClienteByIdCommandHandler(IClienteRepositoryAsync clienteRepository, IClienteEnderecoRepositoryAsync clienteEnderecoRepository,
                                                        IEnderecoRepositoryAsync EnderecoRepository)
            {
                _clienteRepository = clienteRepository;
                _clienteEnderecoRepository = clienteEnderecoRepository;
                _EnderecoRepository = EnderecoRepository;
            }
            public async Task<Response<int>> Handle(DeleteClienteByIdCommand command, CancellationToken cancellationToken)
            {
                var cli = await _clienteRepository.GetByIdAsync(command.Id);
                await _clienteRepository.DeleteAsync(cli);               
                return new Response<int>(1);
            }
        }
    }
}
