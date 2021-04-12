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


namespace Opah.Infrastructure.Persistence.Repositories
{
    public class CidadeRepositoryAsync : GenericRepositoryAsync<Cidade>, ICidadeRepositoryAsync
    {
        private readonly DbSet<Cidade> _cidade;

        public CidadeRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _cidade = dbContext.Set<Cidade>();
        }

        public Task<Cliente> ObterCidade(string IdCidade)
        {
            throw new NotImplementedException();
        }
    }
}
