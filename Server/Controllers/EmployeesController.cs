using Shared.Interfaces;
using Shared.Models;

namespace Server.Controllers
{
    public class EmployeesController : BaseController<Employee, IEmployeeRepository>
    {
        // ======================================= //
        private readonly IEmployeeRepository _repository;
        // ======================================= //
        public EmployeesController(IEmployeeRepository repository) : base(repository) => this._repository = repository;
        // ======================================= //
    }
}