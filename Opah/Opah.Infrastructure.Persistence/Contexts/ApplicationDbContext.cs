using Opah.Application.Interfaces;
using Opah.Domain.Common;
using Opah.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Opah.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IAuthenticatedUserService _authenticatedUser;

        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IDateTimeService dateTime, IAuthenticatedUserService authenticatedUser) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _authenticatedUser = authenticatedUser;
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteEndereco> ClienteEndereco { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cidade> Cidade { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            //{
            //switch (entry.State)
            //{
            //    case EntityState.Added:
            //        entry.Entity.Created = _dateTime.NowUtc;
            //        entry.Entity.CreatedBy = _authenticatedUser.UserId;
            //        break;
            //    case EntityState.Modified:
            //        entry.Entity.LastModified = _dateTime.NowUtc;
            //        entry.Entity.LastModifiedBy = _authenticatedUser.UserId;
            //        break;
            //}
            //}
            return base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ClienteEndereco>()
         .HasKey(bc => new { bc.IdClienteEndereco });
            modelBuilder.Entity<ClienteEndereco>()
                .HasOne(bc => bc.Clientes)
                .WithMany(b => b.ClienteEnderecos)
                .HasForeignKey(bc => bc.IdCliente)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ClienteEndereco>()
                .HasOne(bc => bc.Enderecos)
                .WithMany(c => c.ClienteEnderecos)
                .HasForeignKey(bc => bc.IdEndereco)
                .OnDelete(DeleteBehavior.Cascade);

            //All Decimals will have 18,6 Range
            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,6)");
            }
            //base.OnModelCreating(builder);



        }
    }
}
