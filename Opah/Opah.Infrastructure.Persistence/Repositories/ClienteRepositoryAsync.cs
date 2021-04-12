using Opah.Application.Interfaces.Repositories;
using Opah.Domain.Entities;
using Opah.Infrastructure.Persistence.Contexts;
using Opah.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Opah.Application.Interfaces;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace Opah.Infrastructure.Persistence.Repositories
{
    public class ClienteRepositoryAsync : GenericRepositoryAsync<Cliente>, IClienteRepositoryAsync
    {
    
        private readonly DbSet<Cliente> _cliente;
        IConfiguration _configuration;

        public ClienteRepositoryAsync(ApplicationDbContext dbContext, IConfiguration configuration) : base(dbContext)
        {
            _cliente = dbContext.Set<Cliente>();
            _configuration = configuration;
        }

        public string GetConnection()
        {
            var connection = _configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return connection;
        }

        public async void AtualizaCliente(Cliente cliente)
        {
            //_cliente.Update(cliente);            
            base.UpdateAsync(cliente);
        }

        public async Task<Cliente> InsereCliente(Cliente cliente)
        {
            var a = await base.AddAsync(cliente);
            return a;
        }



        public async Task<Cliente> RetornarCliente(int IdCliente)
        {
            return await _cliente.FindAsync(IdCliente);
        }


        public async Task<bool> RetornarCpfCadastrado(string Cpf, string CodEmpresa)
        {
            bool retorno = true;
            try
            {
                
                var ret = _cliente.Where(x => x.Cpf == Cpf && x.Cod_Empresa == CodEmpresa).ToList();
                //var ret = await this.GetAllAsync(x => x.Cpf == Cpf && x.Cod_Empresa == CodEmpresa);
                //.GetAllAsync(x => x.Cpf == Cpf && x.Cod_Empresa == CodEmpresa);
                if (ret.Count > 0)
                    retorno = false;
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }


            //var ret = await _cliente.AllAsync(x => x.Cpf.Equals(Cpf) &&
            //(x.Cod_Empresa.Equals(CodEmpresa)));
            //if (ret)
            //    retorno = false;


            return retorno;
        }


        public async Task<List<Cliente>> RetornarClientes(string CodEmpresa, string Nome, string Cpf, string idCidade, string UF)
        {
            var connectionString = this.GetConnection();
            List<Cliente> clientes = new List<Cliente>();
            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    var query = @"SELECT c.IdCliente
                                  , c.Nome
                                  ,RG
                                  ,Cpf
                                  ,DataNascimento
                                  ,Telefone
                                  ,Email
                                  ,Cod_Empresa
                                  FROM Carregour.dbo.Clientes c
                                  inner join Carregour.dbo.ClienteEndereco ce on c.IdCliente = ce.idCliente
                                  inner join Carregour.dbo.Enderecos e on ce.IdEndereco = e.IdEndereco
                                  inner join Carregour.dbo.Cidade ci on e.IdCidade = ci.IdCidade
                                  where c.Cod_Empresa = @CodEmpresa
                                  and c.Nome = ISNULL(@Nome, c.Nome)
                                  and c.CPF = ISNULL(@Cpf, c.Cpf)
                                  and e.IdCidade = ISNULL(@idCidade, e.IdCidade)
                                  and ci.Estado = ISNULL(@UF, ci.Estado)";
                    clientes = con.Query<Cliente>(query, new { CodEmpresa = CodEmpresa, Nome = Nome, Cpf = Cpf, idCidade = idCidade, UF = UF }).ToList();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
                return clientes;
            }
        }

    }
}
