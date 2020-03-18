using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TourOfHeroes.Context;
using TourOfHeroes.Models;

namespace TourOfHeroes.Controllers
{
    [ApiController]
    [Route("heroes")]
    public class HeroController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Hero>>> Get([FromServices] HeroContext context)
        {
            var heroes = await context.Heroes.ToListAsync();
            return heroes;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Hero>> GetById(int id, [FromServices] HeroContext context)
        {
            return await context.Heroes.FirstOrDefaultAsync(x => x.Id == id);
        }
        
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Hero>> Put([FromServices] HeroContext context, [FromBody] Hero model)
        {
            context.Heroes.Update(model);
            await context.SaveChangesAsync();
            return model;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Hero>> Post([FromServices] HeroContext context, [FromBody] Hero model)
        {
            if (ModelState.IsValid)
            {
                context.Heroes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Hero>> Delete(int id, [FromServices] HeroContext context)
        {
            var hero = await context.Heroes.FirstOrDefaultAsync(x => x.Id == id);
            context.Heroes.Remove(hero);
            await context.SaveChangesAsync();
            return hero;
        }
    }
}