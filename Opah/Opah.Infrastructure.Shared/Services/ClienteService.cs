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

namespace Opah.Infrastructure.Shared.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _dbContext;

        IClienteRepositoryAsync _clienterepository;
        IEnderecoRepositoryAsync _enderecoRepository;
        IClienteEnderecoRepositoryAsync _clientEenderecoRepositoryAsync;
        IEnderecoService _enderecoService;
        public ILogger<ClienteService> _logger { get; }

        public ClienteService(IClienteRepositoryAsync iclienterepo, IClienteEnderecoRepositoryAsync clienteEnderecoRepositoryAsync, IEnderecoRepositoryAsync enderecoService)
        {
            _clienterepository = iclienterepo;
            _clientEenderecoRepositoryAsync = clienteEnderecoRepositoryAsync;
            _enderecoRepository = enderecoService;

            _dbContext = new ApplicationDbContext();
            
        }

        public ClienteService(IClienteRepositoryAsync clienteRepository, IClienteEnderecoRepositoryAsync clienteEnderecoRepositoryAsync,
            IEnderecoRepositoryAsync enderecoRepository, ILogger<ClienteService> logger,
            ApplicationDbContext dbContext, IEnderecoService enderecoService)
        {
            _clienterepository = clienteRepository;
            _clientEenderecoRepositoryAsync = clienteEnderecoRepositoryAsync;
            _enderecoRepository = enderecoRepository;
            _logger = logger;
            _dbContext = dbContext;
            _enderecoService = enderecoService;
        }

        private Cliente CarregarCliente(ClienteRequest cliente)
        {
            Cliente obj = new Cliente();
            obj.Cod_Empresa = cliente.Cod_Empresa;
            obj.Cpf = cliente.Cpf;
            obj.DataNascimento = cliente.DataNascimento;
            obj.Email = cliente.Email;
            obj.Nome = cliente.Nome;
            obj.RG = cliente.RG;
            obj.Telefone = cliente.Telefone;

            return obj;
        }

        private Endereco CarregaEndereco(ClienteRequest cliente)
        {
            Endereco endereco = new Endereco();

            if (cliente.Endereco != null)
            {
                endereco.Rua = cliente.Endereco.Rua;
                endereco.Bairro = cliente.Endereco.Bairro;
                endereco.Cep = cliente.Endereco.Cep;
                endereco.IdCidade = cliente.Endereco.IdCidade;
                endereco.Complemento = cliente.Endereco.Complemento;
                endereco.Numero = cliente.Endereco.Numero;
                endereco.Tipo_Endereco = cliente.Endereco.Tipo_Endereco;
            }

            return endereco;
        }

        public async Task<Cliente> InsereCliente(ClienteRequest cliente)
        {
            var ret = string.Empty;

            Cliente objCLi = new Cliente();
            objCLi = CarregarCliente(cliente);
            Endereco objEnd = new Endereco();
            objEnd = CarregaEndereco(cliente);


            try
            {
                //var retEnderec = await ValidaEndereco(objCLi, objEnd);
                string validacao = await ValidaCliente(objCLi, objEnd);

                if (string.IsNullOrEmpty(validacao))
                {
                /*    using (var transaction = _dbContext.Database.BeginTransaction())
                    {*/
                        try
                        {
                            objCLi = await _clienterepository.AddAsync(objCLi);
                            var retEndereco = await _enderecoRepository.AddAsync(objEnd);
                            ClienteEndereco ObjCliEnd = new ClienteEndereco();
                            ObjCliEnd.IdEndereco = retEndereco.IdEndereco;
                            ObjCliEnd.IdCliente = objCLi.IdCliente;
                            await _clientEenderecoRepositoryAsync.AddAsync(ObjCliEnd);

                            //transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex.Message, ex);
                            //transaction.Rollback();
                            return null;
                        }
                    }
                //}
                else
                {
                    return null;
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                ret = null;
            }
            return objCLi;
        }

        private async Task<string> ValidaCliente(Cliente obj, Endereco objEnd)
        {
            string ret = string.Empty;

            var retCodEmpresa = await validaCodEmpresaCliente(obj);
            var retCpf = await ValidaCpfCodEmpresa(obj);
            var retEndereco = await ValidaEndereco(obj, objEnd);
            var retTipoEndereco = await validaTipoEndereco(objEnd);

            if (!retCodEmpresa || !retCpf || !retEndereco || !retTipoEndereco)
            {
                if (!retCodEmpresa)
                {
                    ret = "Codigo da Empresa invalido";
                }
                else if (!retCpf)
                {
                    ret = "Cpf já inserido para essa empresa";
                }
                else if (!retEndereco)
                {
                    ret = "Não é possivel inserir mais de um endereco para o mesmo tipo de endereco";
                }
                else if (!retTipoEndereco)
                {
                    ret = "Tipo de endereco invalido";
                }
            }

            return ret;
        }

        private async Task<bool> ValidaEndereco(Cliente obj, Endereco objEnd)
        {
            bool ret = true;
            try
            {
                //ret = await _clientEenderecoRepositoryAsync.ValidarEnderecoCliente(obj.IdCliente, objEnd.Tipo_Endereco);
                ret = await _clientEenderecoRepositoryAsync.ValidarEnderecoCliente(obj.Cpf, objEnd.Tipo_Endereco);

                //
            }
            catch (ApiException ex)
            {
                var a = ex.Message;
            }
            return ret;
        }

        //valida se existe mais de um cpf por codEmpresa
        private async Task<bool> ValidaCpfCodEmpresa(Cliente obj)
        {
            bool ret = true;
            try
            {
                ret = await _clienterepository.RetornarCpfCadastrado(obj.Cpf, obj.Cod_Empresa);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }


            return ret;
        }

        private async Task<bool> validaCodEmpresaCliente(Cliente obj)
        {
            bool ret = true;

            if (obj.Cod_Empresa != "1" && obj.Cod_Empresa != "2")
                ret = false;

            return ret;
        }

        private async Task<bool> validaTipoEndereco(Endereco obj)
        {
            bool ret = true;

            if (obj.Tipo_Endereco != "1" && obj.Tipo_Endereco != "2" && obj.Tipo_Endereco != "3")
                ret = false;

            return ret;
        }

        public void AlterarCliente(Cliente obj)
        {

            try
            {
                var result = _clienterepository.GetByIdAsync(obj.IdCliente).Result;

                if (result != null)
                    //_clienterepository.AtualizaCliente(obj);
                    _clienterepository.UpdateAsync(obj);


            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException("Ocorreu um erro ao atualizar o Cliente");
            }
        }

        public Task<Cliente> RetornarCliente(int IdCliente)
        {
            try
            {
                return _clienterepository.GetByIdAsync(IdCliente);
            }
            catch (System.Exception ex)
            {
                //_logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
        }

        public async Task DeletaCliente(int IdCliente)
        {
            try
            {
                var cli = await _clienterepository.GetByIdAsync(IdCliente);
                await _clienterepository.DeleteAsync(cli);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }

        }

      
        public async Task<List<Cliente>> RetornarClientes(string CodEmpresa, string Nome, string Cpf, string idCidade, string UF)
        {
            List<Cliente> cli = new List<Cliente>();

            try
            {
                cli=  await  _clienterepository.RetornarClientes(CodEmpresa, Nome, Cpf, idCidade, UF);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                throw new ApiException(ex.Message);
            }
            return cli;
        }
    }
}
