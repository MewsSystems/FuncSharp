using System;

namespace FuncSharp
{
    public static class ITryExtensions
    {
        /// <summary>
        /// Turns an error try into successful try. Successful try is returned intact.
        /// </summary>
        public static ITry<B> Recover<A, B>(this ITry<A> t, Func<Exception, B> recover)
            where A : B
        {
            return t.Match(
                _ => t as ITry<B>,
                e => recover(e).ToTry<B>()
            );
        }
    }
}
