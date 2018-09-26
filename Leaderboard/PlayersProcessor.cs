using System;
using System.Threading.Tasks;
using Leaderboard.Models;

namespace Leaderboard
{
    public class PlayersProcessor
    {
        private IRepository _repository;

        public PlayersProcessor(IRepository Repository){
            _repository = Repository;
        }
        public async Task<Player> Create (NewPlayer player){
            Player plr = new Player();
            plr.Id = Guid.NewGuid();
            plr.Name = player.Name;
            plr.Score = player.Score;
            await _repository.Create(plr);
            return plr;
        }
        public Task<Player[]> GetAll(){
            return _repository.GetAll();
        }
        public Task<Player> DeletePlayer(Guid id){
            return _repository.DeletePlayer(id);
        }
        public Task<Player> GetPlayer(int placement){
            return _repository.GetPlayer(placement);
        }
    }
}