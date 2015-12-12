using System;

namespace FuncSharp
{
    public static class ITraitExtensions
    {
        /// <summary>
        /// Returns data stored for the specified trait interface. If nothing is stored yet, creates the data using the specified
        /// <paramref name="dataCreator"/> and returns them.
        /// </summary>
        public static TData GetTraitData<TTraitInterface, TData>(this TTraitInterface traitInterface, Func<Unit, TData> dataCreator)
            where TTraitInterface : ITrait<TData>
            where TData : class
        {
            return traitInterface.TraitDataStorage.Get<TTraitInterface, TData>(dataCreator);
        }
    }
}
