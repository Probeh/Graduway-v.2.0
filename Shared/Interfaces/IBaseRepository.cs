using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.Models;

namespace Shared.Interfaces
{
    public interface IBaseRepository<TSource> where TSource : BaseModel
    {
        // ======================================= //
        //   Base Generic Repository Signatures
        // ======================================= //
        Task<TSource> CreateModel(TSource model);
        Task<TSource> GetModel(int id);
        Task<IEnumerable<TSource>> GetModels();
        Task<IEnumerable<TSource>> GetModels(Func<TSource, bool> predicate);
        Task<TSource> UpdateModel(TSource model);
        Task DeleteModel(int id);
    }
}