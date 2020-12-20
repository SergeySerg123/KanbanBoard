using KanbanBoard.Api.Interfaces;
using KanbanBoard.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.Api.Services
{
    public class GoalsService
    {
        private readonly IGoalsRepository _goalsRepository;

        public GoalsService(IGoalsRepository goalsRepository)
        {
            _goalsRepository = goalsRepository;
        }

        public async Task<IEnumerable<Goal>> GetAll(string authorId)
        {
            var goals = await _goalsRepository.GetAll(authorId);
            return goals;
        }

        public async Task<Goal> Get(string id)
        {
            var goal = await _goalsRepository.Get(id);

            return goal;
        }

        public async Task Create(Goal goal)
        {
            await _goalsRepository.Create(goal);
        }

        public async Task Update(Goal goal)
        {
            await _goalsRepository.Update(goal);
        }

        public async Task Delete(string goalId)
        {
            await _goalsRepository.Delete(goalId);
        }
    }
}
