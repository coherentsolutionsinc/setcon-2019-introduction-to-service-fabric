using System;
using System.Fabric;
using System.Threading;
using System.Threading.Tasks;

using JokesStats.Interfaces;

using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace JokesWeb.Clients
{
    public class FabricJokesStatsClient : IJokesStatsClient
    {
        private readonly StatelessServiceContext context;

        public FabricJokesStatsClient(
            StatelessServiceContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<JokesStatistics> IncrementViewedAndGetStatisticsAsync(
            string user,
            string language,
            string category,
            CancellationToken cancellationToken)
        {
            var actor = ActorProxy.Create<IJokesStats>(
                new ActorId($"{user}/{language}/{category}"),
                new Uri($"{this.context.CodePackageActivationContext.ApplicationName}/JokesStatsActorService"));

            await actor.IncrementViewed(cancellationToken);

            return await actor.GetAsync(cancellationToken);
        }
    }
}