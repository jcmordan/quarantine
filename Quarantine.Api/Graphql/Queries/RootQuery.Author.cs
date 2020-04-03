using GraphQL.Types;
using GraphQL.Utilities;
using Quarantine.Api.Graphql.Types;
using Quarantine.Core.Services;

namespace Quarantine.Api.Graphql.Queries
{
    public partial class RootQuery
    {
        private void RegisterAuthorQuery()
        {
            FieldAsync<ListGraphType<AuthorGraphType>>("authors",
                resolve: async context =>
                {
                    var authorService = _provider.GetRequiredService<AuthorService>();

                    return await authorService.GetAllAsync();
                }
            );
        }
    }
}