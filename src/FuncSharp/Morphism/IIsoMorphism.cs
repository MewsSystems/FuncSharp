namespace FuncSharp;

/// <summary>
/// A finite isomorphism between values of type <typeparamref name="A"/> and values of type <typeparamref name="B"/>.
/// </summary>
public interface IIsoMorphism<A, B> : IMorphism<A, B>
{
    /// <summary>
    /// The inverse morphism from range to domain.
    /// </summary>
    IMorphism<B, A> Inverse { get; }
}