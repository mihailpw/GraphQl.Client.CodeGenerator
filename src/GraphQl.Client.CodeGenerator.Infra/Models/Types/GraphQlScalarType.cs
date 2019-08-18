namespace GraphQl.Client.CodeGenerator.Infra.Models.Types
{
    public class GraphQlScalarType : GraphQlTypeBase
    {
        public override GraphQlKind Kind => GraphQlKind.Scalar;

        public ScalarTypes Type { get; set; }
    }

    public enum ScalarTypes
    {
        String,
        Boolean,
        Float,
        Int,
        Id,
        Date,
        DateTime,
        DateTimeOffset,
        Seconds,
        Milliseconds,
        Decimal,
        Uri,
        Guid,
        Short,
        UShort,
        UInt,
        ULong,
        Byte,
        SByte,
    }
}