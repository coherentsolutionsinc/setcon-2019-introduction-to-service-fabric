using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using JokesApiContracts.Domain.Model;

namespace JokesApi.Services
{
    public interface IJokesService
    {
        Task<JokesLanguageModel> GetLanguageAsync(
            CancellationToken cancellationToken);

        Task<IEnumerable<JokeModel>> GetJokesAsync(
            CancellationToken cancellationToken);

        Task ImportJokesAsync(
            IEnumerable<JokeImportModel> importJokes,
            CancellationToken cancellationToken);
    }
}