using System;
using System.Threading.Tasks;
using Leaderboard.Models;

namespace Leaderboard
{
    public interface IRepository
    {
        Task<Player> Create(Player player);
        Task<Player[]> GetAll();
        Task<Player> DeletePlayer(Guid id);
        Task<Player> GetPlayer(int placement);
        Task<Player> GetName(string name);
    }
}
