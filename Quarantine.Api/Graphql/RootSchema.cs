using System;
using GraphQL.Types;
using GraphQL.Utilities;
using Quarantine.Api.Graphql.Mutations;
using Quarantine.Api.Graphql.Queries;

namespace Quarantine.Api.Graphql
{
    public class RootSchema: Schema
    {
        public RootSchema(IServiceProvider provider): base(provider)
        {
            Query = provider.GetRequiredService<RootQuery>();
            Mutation = provider.GetRequiredService<RootMutation>();
        }
    }
}