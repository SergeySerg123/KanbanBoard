using KanbanBoard.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KanbanBoard.Api.Interfaces
{
    public interface IGoalsRepository
    {
        Task<IEnumerable<Goal>> GetAll(string authorId);
        Task<Goal> Get(string id);
        Task Create(Goal goal);
        Task Update(Goal goal);
        Task Delete(string goalId);
    }
}
