using GraphQL.Types;
using Quarantine.Core.Models;

namespace Quarantine.Api.Graphql.Types
{
    public class AuthorGraphType : ObjectGraphType<Author>
    {
        public AuthorGraphType()
        {
            Name = "Author";

            Field(a => a.Id, type: typeof(IdGraphType))
                .Description("Author Id");

            Field(a => a.FirstName).Description("Author's first name");
            Field(a => a.LastName).Description("Author's last name");
            Field(a => a.Pseudonym).Description("Author's last pseudonym");
            Field(a => a.IdentificationNumber, type: typeof(IdentificationNumberGraphType))
                .Description("Author's identification number");
            //
            // Field(a => a.IdentificationNumber)
            //     .Description("Author's identification number");
            //
            Field(a => a.DateOfBirth).Description("Author's date of birth");
        }
    }
}