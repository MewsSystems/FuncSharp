using System.Collections.Generic;

namespace FuncSharp
{
    /// <summary>
    /// A finite morphism from values of type <typeparamref name="A"/> to values of type <typeparamref name="B"/>.
    /// </summary>
    public interface IMorphism<A, B>
    {
        /// <summary>
        /// Domain of the morphism (the values that are mapped).
        /// </summary>
        IEnumerable<A> Domain { get; }

        /// <summary>
        /// Range of the morphism (that values that are being mapped onto).
        /// </summary>
        IEnumerable<B> Range { get; }

        /// <summary>
        /// Returns value that the <paramref name="source"/> is mapped onto.
        /// </summary>
        Option<B> Apply(A source);
    }
}
