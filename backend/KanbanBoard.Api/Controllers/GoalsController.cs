using System.Threading.Tasks;
using KanbanBoard.Api.Extensions;
using KanbanBoard.Api.Models;
using KanbanBoard.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class GoalsController : ControllerBase
    {
        private readonly GoalsService _goalsService;

        public GoalsController(GoalsService goalsService)
        {
            _goalsService = goalsService;
        }

        // GET: api/Goals
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authorId = this.GetUserIdFromToken();
            var goals = await _goalsService.GetAll(authorId);
            return Ok(goals);
        }

        // GET: api/Goals/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var goal = await _goalsService.Get(id);
            return Ok(goal);
        }

        // POST: api/Goals
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Goal goal)
        {
            var authorId = this.GetUserIdFromToken();
            await _goalsService.Create(authorId, goal);
            return Ok();
        }

        // PUT: api/Goals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Goal goal)
        {
            await _goalsService.Update(goal);
            return NoContent();
        }

        // DELETE: api/Goals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _goalsService.Delete(id);
            return NoContent();
        }
    }
}
