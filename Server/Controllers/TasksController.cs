using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Interfaces;
using Shared.Models;

namespace Server.Controllers
{
    public class TasksController : BaseController<EmployeeTask, ITaskRepository>
    {
        // ======================================= //
        private readonly ITaskRepository _repository;
        // ======================================= //
        public TasksController(ITaskRepository repository) : base(repository) => this._repository = repository;
        // ======================================= //

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTasksByEmployee([FromRoute] int id)
        {
            var result = await this._repository.GetModels(x => x.EmployeeId == id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> CreateModel([FromBody] TaskCreateDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await this._repository.CreateModel(new EmployeeTask(model.Title, model.Description, model.EmployeeId, model.Estimate, model.Priority, model.State));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateModel([FromBody] TaskUpdateDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await this._repository.UpdateModel(new EmployeeTask(model.Id, model.Title, model.Description, model.EmployeeId, model.Estimate, model.Priority, model.State));
            return Ok(result);
        }
    }
}