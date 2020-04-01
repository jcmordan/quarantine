using System;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using Quarantine.Api.Graphql.Types;
using Quarantine.Api.Graphql.Types.Inputs;
using Quarantine.Core.Models;
using Quarantine.Core.Services;

namespace Quarantine.Api.Graphql.Mutations
{
    public partial class RootMutation
    {
        private void RegisterAuthorMutation()
        {
            FieldAsync<AuthorGraphType>(
                "addAuthor",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<AuthorInputGraphType>> {Name = "author"}
                ),
                resolve: async context =>
                {
                    var author = context.GetArgument<Author>("author");
                    var authorService = _provider.GetRequiredService<AuthorService>();
                    return await authorService.AddAsync(author);
                }
            );
        }
    }
}