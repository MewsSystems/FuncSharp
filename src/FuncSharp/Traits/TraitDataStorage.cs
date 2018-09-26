using System;
using System.Collections.Concurrent;

namespace FuncSharp
{
    /// <summary>
    /// Storage of trait data.
    /// </summary>
    public class TraitDataStorage
    {
        private ConcurrentDictionary<Type, object> dataByTraitTypes = new ConcurrentDictionary<Type, object>();

        /// <summary>
        /// Returns data stored for the specified trait interface. If nothing is stored yet, creates the data using the specified
        /// <paramref name="dataCreator"/> and returns them.
        /// </summary>
        public TData Get<TTraitInterface, TData>(Func<Unit, TData> dataCreator)
            where TData : class
        {
            var traitType = typeof(TTraitInterface);
            var data = dataByTraitTypes.GetOrAdd(traitType, t => dataCreator(Unit.Value).ToOption().Get(_ => new ArgumentException("The created data must not be null.")));
            return data.As<TData>().Get(_ => new ArgumentException("TData is invalid. The trait already contains data of different type for the specified trait interface."));
        }
    }
}
