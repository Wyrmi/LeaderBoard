using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Leaderboard.Models;
using System.Linq;
using System.Collections.Generic;

namespace Leaderboard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController
    {
        private readonly PlayersProcessor _context;
        public PlayerController(PlayersProcessor context){
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public Task<Player[]> GetAll(){
            return _context.GetAll();
        }
        [HttpPost]
        [Route("")]
        public Task<Player> Create(NewPlayer player){
            return _context.Create(player);
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public Task<Player> DeletePlayer(Guid id){
            return _context.DeletePlayer(id);
        }
        [HttpGet]
        [Route("{place}")]
        public Task<Player> GetPlayer(int place){
            return _context.GetPlayer(place);
        }
        [HttpGet]
        [Route("{name}")] 
        public Task<Player> GetName(string name) {
            return _context.GetName(name);
        }
    }
}
