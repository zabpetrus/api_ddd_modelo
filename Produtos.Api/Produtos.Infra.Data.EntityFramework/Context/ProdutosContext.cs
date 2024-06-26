using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Entities;
using Produtos.Infra.Data.Context;
using System;
using System.Linq;

namespace Produtos.Infra.Data.EntityFramework.Context
{
    public class ProdutosContext : DbContext, IDatabaseContext
    {
        public ProdutosContext(DbContextOptions<ProdutosContext> options)
            : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>(); // Usado pela validação com o Flunt
            //modelBuilder.Ignore<Produto>();

        }

        public override int SaveChanges()
        {
            SetupDateRegisterOnlyAdd("DataInclusao");
            SetupDateRegisterOnlyUpdate("DataAlteracao");
            return base.SaveChanges();
        }

        protected virtual void SetupDateRegisterOnlyAdd(string nameDateField)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(nameDateField) != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(nameDateField).CurrentValue = DateTime.Now;
                }
            }
        }

        protected virtual void SetupDateRegisterOnlyUpdate(string nameDateField)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty(nameDateField) != null))
            {
                if (entry.State == EntityState.Added || entry.State == EntityState.Modified)
                {
                    entry.Property(nameDateField).CurrentValue = DateTime.Now;
                }
            }
        }
    }
}

