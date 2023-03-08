using MediatR;
using Microsoft.AspNetCore.Mvc;
using SWAPI.Models;
using SWAPI.Services;

namespace SWAPI.Controllers
{

    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly IStarWarsMovie _starwarmovie;
        public CharactersController(IStarWarsMovie starwarmovie)
        {
            _starwarmovie = starwarmovie;
        }

        [ResponseCache(Duration = 3600)]
        [Route("swapi/public/characters")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ResponseSW>>> Characters(int Pagenumber)
        {
            var jsonresult = await _starwarmovie.GetPublicStarWarsMovie(Pagenumber);
            return Ok(jsonresult);
        }

        [Route("swapi/protected/download")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResponseDownload>>> Download(int Pagenumber)
        {
            var jsonresult = await _starwarmovie.GetProtectedStarWarsMovie(Pagenumber);
            return Ok(jsonresult);
        }
    }
}