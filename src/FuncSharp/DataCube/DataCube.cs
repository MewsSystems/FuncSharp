﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuncSharp
{
    /// <summary>
    /// Base class and factory of data cubes.
    /// </summary>
    public abstract class DataCube
    {
        /// <summary>
        /// Creates a new 1-dimensional data cube.
        /// </summary>
        public static DataCube1<P1, TValue> Create<T, P1, TValue>(
            IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, TValue> value)
        {
            var dataCube = new DataCube1<P1, TValue>();
            foreach (var v in source)
            {
                dataCube.Set(
                    p1(v),
                    value(v)
                );
            }
            return dataCube;
        }

        /// <summary>
        /// Creates a new 2-dimensional data cube.
        /// </summary>
        public static DataCube2<P1, P2, TValue> Create<T, P1, P2, TValue>(
            IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, TValue> value)
        {
            var dataCube = new DataCube2<P1, P2, TValue>();
            foreach (var v in source)
            {
                dataCube.Set(
                    p1(v),
                    p2(v),
                    value(v)
                );
            }
            return dataCube;
        }

        /// <summary>
        /// Creates a new 3-dimensional data cube.
        /// </summary>
        public static DataCube3<P1, P2, P3, TValue> Create<T, P1, P2, P3, TValue>(
            IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, TValue> value)
        {
            var dataCube = new DataCube3<P1, P2, P3, TValue>();
            foreach (var v in source)
            {
                dataCube.Set(
                    p1(v),
                    p2(v),
                    p3(v),
                    value(v)
                );
            }
            return dataCube;
        }

        /// <summary>
        /// Creates a new 4-dimensional data cube.
        /// </summary>
        public static DataCube4<P1, P2, P3, P4, TValue> Create<T, P1, P2, P3, P4, TValue>(
            IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, TValue> value)
        {
            var dataCube = new DataCube4<P1, P2, P3, P4, TValue>();
            foreach (var v in source)
            {
                dataCube.Set(
                    p1(v),
                    p2(v),
                    p3(v),
                    p4(v),
                    value(v)
                );
            }
            return dataCube;
        }

        /// <summary>
        /// Creates a new 5-dimensional data cube.
        /// </summary>
        public static DataCube5<P1, P2, P3, P4, P5, TValue> Create<T, P1, P2, P3, P4, P5, TValue>(
            IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, P5> p5,
            Func<T, TValue> value)
        {
            var dataCube = new DataCube5<P1, P2, P3, P4, P5, TValue>();
            foreach (var v in source)
            {
                dataCube.Set(
                    p1(v),
                    p2(v),
                    p3(v),
                    p4(v),
                    p5(v),
                    value(v)
                );
            }
            return dataCube;
        }

        /// <summary>
        /// Creates a new 6-dimensional data cube.
        /// </summary>
        public static DataCube6<P1, P2, P3, P4, P5, P6, TValue> Create<T, P1, P2, P3, P4, P5, P6, TValue>(
            IEnumerable<T> source,
            Func<T, P1> p1,
            Func<T, P2> p2,
            Func<T, P3> p3,
            Func<T, P4> p4,
            Func<T, P5> p5,
            Func<T, P6> p6,
            Func<T, TValue> value)
        {
            var dataCube = new DataCube6<P1, P2, P3, P4, P5, P6, TValue>();
            foreach (var v in source)
            {
                dataCube.Set(
                    p1(v),
                    p2(v),
                    p3(v),
                    p4(v),
                    p5(v),
                    p6(v),
                    value(v)
                );
            }
            return dataCube;
        }

    }

    /// <summary>
    /// General representation of a data cube.
    /// </summary>
    public abstract class DataCube<TPosition, TValue> : DataCube
    {
        /// <summary>
        /// Creates a new empty data cube.
        /// </summary>
        protected DataCube()
        {
            Index = new Dictionary<TPosition, TValue>();
        }

        /// <summary>
        /// Returns whether the cube is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return !Index.Any(); }
        }

        /// <summary>
        /// Returns whether the cube is not empty.
        /// </summary>
        public bool NonEmpty
        {
            get { return !IsEmpty; }
        }

        /// <summary>
        /// Positions of all values stored in the cube.
        /// </summary>
        public IEnumerable<TPosition> Positions
        {
            get { return Index.Keys; }
        }

        /// <summary>
        /// All values stored in the cube.
        /// </summary>
        public IEnumerable<TValue> Values
        {
            get { return Index.Values; }
        }

        /// <summary>
        /// Values in the cube indexed by their positions.
        /// </summary>
        private Dictionary<TPosition, TValue> Index { get; }

        /// <summary>
        /// Returns whether the cube contains a value at the specified position.
        /// </summary>
        public bool Contains(TPosition position)
        {
            return Index.ContainsKey(position);
        }

        /// <summary>
        /// Returns value at the specified position.
        /// </summary>
        public Option<TValue> Get(TPosition position)
        {
            return Index.Get(position);
        }

        /// <summary>
        /// Returns value at the specified position. If there is no value present, sets the position to value generated by 
        /// the <paramref name="setter"/> function and returns the newly generated value.
        /// </summary>
        public TValue GetOrElseSet(TPosition position, Func<Unit, TValue> setter)
        {
            return Get(position).GetOrElse(_ => Set(position, setter(Unit.Value)));
        }

        /// <summary>
        /// Sets value at the specified position. If there is value already present at that position, overwrites it.
        /// </summary>
        public virtual TValue Set(TPosition position, TValue value)
        {
            Index[position] = value;
            return value;
        }

        /// <summary>
        /// Sets value at the specified position. If there is value already present at that position, returns result of the
        /// <paramref name="otherwise"/> function which is invoked with the current value.
        /// </summary>
        public virtual TValue SetOrElse(TPosition position, TValue value, Func<TValue, TValue> otherwise)
        {
            return Get(position).Match(
                v => otherwise(v),
                _ => Set(position, value)
            );
        }

        /// <summary>
        /// Sets value at the specified position. If there is value already present at that position, updates it with the
        /// result of the <paramref name="updater"/> function which is given the present value and the new value.
        /// </summary>
        public virtual TValue SetOrElseUpdate(TPosition position, TValue value, Func<TValue, TValue, TValue> updater)
        {
            return SetOrElse(position, value, v => Set(position, updater(v, value)));
        }

        /// <summary>
        /// Sets value at the specified position. If there is value already present at that position, updates it with the
        /// result of the <paramref name="updater"/> function which is given the present value and the new value.
        /// </summary>
        public virtual TValue SetOrElseUpdate<TNewValue>(TPosition position, TNewValue value, Func<TNewValue, TValue> valueInitialization, Func<TValue, TNewValue, TValue> updater)
        {
            return SetOrElse(position, valueInitialization(value), v => Set(position, updater(v, value)));
        }

        /// <summary>
        /// For each value in the cube, invokes the specified function passing in the position and the stored value.
        /// </summary>
        public void ForEach(Action<TPosition, TValue> a)
        {
            foreach (var kv in Index)
            {
                a(kv.Key, kv.Value);
            }
        }

        /// <summary>
        /// Transforms each value in the cube using the specified function and returns a collection of the transformed values.
        /// </summary>
        public IReadOnlyList<T> Select<T>(Func<TPosition, TValue, T> f)
        {
            var result = new List<T>();
            ForEach((p, v) => result.Add(f(p, v)));
            return result;
        }

        /// <summary>
        /// Transforms each value in the cube using the specified function and returns a concatenated collection of the transformed values.
        /// </summary>
        public IReadOnlyList<T> SelectMany<T>(Func<TPosition, TValue, IEnumerable<T>> f)
        {
            var result = new List<T>();
            ForEach((p, v) => result.AddRange(f(p, v)));
            return result;
        }

        /// <summary>
        /// Transforms each value in the cube into a key and value and returns a dictionary with those pairs.
        /// </summary>
        public Dictionary<K, V> ToDictionary<K, V>(Func<TPosition, TValue, K> key, Func<TPosition, TValue, V> value)
        {
            var result = new Dictionary<K, V>();
            ForEach((p, v) => result.Add(key(p, v), value(p, v)));
            return result;
        }

        /// <summary>
        /// Returns a new cube containing only the values that pass the specified predicate.
        /// </summary>
        public TNewCube Where<TNewCube>(Func<TPosition, TValue, bool> predicate)
            where TNewCube : DataCube<TPosition, TValue>, new()
        {
            var result = new TNewCube();
            ForEach((p, v) =>
            {
                if (predicate(p, v))
                {
                    result.Set(p, v);
                }
            });
            return result;
        }

        /// <summary>
        /// Transforms the current cube into a new cube. The transformation is directed by two functions. 
        /// The <paramref name="positionMapper"/> maps positions of values in the current cube into positions 
        /// in the new cube. If there are multiple values in the current cube, whose positions are mapped onto 
        /// the same position in the new cube, then the <paramref name="aggregator"/> function is used to 
        /// aggregate all the colliding values into one value.
        /// </summary>
        public TNewCube Transform<TNewPosition, TNewCube>(Func<TPosition, TNewPosition> positionMapper, Func<TValue, TValue, TValue> aggregator)
            where TNewCube : DataCube<TNewPosition, TValue>, new()
        {
            var result = new TNewCube();
            ForEach((p, v) => result.SetOrElseUpdate(positionMapper(p), v, aggregator));
            return result;
        }

        /// <summary>
        /// Transforms the current cube into a new cube. The transformation is directed by two functions. 
        /// The <paramref name="positionMapper"/> maps positions of values in the current cube into positions 
        /// in the new cube. If there are multiple values in the current cube, whose positions are mapped onto 
        /// the same position in the new cube, then the <paramref name="aggregator"/> function is used to 
        /// aggregate all the colliding values into one value.
        /// </summary>
        public TNewCube MultiTransform<TNewPosition, TNewCube>(Func<TPosition, IEnumerable<TNewPosition>> positionMapper, Func<TValue, TValue, TValue> aggregator)
            where TNewCube : DataCube<TNewPosition, TValue>, new()
        {
            var result = new TNewCube();
            ForEach((p, v) =>
            {
                foreach (var newPosition in positionMapper(p))
                {
                    result.SetOrElseUpdate(newPosition, v, aggregator);
                }
            });
            return result;
        }

        public override string ToString()
        {
            var result = new StringBuilder("DataCube(");
            if (!IsEmpty)
            {
                result.AppendLine();

                var isFirst = true;
                ForEach((p, v) =>
                {
                    if (!isFirst)
                    {
                        result.Append(",");
                    }
                    isFirst = false;

                    result.AppendLine();
                    result.Append("   " + p.ToString() + " → " + v.SafeToString());
                });
                result.AppendLine();
            }
            result.Append(")");

            return result.ToString();
        }
        
        protected void AddDomain<P>(HashSet<ValueTuple<P>> domainValues, P value)
        {
            domainValues.Add(ValueTuple.Create(value));
        }
    }
}