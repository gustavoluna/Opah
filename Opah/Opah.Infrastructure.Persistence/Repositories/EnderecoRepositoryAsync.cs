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
    public class EnderecoRepositoryAsync : GenericRepositoryAsync<Endereco>, IEnderecoRepositoryAsync
    {
        private readonly DbSet<Endereco> _Endereco;

        public EnderecoRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _Endereco = dbContext.Set<Endereco>();
        }

        public async Task<Endereco> RetornarEndereco(int Id)
        {
            return  _Endereco.Where(x => x.IdEndereco == Id).FirstOrDefault();
        }

    }
}
