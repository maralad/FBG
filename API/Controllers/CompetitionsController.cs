using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class CompetitionsController : BaseApiController
    {
        
        private readonly DataContext _context;
        public CompetitionsController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Competition>>> GetCompetitions()
        {
            return await _context.Competitions.ToListAsync();
        }
        [HttpGet("{id}")] //competition/id
        public async Task<ActionResult<Competition>> GetCompetition(Guid id)
        {
            return await _context.Competitions.FindAsync(id);

        }



    }
}