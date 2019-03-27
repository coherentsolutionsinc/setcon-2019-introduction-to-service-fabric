using System.Collections.Generic;
using System.Threading.Tasks;

using JokesApi.Services;

using JokesApiContracts.Domain.Model;

using Microsoft.AspNetCore.Mvc;

namespace JokesApi.Controllers
{
    [Route("api/jokes")]
    public class JokesController : Controller
    {
        private readonly IJokesService service;

        public JokesController(
            IJokesService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public async Task<IEnumerable<JokeModel>> GetJokesAsync()
        {
            return await this.service.GetJokesAsync(this.HttpContext.RequestAborted);
        }

        [HttpGet("language")]
        public async Task<JokesLanguageModel> GetLanguageAsync()
        {
            return await this.service.GetLanguageAsync(this.HttpContext.RequestAborted);
        }

        [HttpPost("import")]
        public async Task ImportJokesAsync(
            [FromBody] IEnumerable<JokeImportModel> importJokes)
        {
            await this.service.ImportJokesAsync(importJokes, this.HttpContext.RequestAborted);
        }
    }
}