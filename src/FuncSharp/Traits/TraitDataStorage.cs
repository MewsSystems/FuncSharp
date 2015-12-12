using System;
using System.Collections.Generic;

namespace FuncSharp
{
    /// <summary>
    /// Storage of trait data.
    /// </summary>
    public class TraitDataStorage
    {
        private Dictionary<Type, object> dataByTraitTypes = new Dictionary<Type, object>();

        /// <summary>
        /// Returns data stored for the specified trait interface. If nothing is stored yet, creates the data using the specified
        /// <paramref name="dataCreator"/> and returns them.
        /// </summary>
        public TData Get<TTraitInterface, TData>(Func<Unit, TData> dataCreator)
            where TData : class
        {
            var traitType = typeof(TTraitInterface);
            return dataByTraitTypes.Get(traitType).Match(
                data => data.As<TData>().Get(_ => new ArgumentException("TData is invalid. The trait already contains data of different type for the specified trait interface.")),
                _ =>
                {
                    var data = dataCreator(_).ToOption().Get(__ => new ArgumentException("The created data must not be null."));
                    dataByTraitTypes.Add(traitType, data);
                    return data;
                }
            );
        }
    }
}
