using System;
using GraphQL.Types;

namespace Quarantine.Api.Graphql.Mutations
{
    public partial class RootMutation: ObjectGraphType
    {
        private readonly IServiceProvider _provider;

        public RootMutation(IServiceProvider provider)
        {
            _provider = provider;
            
            RegisterAuthorMutation();
        }
    }
}