namespace FuncSharp.Tests.Generative;

public record class ReferenceTypeBase (int BaseValue);
public record class ReferenceType (int Value) : ReferenceTypeBase(Value);
