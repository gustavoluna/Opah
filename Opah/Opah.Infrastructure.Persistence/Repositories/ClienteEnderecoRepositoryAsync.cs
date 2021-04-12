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


namespace Opah.Infrastructure.Persistence.Repositories
{
    public class ClienteEnderecoRepositoryAsync : GenericRepositoryAsync<ClienteEndereco>, IClienteEnderecoRepositoryAsync
    {
        private DbSet<ClienteEndereco> _ClienteEndereco;
        private DbSet<Cliente> _cliente;
        private DbSet<Endereco> _endereco;
        private ApplicationDbContext _dbContext;

        public ClienteEnderecoRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _ClienteEndereco = dbContext.Set<ClienteEndereco>();
            _cliente = dbContext.Set<Cliente>();
            _endereco = dbContext.Set<Endereco>();
            _dbContext = dbContext;
        }

        public void Adicionar(ClienteEndereco clienteEndereco)
        {
            _ClienteEndereco.AddAsync(clienteEndereco);
        }


        public async Task<List<ClienteEndereco>> RetornarEnderecoPorCliente(string IdCliente)
        {
            var ret = _ClienteEndereco.ToListAsync().Result.Where(x => x.IdCliente.Equals(IdCliente)).ToList();
            return ret;
        }

        public async Task<bool> ValidarEnderecoCliente(string cpf, string TipoEndereco)
        {
            bool ret = true;
            try
            {
                var validacao = (from f in _dbContext.ClienteEndereco
                                 join c in _dbContext.Enderecos                                 
                                 on f.IdEndereco equals c.IdEndereco
                                 join cli in _dbContext.Clientes
                                 on f.IdCliente equals cli.IdCliente
                                 where cli.Cpf.Equals(cpf) && c.Tipo_Endereco.Equals(TipoEndereco)
                                 select f.IdCliente
                              ).ToList();

                //var validacao = _ClienteEndereco.AsQueryable()
                //    .Include(x => x.Clientes)
                //    .Include(x => x.Enderecos)
                //.ToList();
                //.Where(x => x.Clientes.IdCliente == IdCliente && x.Enderecos.Tipo_Endereco == TipoEndereco).ToList();



                if (validacao.Count > 0)
                    ret = false;

            }
            catch (Exception ex)
            {
                var a = ex.Message;
                return false;
            }
            return ret;
        }
    }
}
