using Opah.Application.DTOs.Email;
using Opah.Application.Exceptions;
using Opah.Application.Interfaces;
using Opah.Application.DTOs;
using Opah.Domain.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Threading.Tasks;
using Opah.Application.Interfaces.Repositories;
using Opah.Domain.Entities;
using System.Collections.Generic;
using Opah.Infrastructure.Persistence.Contexts;
using System;
using Opah.Infrastructure.Persistence.Repositories;

namespace Opah.Infrastructure.Shared.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly ApplicationDbContext _dbContext;


        IEnderecoRepositoryAsync _enderecoRepository;

        public ILogger<ClienteService> _logger { get; }

        public EnderecoService(IEnderecoRepositoryAsync enderecoRepository, ILogger<ClienteService> logger,
                                    ApplicationDbContext dbContext)
        {

            _enderecoRepository = enderecoRepository;
            _logger = logger;
            _dbContext = dbContext;
        }


        public async Task DeletaEndereco(IList<ClienteEndereco> obj)
        {
            try
            {
                foreach (var item in obj)
                {
                    Endereco end = new Endereco();

                    
                    end = await _enderecoRepository.RetornarEndereco(item.IdEndereco);

                    _enderecoRepository.DeleteAsync(end);
                }                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }
    }

}
