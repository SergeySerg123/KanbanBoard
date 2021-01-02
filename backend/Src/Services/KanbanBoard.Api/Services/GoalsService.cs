using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;
        private readonly IGoalsRepository _goalsRepository;
       
        public GoalsService(IMapper mapper, IEventBus eventBus, IGoalsRepository goalsRepository)
        {
            _mapper = mapper;
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

        public async Task Create(GoalDTO goalDto)
        {
            var goal = _mapper.Map<Goal>(goalDto);
            var newGoal = new Goal
            {
                Name = goal.Name,
                Description = goal.Description,
                AuthorId = goal.AuthorId,
                BoardId = goal.BoardId
            };
            await _goalsRepository.Create(newGoal);
            
            var message = new CreatedGoalIntegrationEvent(newGoal.Name, newGoal.Description, newGoal.AuthorId.ToString(), "sergey_chizhik@ukr.net");
            _eventBus.Publish(message);
        }

        public async Task Update(GoalDTO goalDto)
        {
            var goal = _mapper.Map<Goal>(goalDto);
            await _goalsRepository.Update(goal);
        }

        public async Task Delete(string goalId)
        {
            await _goalsRepository.Delete(goalId);
        }
    }
}
