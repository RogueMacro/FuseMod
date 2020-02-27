using System.Collections.Generic;

namespace Fuse.Unturned
{
    public static class TupleHelper
    {
        public static IEnumerable<KeyValuePair<string, object>> ToKeyValuePairArray(this (string, object)[] array)
        {
            foreach (var item in array)
                yield return new KeyValuePair<string, object>(item.Item1, item.Item2);
        }
    }
}