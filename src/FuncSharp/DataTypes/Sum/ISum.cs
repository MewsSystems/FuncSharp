using System;

namespace FuncSharp
{
    /// <summary>
    /// A type that represents a disjunction of types, choice from multiple different types e.g. T1 or T2 or T3.
    /// </summary>
    public interface ISum
    {
        /// <summary>
        /// Arity of the sum type. Should be non-negative.
        /// </summary>
        int SumArity { get; }

        /// <summary>
        /// Discriminator of the sum type value. Should be in interval [1, SumArity].
        /// </summary>
        int SumDiscriminator { get; }

        /// <summary>
        /// Value of the sum type no matter which one of the possible values it is.
        /// </summary>
        object SumValue { get; }
    }

    /// <summary>
    /// A 0-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum0 : ISum
    {
    }

    /// <summary>
    /// A 1-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum1<out T1> : ISum
    {
        /// <summary>
        /// Returns whether the sum contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the sum as an option. The option contains the first value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns result of a function that matches the sum value. E.g. if the sum is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst);

        /// <summary>
        /// Executes the function that matches the sum value. E.g. if the sum is the first value, executes 
        /// the <paramref name="ifFirst" /> function.
        /// </summary>
        void Match(
            Action<T1> ifFirst);

        /// <summary>
        /// Returns result of a function that matches the sum value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<object, R> otherwise = null);

        /// <summary>
        /// Executes the function that matches the sum value similarly to match. If the function is null, executes the the 
        /// <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, does nothing.
        /// </summary>
        void PartialMatch(
            Action<T1> ifFirst = null,
            Action<object> otherwise = null);

    }

    /// <summary>
    /// A 2-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum2<out T1, out T2> : ISum
    {
        /// <summary>
        /// Returns whether the sum contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the sum as an option. The option contains the first value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the sum contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the sum as an option. The option contains the second value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns result of a function that matches the sum value. E.g. if the sum is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond);

        /// <summary>
        /// Executes the function that matches the sum value. E.g. if the sum is the first value, executes 
        /// the <paramref name="ifFirst" /> function.
        /// </summary>
        void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond);

        /// <summary>
        /// Returns result of a function that matches the sum value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<object, R> otherwise = null);

        /// <summary>
        /// Executes the function that matches the sum value similarly to match. If the function is null, executes the the 
        /// <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, does nothing.
        /// </summary>
        void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<object> otherwise = null);

    }

    /// <summary>
    /// A 3-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum3<out T1, out T2, out T3> : ISum
    {
        /// <summary>
        /// Returns whether the sum contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the sum as an option. The option contains the first value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the sum contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the sum as an option. The option contains the second value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the sum contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the sum as an option. The option contains the third value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns result of a function that matches the sum value. E.g. if the sum is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird);

        /// <summary>
        /// Executes the function that matches the sum value. E.g. if the sum is the first value, executes 
        /// the <paramref name="ifFirst" /> function.
        /// </summary>
        void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird);

        /// <summary>
        /// Returns result of a function that matches the sum value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<object, R> otherwise = null);

        /// <summary>
        /// Executes the function that matches the sum value similarly to match. If the function is null, executes the the 
        /// <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, does nothing.
        /// </summary>
        void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<object> otherwise = null);

    }

    /// <summary>
    /// A 4-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum4<out T1, out T2, out T3, out T4> : ISum
    {
        /// <summary>
        /// Returns whether the sum contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the sum as an option. The option contains the first value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the sum contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the sum as an option. The option contains the second value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the sum contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the sum as an option. The option contains the third value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the sum contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the sum as an option. The option contains the fourth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns result of a function that matches the sum value. E.g. if the sum is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth);

        /// <summary>
        /// Executes the function that matches the sum value. E.g. if the sum is the first value, executes 
        /// the <paramref name="ifFirst" /> function.
        /// </summary>
        void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth);

        /// <summary>
        /// Returns result of a function that matches the sum value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<object, R> otherwise = null);

        /// <summary>
        /// Executes the function that matches the sum value similarly to match. If the function is null, executes the the 
        /// <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, does nothing.
        /// </summary>
        void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<object> otherwise = null);

    }

    /// <summary>
    /// A 5-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum5<out T1, out T2, out T3, out T4, out T5> : ISum
    {
        /// <summary>
        /// Returns whether the sum contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the sum as an option. The option contains the first value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the sum contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the sum as an option. The option contains the second value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the sum contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the sum as an option. The option contains the third value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the sum contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the sum as an option. The option contains the fourth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the sum contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the sum as an option. The option contains the fifth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns result of a function that matches the sum value. E.g. if the sum is the first value, returns result
        /// of the <paramref name="ifFirst" /> function.
        /// </summary>
        R Match<R>(
            Func<T1, R> ifFirst,
            Func<T2, R> ifSecond,
            Func<T3, R> ifThird,
            Func<T4, R> ifFourth,
            Func<T5, R> ifFifth);

        /// <summary>
        /// Executes the function that matches the sum value. E.g. if the sum is the first value, executes 
        /// the <paramref name="ifFirst" /> function.
        /// </summary>
        void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth);

        /// <summary>
        /// Returns result of a function that matches the sum value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<object, R> otherwise = null);

        /// <summary>
        /// Executes the function that matches the sum value similarly to match. If the function is null, executes the the 
        /// <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, does nothing.
        /// </summary>
        void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<object> otherwise = null);

    }

    /// <summary>
    /// A 6-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum6<out T1, out T2, out T3, out T4, out T5, out T6> : ISum
    {
        /// <summary>
        /// Returns whether the sum contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the sum as an option. The option contains the first value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the sum contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the sum as an option. The option contains the second value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the sum contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the sum as an option. The option contains the third value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the sum contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the sum as an option. The option contains the fourth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the sum contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the sum as an option. The option contains the fifth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the sum contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the sum as an option. The option contains the sixth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns result of a function that matches the sum value. E.g. if the sum is the first value, returns result
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
        /// Executes the function that matches the sum value. E.g. if the sum is the first value, executes 
        /// the <paramref name="ifFirst" /> function.
        /// </summary>
        void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth,
            Action<T6> ifSixth);

        /// <summary>
        /// Returns result of a function that matches the sum value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<object, R> otherwise = null);

        /// <summary>
        /// Executes the function that matches the sum value similarly to match. If the function is null, executes the the 
        /// <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, does nothing.
        /// </summary>
        void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<object> otherwise = null);

    }

    /// <summary>
    /// A 7-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum7<out T1, out T2, out T3, out T4, out T5, out T6, out T7> : ISum
    {
        /// <summary>
        /// Returns whether the sum contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the sum as an option. The option contains the first value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the sum contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the sum as an option. The option contains the second value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the sum contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the sum as an option. The option contains the third value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the sum contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the sum as an option. The option contains the fourth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the sum contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the sum as an option. The option contains the fifth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the sum contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the sum as an option. The option contains the sixth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the sum contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the sum as an option. The option contains the seventh value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns result of a function that matches the sum value. E.g. if the sum is the first value, returns result
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
        /// Executes the function that matches the sum value. E.g. if the sum is the first value, executes 
        /// the <paramref name="ifFirst" /> function.
        /// </summary>
        void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth,
            Action<T6> ifSixth,
            Action<T7> ifSeventh);

        /// <summary>
        /// Returns result of a function that matches the sum value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<T7, R> ifSeventh = null,
            Func<object, R> otherwise = null);

        /// <summary>
        /// Executes the function that matches the sum value similarly to match. If the function is null, executes the the 
        /// <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, does nothing.
        /// </summary>
        void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<object> otherwise = null);

    }

    /// <summary>
    /// A 8-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum8<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8> : ISum
    {
        /// <summary>
        /// Returns whether the sum contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the sum as an option. The option contains the first value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the sum contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the sum as an option. The option contains the second value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the sum contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the sum as an option. The option contains the third value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the sum contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the sum as an option. The option contains the fourth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the sum contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the sum as an option. The option contains the fifth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the sum contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the sum as an option. The option contains the sixth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the sum contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the sum as an option. The option contains the seventh value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the sum contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the sum as an option. The option contains the eighth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns result of a function that matches the sum value. E.g. if the sum is the first value, returns result
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
        /// Executes the function that matches the sum value. E.g. if the sum is the first value, executes 
        /// the <paramref name="ifFirst" /> function.
        /// </summary>
        void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth,
            Action<T6> ifSixth,
            Action<T7> ifSeventh,
            Action<T8> ifEighth);

        /// <summary>
        /// Returns result of a function that matches the sum value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<T7, R> ifSeventh = null,
            Func<T8, R> ifEighth = null,
            Func<object, R> otherwise = null);

        /// <summary>
        /// Executes the function that matches the sum value similarly to match. If the function is null, executes the the 
        /// <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, does nothing.
        /// </summary>
        void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<object> otherwise = null);

    }

    /// <summary>
    /// A 9-dimensional strongly-typed sum.
    /// </summary>
    public interface ISum9<out T1, out T2, out T3, out T4, out T5, out T6, out T7, out T8, out T9> : ISum
    {
        /// <summary>
        /// Returns whether the sum contains the first value.
        /// </summary>
        bool IsFirst { get; }

        /// <summary>
        /// Returns first value of the sum as an option. The option contains the first value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T1> First { get; }

        /// <summary>
        /// Returns whether the sum contains the second value.
        /// </summary>
        bool IsSecond { get; }

        /// <summary>
        /// Returns second value of the sum as an option. The option contains the second value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T2> Second { get; }

        /// <summary>
        /// Returns whether the sum contains the third value.
        /// </summary>
        bool IsThird { get; }

        /// <summary>
        /// Returns third value of the sum as an option. The option contains the third value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T3> Third { get; }

        /// <summary>
        /// Returns whether the sum contains the fourth value.
        /// </summary>
        bool IsFourth { get; }

        /// <summary>
        /// Returns fourth value of the sum as an option. The option contains the fourth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T4> Fourth { get; }

        /// <summary>
        /// Returns whether the sum contains the fifth value.
        /// </summary>
        bool IsFifth { get; }

        /// <summary>
        /// Returns fifth value of the sum as an option. The option contains the fifth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T5> Fifth { get; }

        /// <summary>
        /// Returns whether the sum contains the sixth value.
        /// </summary>
        bool IsSixth { get; }

        /// <summary>
        /// Returns sixth value of the sum as an option. The option contains the sixth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T6> Sixth { get; }

        /// <summary>
        /// Returns whether the sum contains the seventh value.
        /// </summary>
        bool IsSeventh { get; }

        /// <summary>
        /// Returns seventh value of the sum as an option. The option contains the seventh value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T7> Seventh { get; }

        /// <summary>
        /// Returns whether the sum contains the eighth value.
        /// </summary>
        bool IsEighth { get; }

        /// <summary>
        /// Returns eighth value of the sum as an option. The option contains the eighth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T8> Eighth { get; }

        /// <summary>
        /// Returns whether the sum contains the ninth value.
        /// </summary>
        bool IsNinth { get; }

        /// <summary>
        /// Returns ninth value of the sum as an option. The option contains the ninth value
        /// or is empty if the sum contains different value.
        /// </summary>
        IOption<T9> Ninth { get; }

        /// <summary>
        /// Returns result of a function that matches the sum value. E.g. if the sum is the first value, returns result
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
        /// Executes the function that matches the sum value. E.g. if the sum is the first value, executes 
        /// the <paramref name="ifFirst" /> function.
        /// </summary>
        void Match(
            Action<T1> ifFirst,
            Action<T2> ifSecond,
            Action<T3> ifThird,
            Action<T4> ifFourth,
            Action<T5> ifFifth,
            Action<T6> ifSixth,
            Action<T7> ifSeventh,
            Action<T8> ifEighth,
            Action<T9> ifNinth);

        /// <summary>
        /// Returns result of a function that matches the sum value similarly to match. If the function is null, returns result
        /// of the <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, returns default value of the result type. 
        /// </summary>
        R PartialMatch<R>(
            Func<T1, R> ifFirst = null,
            Func<T2, R> ifSecond = null,
            Func<T3, R> ifThird = null,
            Func<T4, R> ifFourth = null,
            Func<T5, R> ifFifth = null,
            Func<T6, R> ifSixth = null,
            Func<T7, R> ifSeventh = null,
            Func<T8, R> ifEighth = null,
            Func<T9, R> ifNinth = null,
            Func<object, R> otherwise = null);

        /// <summary>
        /// Executes the function that matches the sum value similarly to match. If the function is null, executes the the 
        /// <paramref name="otherwise">otherwise</paramref> function. If the <paramref name="otherwise">otherwise</paramref> function 
        /// is null, does nothing.
        /// </summary>
        void PartialMatch(
            Action<T1> ifFirst = null,
            Action<T2> ifSecond = null,
            Action<T3> ifThird = null,
            Action<T4> ifFourth = null,
            Action<T5> ifFifth = null,
            Action<T6> ifSixth = null,
            Action<T7> ifSeventh = null,
            Action<T8> ifEighth = null,
            Action<T9> ifNinth = null,
            Action<object> otherwise = null);

    }

}