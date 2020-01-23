using System;
using System.Collections.Generic;
using System.Linq;

namespace Fuse.Unturned
{
    public static class KeyValuePairHelper
    {
        public static TV Get<TK, TV>(this KeyValuePair<TK, TV>[] array, TK key)
        {
            return array.First(pair => Compare(pair.Key, key)).Value;
        }

        public static TV GetOrDefault<TK, TV>(this KeyValuePair<TK, TV>[] array, TK key)
        {
            return array.FirstOrDefault(pair => Compare(pair.Key, key)).Value;
        }

        public static TV GetOrDefault<TK, TV>(this KeyValuePair<TK, TV>[] array, TK key, TV defaultValue)
        {
            return array.ContainsKeyAndType(key, typeof(TV)) 
                ? array.FirstOrDefault(pair => Compare(pair.Key, key)).Value 
                : defaultValue;
        }

        public static bool ContainsKey<TK, TV>(this IEnumerable<KeyValuePair<TK, TV>> array, TK key)
        {
            return array.Any(pair => EqualityComparer<TK>.Default.Equals(pair.Key, key));
        }

        public static bool ContainsKeyAndType<TK, TV>(this IEnumerable<KeyValuePair<TK, TV>> array, TK key, Type type)
        {
            return array.Any(pair => Compare(pair.Key, key) && pair.Value.GetType() == type);
        }

        public static bool ContainsValue<TK, TV>(this IEnumerable<KeyValuePair<TK, TV>> array, TV value)
        {
            return array.Any(pair => Compare(pair.Value, value));
        }

        private static bool Compare<T>(T a, T b)
        {
            return EqualityComparer<T>.Default.Equals(a, b);
        }
    }
}