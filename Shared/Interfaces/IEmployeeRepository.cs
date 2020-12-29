using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared.Context;
using Shared.Models;

namespace Shared.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee> { }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        // ======================================= //
        public EmployeeRepository(DataContext context) => _context = context;
        // ======================================= //
        public async Task<Employee> CreateModel(Employee model)
        {
            var result = await this._context.Employees.AddAsync(model);
            await this._context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task DeleteModel(int id)
        {
            this._context.Employees
                .Remove(await this._context.Employees.FirstOrDefaultAsync(x => x.Id == id));
            await this._context.SaveChangesAsync();
        }
        public async Task<Employee> UpdateModel(Employee model)
        {
            var result = this._context.Update(model);
            await this._context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Employee> GetModel(int id) =>
            await this._context.Employees.FirstOrDefaultAsync(x => x.Id == id);
        public async Task<IEnumerable<Employee>> GetModels(Func<Employee, bool> predicate) =>
            (await this._context.Employees.ToListAsync())
            .Where(predicate)
            .OrderBy(x => x.Title);
        public async Task<IEnumerable<Employee>> GetModels() =>
            await this._context.Employees
            .OrderBy(x => x.Title)
            .ToListAsync();
    }
}