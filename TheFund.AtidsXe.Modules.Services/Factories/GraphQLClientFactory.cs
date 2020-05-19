using Ensure;
using GraphQL.Client;

namespace TheFund.AtidsXe.Modules.Services.Factories
{
    public static class GraphQLClientFactory
    {
        public static GraphQLClient Create(string endPointAddress, params (string, string)[] headers)
        {
            endPointAddress.EnsureNotNullOrWhitespace(nameof(endPointAddress));

            var client = new GraphQLClient(endPointAddress);

            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Item1, header.Item2);
            }

            return client;
        }
    }
}