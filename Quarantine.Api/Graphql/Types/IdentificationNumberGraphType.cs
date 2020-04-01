using GraphQL.Language.AST;
using GraphQL.Types;

namespace Quarantine.Api.Graphql.Types
{
    public class IdentificationNumberGraphType: ScalarGraphType
    {
        public IdentificationNumberGraphType()
        {
            Name = "IdentificationScalarType";
        }

        public override object Serialize(object value)
        {
            var stringValue = value.ToString();
            var replacedValue = stringValue.Substring(0, stringValue.Length - 4);

            return stringValue.Replace(replacedValue, "").PadLeft(replacedValue.Length, '*');
        }

        public override object ParseValue(object value)
        {
            return value.ToString();
        }

        public override object ParseLiteral(IValue value)
        {
            return value.ToString();
        }
    }
}