using ProvaConceito.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProvaConceito.Interfaces
{
    public interface IAsyncRepository<T> : IDisposable where T : BaseEntity
    {
        Task<IEnumerable<T>> BuscaAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> ListaAsync();
        Task<T> BuscaPorIdAsync(int id);
        Task IncluiAsync(T inObj);
        Task AlteraAsync(T inObj);
    }

    public interface IAsyncRepository<T, U> : IDisposable where T : BaseEntity
    {

    }
}
