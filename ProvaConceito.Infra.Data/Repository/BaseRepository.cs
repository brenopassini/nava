using AspnetCore_EFCoreInMemory.Models;
using Microsoft.EntityFrameworkCore;
using ProvaConceito.Entities;
using ProvaConceito.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Suporte.Infra.Data.Repository
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : BaseEntity, new()
    {
        protected readonly SqlServerDbContext Db;
        protected readonly DbSet<T> DbSet;

        public BaseRepository(SqlServerDbContext db)
        {
            Db = db;
            DbSet = db.Set<T>();
        }

        public async Task<IEnumerable<T>> BuscaAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListaAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> BuscaPorIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task IncluiAsync(T inObj)
        {
            DbSet.Add(inObj);
            await SaveChanges();
        }

        public async Task AlteraAsync(T inObj)
        {
            DbSet.Update(inObj);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }

}
