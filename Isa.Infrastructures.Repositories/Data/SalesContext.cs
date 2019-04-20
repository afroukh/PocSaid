using Isa.Core.Repositories.EntityModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isa.Infrastructures.Repositories.Data
{
    public class SalesContext : DbContext, IEntitiesContext
    {

        
        public DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Client> Clients { get; set; }


        public SalesContext()
            : base("name=SalesContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<SalesContext>(null);
           
            //modelBuilder.Entity<Cours>().ToTable("Cours");
            //modelBuilder.Entity<Etudiant>().ToTable("Etudiant");
            //modelBuilder.Entity<CoursPasses>().ToTable("CoursPasses");
        }
        public ObjectResult<T> ExecuteProcedureStockee<T>(string nomProcedureStockee, params ObjectParameter[] parameters) where T : class
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<T>(nomProcedureStockee, parameters);
        }
    }
}
