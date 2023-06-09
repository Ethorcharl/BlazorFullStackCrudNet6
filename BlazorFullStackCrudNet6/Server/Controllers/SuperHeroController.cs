﻿using BlazorFullStackCrudNet6.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorFullStackCrudNet6.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        public static List<Comic> comics = new List<Comic> {
            new Comic{ Id=1,Name = "Marvel"},
            new Comic{ Id=2,Name = "DC"}
        };
        public static List<SuperHero> heroes = new List<SuperHero> {
            new SuperHero{
                Id=1,
                FirstName = "Peter",
                LastName="Parker",
                HeroName="Spiderman",
                Comic=comics[0],
                ComicId=1
            },
            new SuperHero{ Id=2,
                FirstName = "Bruce",
                LastName="Wayne",
                HeroName="Batmab",
                Comic=comics[1],
                ComicId=2
            },
        };

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes() {

            return Ok(heroes);
        }

        [HttpGet("comics")]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            return Ok(comics);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetSingleHero(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null) {
                return NotFound("Sorry, no hero here. :/");
            }
            return Ok(hero);
        }
    }
}
