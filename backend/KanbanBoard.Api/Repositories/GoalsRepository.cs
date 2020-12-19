using KanbanBoard.Api.Interfaces;
using KanbanBoard.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.Api.Repositories
{
    public class GoalsRepository : IGoalsRepository
    {
        private readonly GoalDbContext _dbContext;

        public GoalsRepository(GoalDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(Goal goal)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string goalId)
        {
            throw new System.NotImplementedException();
        }

        public Task<Goal> Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Goal>> GetAll(string authorId)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Goal goal)
        {
            throw new System.NotImplementedException();
        }
    }
}
