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
    public interface IEntitiesContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        DbEntityEntry Entry(object entry);
        ObjectResult<T> ExecuteProcedureStockee<T>(string nomProcedureStockee, params ObjectParameter[] parameters) where T : class;
        int SaveChanges();
    }
}
