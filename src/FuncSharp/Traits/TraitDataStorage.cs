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
        public TData Get<TTraitInterface, TData>(Func<TData> dataCreator)
            where TData : class
        {
            object data = null;
            if (dataByTraitTypes.TryGetValue(typeof(TTraitInterface), out data))
            {
                var traitData = data as TData;
                if (data == null)
                {
                    throw new ArgumentException("TData is invalid. The trait already contains data of different type for the specified trait interface.");
                }
                return traitData;
            }
            else
            {
                var traitData = dataCreator();
                if (traitData == null)
                {
                    throw new ArgumentException("The created data must not be null.");
                }
                dataByTraitTypes.Add(typeof(TTraitInterface), traitData);
                return traitData;
            }
        }
    }
}
