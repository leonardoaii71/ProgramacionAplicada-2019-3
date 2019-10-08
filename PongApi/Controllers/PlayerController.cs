using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PongApi.Models;

namespace PongApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerContext _context;

        public PlayerController(PlayerContext context)
        {
            _context = context;
        }

        // GET: api/players/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> getPlayerItem(long id)
        {
            var todoItem = await _context.Players.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return null;
        }

    }
}