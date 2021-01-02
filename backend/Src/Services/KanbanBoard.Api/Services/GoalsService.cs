using EventBus.Base.Standard;
using KanbanBoard.Api.DTO;
using KanbanBoard.Api.Interfaces;
using KanbanBoard.Api.Models;
using KanbanBoard.Services.Goals.Api.IntegrationEvents.Events;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.Api.Services
{
    public class GoalsService
    {
        private readonly IGoalsRepository _goalsRepository;
        private readonly IEventBus _eventBus;

        public GoalsService(IEventBus eventBus, IGoalsRepository goalsRepository)
        {
            _eventBus = eventBus;
            _goalsRepository = goalsRepository;
        }

        public async Task<IEnumerable<Goal>> GetAll()
        {
            var goals = await _goalsRepository.GetAll();
            return goals;
        }

        public async Task<Goal> Get(string id)
        {
            var goal = await _goalsRepository.Get(id);

            return goal;
        }

        public async Task Create(string authorId, GoalDTO goalDto)
        {
            var newGoal = new Goal
            {
                Name = goal.Name,
                Description = goal.Description,
                //Author = authorId
            };
            await _goalsRepository.Create(newGoal);
            
            var message = new CreatedGoalIntegrationEvent(newGoal.Name, newGoal.Description, authorId, "sergey_chizhik@ukr.net");
            _eventBus.Publish(message);
        }

        public async Task Update(GoalDTO goalDto)
        {
            await _goalsRepository.Update(goal);
        }

        public async Task Delete(string goalId)
        {
            await _goalsRepository.Delete(goalId);
        }
    }
}
