using KanbanBoard.Api.Interfaces;
using KanbanBoard.Api.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.Api.Repositories
{
    public class GoalsRepository : IGoalsRepository
    {
        private readonly IMongoCollection<Goal> _goals;

        public GoalsRepository(IGoalstoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _goals = database.GetCollection<Goal>(settings.GoalsCollectionName);
        }

        public async Task<IEnumerable<Goal>> GetAll()
        {
            var goals = await _goals.Find(_ => true).ToListAsync();
            return goals;
        }

        public async Task<Goal> Get(string id)
        {
            var goal = await _goals
                .Find(goal => goal.Id == new BsonObjectId(id))
                .FirstOrDefaultAsync();

            return goal;
        }

        public async Task Create(Goal goal)
        {
            await _goals.InsertOneAsync(goal);
        }

        public async Task Update(Goal goal)
        {
            await _goals.ReplaceOneAsync(g => g.Id == goal.Id, goal);
        }

        public async Task Delete(string goalId)
        {
            await _goals.DeleteOneAsync(g => g.Id == new BsonObjectId(goalId));
        }  
    }
}
