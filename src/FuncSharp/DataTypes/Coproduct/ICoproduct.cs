using System;

namespace FuncSharp
{
    /// <summary>
    /// A type that represents a disjunction of types, choice from multiple different types e.g. T1 or T2 or T3.
    /// </summary>
    public interface ICoproduct
    {
        /// <summary>
        /// Arity of the coproduct type. Should be non-negative.
        /// </summary>
        int CoproductArity { get; }

        /// <summary>
        /// Discriminator of the coproduct type value. Should be in interval [1, CoproductArity].
        /// </summary>
        int CoproductDiscriminator { get; }

        /// <summary>
        /// Value of the coproduct type no matter which one of the possible values it is.
        /// </summary>
        object CoproductValue { get; }
    }

    /// <summary>
    /// A 0-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct0 : ICoproduct
    {
    }

    /// <summary>
    /// A 1-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct1<out T1> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null);
    }

    /// <summary>
    /// A 2-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct2<out T1, out T2> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null);
    }

    /// <summary>
    /// A 3-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct3<out T1, out T2, out T3> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null);
    }

    /// <summary>
    /// A 4-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct4<out T1, out T2, out T3, out T4> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null);
    }

    /// <summary>
    /// A 5-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct5<out T1, out T2, out T3, out T4, out T5> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null);
    }

    /// <summary>
    /// A 6-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct6<out T1, out T2, out T3, out T4, out T5, out T6> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null);
    }

    /// <summary>
    /// A 7-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct7<out T1, out T2, out T3, out T4, out T5, out T6, out T7> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null);
    }

    /// <summary>
    /// A 8-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct8<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null);
    }

    /// <summary>
    /// A 9-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct9<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null);
    }

    /// <summary>
    /// A 10-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct10<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null);
    }

    /// <summary>
    /// A 11-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct11<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eleventh value.
        /// </summary>
        bool IsEleventh { get; }

        /// <summary>
        /// Returns eleventh value of the coproduct as an option. The option contains the eleventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T11> Eleventh { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth,
            Func<T11, R> ifEleventh);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null,
            Action<T11> ifEleventh = null);
    }

    /// <summary>
    /// A 12-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct12<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eleventh value.
        /// </summary>
        bool IsEleventh { get; }

        /// <summary>
        /// Returns eleventh value of the coproduct as an option. The option contains the eleventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T11> Eleventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the twelfth value.
        /// </summary>
        bool IsTwelfth { get; }

        /// <summary>
        /// Returns twelfth value of the coproduct as an option. The option contains the twelfth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T12> Twelfth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth,
            Func<T11, R> ifEleventh,
            Func<T12, R> ifTwelfth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null,
            Action<T11> ifEleventh = null,
            Action<T12> ifTwelfth = null);
    }

    /// <summary>
    /// A 13-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct13<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eleventh value.
        /// </summary>
        bool IsEleventh { get; }

        /// <summary>
        /// Returns eleventh value of the coproduct as an option. The option contains the eleventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T11> Eleventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the twelfth value.
        /// </summary>
        bool IsTwelfth { get; }

        /// <summary>
        /// Returns twelfth value of the coproduct as an option. The option contains the twelfth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T12> Twelfth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the thirteenth value.
        /// </summary>
        bool IsThirteenth { get; }

        /// <summary>
        /// Returns thirteenth value of the coproduct as an option. The option contains the thirteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T13> Thirteenth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth,
            Func<T11, R> ifEleventh,
            Func<T12, R> ifTwelfth,
            Func<T13, R> ifThirteenth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null,
            Action<T11> ifEleventh = null,
            Action<T12> ifTwelfth = null,
            Action<T13> ifThirteenth = null);
    }

    /// <summary>
    /// A 14-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct14<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eleventh value.
        /// </summary>
        bool IsEleventh { get; }

        /// <summary>
        /// Returns eleventh value of the coproduct as an option. The option contains the eleventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T11> Eleventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the twelfth value.
        /// </summary>
        bool IsTwelfth { get; }

        /// <summary>
        /// Returns twelfth value of the coproduct as an option. The option contains the twelfth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T12> Twelfth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the thirteenth value.
        /// </summary>
        bool IsThirteenth { get; }

        /// <summary>
        /// Returns thirteenth value of the coproduct as an option. The option contains the thirteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T13> Thirteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourteenth value.
        /// </summary>
        bool IsFourteenth { get; }

        /// <summary>
        /// Returns fourteenth value of the coproduct as an option. The option contains the fourteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T14> Fourteenth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth,
            Func<T11, R> ifEleventh,
            Func<T12, R> ifTwelfth,
            Func<T13, R> ifThirteenth,
            Func<T14, R> ifFourteenth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null,
            Action<T11> ifEleventh = null,
            Action<T12> ifTwelfth = null,
            Action<T13> ifThirteenth = null,
            Action<T14> ifFourteenth = null);
    }

    /// <summary>
    /// A 15-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct15<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eleventh value.
        /// </summary>
        bool IsEleventh { get; }

        /// <summary>
        /// Returns eleventh value of the coproduct as an option. The option contains the eleventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T11> Eleventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the twelfth value.
        /// </summary>
        bool IsTwelfth { get; }

        /// <summary>
        /// Returns twelfth value of the coproduct as an option. The option contains the twelfth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T12> Twelfth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the thirteenth value.
        /// </summary>
        bool IsThirteenth { get; }

        /// <summary>
        /// Returns thirteenth value of the coproduct as an option. The option contains the thirteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T13> Thirteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourteenth value.
        /// </summary>
        bool IsFourteenth { get; }

        /// <summary>
        /// Returns fourteenth value of the coproduct as an option. The option contains the fourteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T14> Fourteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifteenth value.
        /// </summary>
        bool IsFifteenth { get; }

        /// <summary>
        /// Returns fifteenth value of the coproduct as an option. The option contains the fifteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T15> Fifteenth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth,
            Func<T11, R> ifEleventh,
            Func<T12, R> ifTwelfth,
            Func<T13, R> ifThirteenth,
            Func<T14, R> ifFourteenth,
            Func<T15, R> ifFifteenth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null,
            Action<T11> ifEleventh = null,
            Action<T12> ifTwelfth = null,
            Action<T13> ifThirteenth = null,
            Action<T14> ifFourteenth = null,
            Action<T15> ifFifteenth = null);
    }

    /// <summary>
    /// A 16-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct16<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eleventh value.
        /// </summary>
        bool IsEleventh { get; }

        /// <summary>
        /// Returns eleventh value of the coproduct as an option. The option contains the eleventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T11> Eleventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the twelfth value.
        /// </summary>
        bool IsTwelfth { get; }

        /// <summary>
        /// Returns twelfth value of the coproduct as an option. The option contains the twelfth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T12> Twelfth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the thirteenth value.
        /// </summary>
        bool IsThirteenth { get; }

        /// <summary>
        /// Returns thirteenth value of the coproduct as an option. The option contains the thirteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T13> Thirteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourteenth value.
        /// </summary>
        bool IsFourteenth { get; }

        /// <summary>
        /// Returns fourteenth value of the coproduct as an option. The option contains the fourteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T14> Fourteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifteenth value.
        /// </summary>
        bool IsFifteenth { get; }

        /// <summary>
        /// Returns fifteenth value of the coproduct as an option. The option contains the fifteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T15> Fifteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixteenth value.
        /// </summary>
        bool IsSixteenth { get; }

        /// <summary>
        /// Returns sixteenth value of the coproduct as an option. The option contains the sixteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T16> Sixteenth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth,
            Func<T11, R> ifEleventh,
            Func<T12, R> ifTwelfth,
            Func<T13, R> ifThirteenth,
            Func<T14, R> ifFourteenth,
            Func<T15, R> ifFifteenth,
            Func<T16, R> ifSixteenth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null,
            Action<T11> ifEleventh = null,
            Action<T12> ifTwelfth = null,
            Action<T13> ifThirteenth = null,
            Action<T14> ifFourteenth = null,
            Action<T15> ifFifteenth = null,
            Action<T16> ifSixteenth = null);
    }

    /// <summary>
    /// A 17-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct17<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eleventh value.
        /// </summary>
        bool IsEleventh { get; }

        /// <summary>
        /// Returns eleventh value of the coproduct as an option. The option contains the eleventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T11> Eleventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the twelfth value.
        /// </summary>
        bool IsTwelfth { get; }

        /// <summary>
        /// Returns twelfth value of the coproduct as an option. The option contains the twelfth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T12> Twelfth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the thirteenth value.
        /// </summary>
        bool IsThirteenth { get; }

        /// <summary>
        /// Returns thirteenth value of the coproduct as an option. The option contains the thirteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T13> Thirteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourteenth value.
        /// </summary>
        bool IsFourteenth { get; }

        /// <summary>
        /// Returns fourteenth value of the coproduct as an option. The option contains the fourteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T14> Fourteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifteenth value.
        /// </summary>
        bool IsFifteenth { get; }

        /// <summary>
        /// Returns fifteenth value of the coproduct as an option. The option contains the fifteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T15> Fifteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixteenth value.
        /// </summary>
        bool IsSixteenth { get; }

        /// <summary>
        /// Returns sixteenth value of the coproduct as an option. The option contains the sixteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T16> Sixteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventeenth value.
        /// </summary>
        bool IsSeventeenth { get; }

        /// <summary>
        /// Returns seventeenth value of the coproduct as an option. The option contains the seventeenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T17> Seventeenth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth,
            Func<T11, R> ifEleventh,
            Func<T12, R> ifTwelfth,
            Func<T13, R> ifThirteenth,
            Func<T14, R> ifFourteenth,
            Func<T15, R> ifFifteenth,
            Func<T16, R> ifSixteenth,
            Func<T17, R> ifSeventeenth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null,
            Action<T11> ifEleventh = null,
            Action<T12> ifTwelfth = null,
            Action<T13> ifThirteenth = null,
            Action<T14> ifFourteenth = null,
            Action<T15> ifFifteenth = null,
            Action<T16> ifSixteenth = null,
            Action<T17> ifSeventeenth = null);
    }

    /// <summary>
    /// A 18-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct18<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17, out T18> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eleventh value.
        /// </summary>
        bool IsEleventh { get; }

        /// <summary>
        /// Returns eleventh value of the coproduct as an option. The option contains the eleventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T11> Eleventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the twelfth value.
        /// </summary>
        bool IsTwelfth { get; }

        /// <summary>
        /// Returns twelfth value of the coproduct as an option. The option contains the twelfth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T12> Twelfth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the thirteenth value.
        /// </summary>
        bool IsThirteenth { get; }

        /// <summary>
        /// Returns thirteenth value of the coproduct as an option. The option contains the thirteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T13> Thirteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourteenth value.
        /// </summary>
        bool IsFourteenth { get; }

        /// <summary>
        /// Returns fourteenth value of the coproduct as an option. The option contains the fourteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T14> Fourteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifteenth value.
        /// </summary>
        bool IsFifteenth { get; }

        /// <summary>
        /// Returns fifteenth value of the coproduct as an option. The option contains the fifteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T15> Fifteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixteenth value.
        /// </summary>
        bool IsSixteenth { get; }

        /// <summary>
        /// Returns sixteenth value of the coproduct as an option. The option contains the sixteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T16> Sixteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventeenth value.
        /// </summary>
        bool IsSeventeenth { get; }

        /// <summary>
        /// Returns seventeenth value of the coproduct as an option. The option contains the seventeenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T17> Seventeenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighteenth value.
        /// </summary>
        bool IsEighteenth { get; }

        /// <summary>
        /// Returns eighteenth value of the coproduct as an option. The option contains the eighteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T18> Eighteenth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth,
            Func<T11, R> ifEleventh,
            Func<T12, R> ifTwelfth,
            Func<T13, R> ifThirteenth,
            Func<T14, R> ifFourteenth,
            Func<T15, R> ifFifteenth,
            Func<T16, R> ifSixteenth,
            Func<T17, R> ifSeventeenth,
            Func<T18, R> ifEighteenth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null,
            Action<T11> ifEleventh = null,
            Action<T12> ifTwelfth = null,
            Action<T13> ifThirteenth = null,
            Action<T14> ifFourteenth = null,
            Action<T15> ifFifteenth = null,
            Action<T16> ifSixteenth = null,
            Action<T17> ifSeventeenth = null,
            Action<T18> ifEighteenth = null);
    }

    /// <summary>
    /// A 19-dimensional strongly-typed coproduct.
    /// </summary>
    public interface ICoproduct19<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9, out T10, out T11, out T12, out T13, out T14, out T15, out T16, out T17, out T18, out T19> : ICoproduct
    {
        /// <summary>
        /// Returns whether the coproduct contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the coproduct as an option. The option contains the first 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the coproduct contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the coproduct as an option. The option contains the second 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the coproduct contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the coproduct as an option. The option contains the third 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the coproduct as an option. The option contains the fourth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the coproduct as an option. The option contains the fifth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the coproduct as an option. The option contains the sixth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the coproduct as an option. The option contains the seventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the coproduct as an option. The option contains the eighth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the coproduct as an option. The option contains the ninth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the tenth value.
        /// </summary>
        bool IsTenth { get; }

        /// <summary>
        /// Returns tenth value of the coproduct as an option. The option contains the tenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T10> Tenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eleventh value.
        /// </summary>
        bool IsEleventh { get; }

        /// <summary>
        /// Returns eleventh value of the coproduct as an option. The option contains the eleventh 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T11> Eleventh { get; }

        /// <summary>
        /// Returns whether the coproduct contains the twelfth value.
        /// </summary>
        bool IsTwelfth { get; }

        /// <summary>
        /// Returns twelfth value of the coproduct as an option. The option contains the twelfth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T12> Twelfth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the thirteenth value.
        /// </summary>
        bool IsThirteenth { get; }

        /// <summary>
        /// Returns thirteenth value of the coproduct as an option. The option contains the thirteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T13> Thirteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fourteenth value.
        /// </summary>
        bool IsFourteenth { get; }

        /// <summary>
        /// Returns fourteenth value of the coproduct as an option. The option contains the fourteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T14> Fourteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the fifteenth value.
        /// </summary>
        bool IsFifteenth { get; }

        /// <summary>
        /// Returns fifteenth value of the coproduct as an option. The option contains the fifteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T15> Fifteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the sixteenth value.
        /// </summary>
        bool IsSixteenth { get; }

        /// <summary>
        /// Returns sixteenth value of the coproduct as an option. The option contains the sixteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T16> Sixteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the seventeenth value.
        /// </summary>
        bool IsSeventeenth { get; }

        /// <summary>
        /// Returns seventeenth value of the coproduct as an option. The option contains the seventeenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T17> Seventeenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the eighteenth value.
        /// </summary>
        bool IsEighteenth { get; }

        /// <summary>
        /// Returns eighteenth value of the coproduct as an option. The option contains the eighteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T18> Eighteenth { get; }

        /// <summary>
        /// Returns whether the coproduct contains the nineteenth value.
        /// </summary>
        bool IsNineteenth { get; }

        /// <summary>
        /// Returns nineteenth value of the coproduct as an option. The option contains the nineteenth 
        /// value or is empty if the coproduct contains different value.
        /// </summary>
        IOption<T19> Nineteenth { get; }

        /// <summary>
        /// Returns result of a function that matches the coproduct value. E.g. if the coproduct is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth,
            Func<T6, R> ifSixth,
            Func<T7, R> ifSeventh,
            Func<T8, R> ifEighth,
            Func<T9, R> ifNinth,
            Func<T10, R> ifTenth,
            Func<T11, R> ifEleventh,
            Func<T12, R> ifTwelfth,
            Func<T13, R> ifThirteenth,
            Func<T14, R> ifFourteenth,
            Func<T15, R> ifFifteenth,
            Func<T16, R> ifSixteenth,
            Func<T17, R> ifSeventeenth,
            Func<T18, R> ifEighteenth,
            Func<T19, R> ifNineteenth);

        /// <summary>
        /// Executes the function that matches the coproduct value. E.g. if the coproduct is the first value, executes 
        /// the <paramref name="ifFirst" /> function. If the function that should be executed is null, does nothing.
        /// </summary>
        void Match(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<T10> ifTenth = null,
            Action<T11> ifEleventh = null,
            Action<T12> ifTwelfth = null,
            Action<T13> ifThirteenth = null,
            Action<T14> ifFourteenth = null,
            Action<T15> ifFifteenth = null,
            Action<T16> ifSixteenth = null,
            Action<T17> ifSeventeenth = null,
            Action<T18> ifEighteenth = null,
            Action<T19> ifNineteenth = null);
    }

}