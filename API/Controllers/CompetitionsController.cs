using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Application.Competitions;

namespace API.Controllers
{
    public class CompetitionsController : BaseApiController
    {


        [HttpGet]
        public async Task<ActionResult<List<Competition>>> GetCompetitions()
        {
            return await Mediator.Send(new List.Query());
        }
        [HttpGet("{id}")] //competition/id
        public async Task<ActionResult<Competition>> GetCompetition(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});

        }
        [HttpPost]
        public async Task<IActionResult> CreateCompetition(Competition competition)
        {
            return Ok(await Mediator.Send(new Create.Command {Competition = competition}));

        }

        [HttpPut("{id}")]

        public async Task<IActionResult> EditCompetition(Guid id, Competition competition)
        {
            competition.Id = id;

            return Ok(await Mediator.Send(new Edit.Command{Competition = competition}));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteCompetition(Guid id)
        {
            
            return Ok(await Mediator.Send(new Delete.Command{Id =id}));

        }




    }
}