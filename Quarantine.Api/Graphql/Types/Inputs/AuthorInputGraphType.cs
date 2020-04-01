using GraphQL.Types;
using Quarantine.Core.Models;

namespace Quarantine.Api.Graphql.Types.Inputs
{
    public class AuthorInputGraphType: InputObjectGraphType<Author>
    {
        public AuthorInputGraphType()
        {
            Name = "AuthorInput";

            Field(a => a.Id, type: typeof(IdGraphType)).Description("Author Id");
            Field(a => a.FirstName, type: typeof(NonNullGraphType<StringGraphType>));
            Field(a => a.LastName, type: typeof(NonNullGraphType<StringGraphType>));
            Field(a => a.IdentificationNumber, type: typeof(StringGraphType));
            Field(a => a.Pseudonym, type: typeof(StringGraphType));
            Field(a => a.DateOfBirth);
        }
    }
}