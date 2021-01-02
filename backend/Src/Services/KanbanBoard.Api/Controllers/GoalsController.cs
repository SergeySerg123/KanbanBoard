using System.Threading.Tasks;
using KanbanBoard.Api.DTO;
using KanbanBoard.Api.Extensions;
using KanbanBoard.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KanbanBoard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
            var goals = await _goalsService.GetAll();
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
        public async Task<IActionResult> Post([FromBody] GoalDTO goalDto)
        {
            var authorId = this.GetUserIdFromToken();
            await _goalsService.Create(authorId, goalDto);
            return Ok();
        }

        // PUT: api/Goals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] GoalDTO goalDto)
        {
            await _goalsService.Update(goalDto);
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
