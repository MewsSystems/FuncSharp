﻿using System;

namespace FuncSharp;

public static class ActionExtensions
{
    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<Unit> ToFunc(this Action a)
    {
        return () =>
        {
            a();
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, Unit> ToFunc<T1>(this Action<T1> a)
    {
        return (t1) =>
        {
            a(t1);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, Unit> ToFunc<T1, T2>(this Action<T1, T2> a)
    {
        return (t1, t2) =>
        {
            a(t1, t2);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, Unit> ToFunc<T1, T2, T3>(this Action<T1, T2, T3> a)
    {
        return (t1, t2, t3) =>
        {
            a(t1, t2, t3);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, Unit> ToFunc<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> a)
    {
        return (t1, t2, t3, t4) =>
        {
            a(t1, t2, t3, t4);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, Unit> ToFunc<T1, T2, T3, T4, T5>(this Action<T1, T2, T3, T4, T5> a)
    {
        return (t1, t2, t3, t4, t5) =>
        {
            a(t1, t2, t3, t4, t5);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, Unit> ToFunc<T1, T2, T3, T4, T5, T6>(this Action<T1, T2, T3, T4, T5, T6> a)
    {
        return (t1, t2, t3, t4, t5, t6) =>
        {
            a(t1, t2, t3, t4, t5, t6);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, T7, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7>(this Action<T1, T2, T3, T4, T5, T6, T7> a)
    {
        return (t1, t2, t3, t4, t5, t6, t7) =>
        {
            a(t1, t2, t3, t4, t5, t6, t7);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8>(this Action<T1, T2, T3, T4, T5, T6, T7, T8> a)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8) =>
        {
            a(t1, t2, t3, t4, t5, t6, t7, t8);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> a)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9) =>
        {
            a(t1, t2, t3, t4, t5, t6, t7, t8, t9);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> a)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10) =>
        {
            a(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> a)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11) =>
        {
            a(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> a)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12) =>
        {
            a(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> a)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13) =>
        {
            a(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> a)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14) =>
        {
            a(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14);
            return Unit.Value;
        };
    }

    /// <summary>
    /// Converts the specified action to a function returning a unit.
    /// </summary>
    public static Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Unit> ToFunc<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> a)
    {
        return (t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15) =>
        {
            a(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15);
            return Unit.Value;
        };
    }

}