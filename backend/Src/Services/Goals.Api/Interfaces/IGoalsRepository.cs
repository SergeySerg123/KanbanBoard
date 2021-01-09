using KanbanBoard.Services.Goals.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.Services.Goals.Api.Interfaces
{
    public interface IGoalsRepository
    {
        Task<IEnumerable<Goal>> GetAll();
        Task<Goal> Get(string id);
        Task Create(Goal goal);
        Task Update(Goal goal);
        Task Delete(string goalId);
    }
}
