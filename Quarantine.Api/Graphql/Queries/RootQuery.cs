using System;
using GraphQL.Types;

namespace Quarantine.Api.Graphql.Queries
{
    public partial class RootQuery: ObjectGraphType
    {
        private readonly IServiceProvider _provider;

        public RootQuery(IServiceProvider provider)
        {
            _provider = provider;
            Name = "Query";
            
            RegisterAuthorQuery();
        }
    }
}