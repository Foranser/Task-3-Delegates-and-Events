using System;
using System.Collections.Generic;

namespace Task3.DelegatesAndEvents.Extensions
{
    public static class EnumerableExtensions
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null) throw new ArgumentNullException(nameof(collection));
            if (convertToNumber == null) throw new ArgumentNullException(nameof(convertToNumber));

            T maxItem = null;
            var hasValue = false;
            var maxValue = float.MinValue;

            foreach (var item in collection)
            {
                if (item == null) continue;

                var value = convertToNumber(item);
                if (!hasValue || value > maxValue)
                {
                    hasValue = true;
                    maxValue = value;
                    maxItem = item;
                }
            }

            return maxItem;
        }
    }
}
