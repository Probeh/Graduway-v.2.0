using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Interfaces;
using Shared.Models;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TSource, TRepository> : ControllerBase where TSource : BaseModel where TRepository : IBaseRepository<TSource>
    {
        // ======================================= //
        private readonly TRepository _repository;
        // ======================================= //
        public BaseController(TRepository repository) => this._repository = repository;
        // ======================================= //
        [HttpGet]
        public virtual async Task<IActionResult> GetModels()
        {
            var result = await this._repository.GetModels();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> DeleteModel([FromRoute] int id)
        {
            await this._repository.DeleteModel(id);
            return Ok();
        }
    }
}