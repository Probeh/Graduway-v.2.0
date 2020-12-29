using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Context;
using Shared.Models;

namespace Shared.Interfaces
{
    public interface ITaskRepository : IBaseRepository<EmployeeTask> { }
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;
        // ======================================= //
        public TaskRepository(DataContext context) => _context = context;
        // ======================================= //
        public async Task<EmployeeTask> CreateModel(EmployeeTask model)
        {
            var result = await this._context.Tasks.AddAsync(model);
            await this._context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteModel(int id)
        {
            this._context.Tasks
                .Remove(await this._context.Tasks.FirstOrDefaultAsync(x => x.Id == id));
            await this._context.SaveChangesAsync();
        }
        public async Task<EmployeeTask> UpdateModel(EmployeeTask model)
        {
            var result = this._context.Update(model);
            await this._context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<EmployeeTask> GetModel(int id) =>
            await this._context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<IEnumerable<EmployeeTask>> GetModels(Func<EmployeeTask, bool> predicate) =>
            (await this._context.Tasks.ToListAsync())
            .Where(predicate)
            .OrderBy(x => x.Priority);
        public async Task<IEnumerable<EmployeeTask>> GetModels() =>
            await this._context.Tasks.ToListAsync();
    }
}