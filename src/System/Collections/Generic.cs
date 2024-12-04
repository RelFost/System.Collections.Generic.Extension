
using System;
using System.Collections.Generic;

namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        public static bool ContainsKeys<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys)
        {
            return dictionary.ContainsAllKeys(keys);
        }

        public static bool ContainsAllKeys<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys)
        {
            foreach (var key in keys)
            {
                if (!dictionary.ContainsKey(key))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ContainsAnyKey<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, IEnumerable<TKey> keys)
        {
            foreach (var key in keys)
            {
                if (dictionary.ContainsKey(key))
                {
                    return true;
                }
            }
            return false;
        }

        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory)
        {
            if (!dictionary.ContainsKey(key))
            {
                var value = valueFactory();
                dictionary.Add(key, value);
                return value;
            }
            return dictionary[key];
        }

        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.GetOrAdd(key, () => default);
        }

        public static TValue GetOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            return dictionary.GetOrAdd(key, () => defaultValue);
        }

        public static TValue GetOr<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> callback)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }

            value = callback(key);
            dictionary.Add(key, value);
            return value;
        }

        public static void UpdateOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Action<TValue> updateAction, Func<TValue> createFactory)
        {
            if (dictionary.ContainsKey(key))
            {
                updateAction(dictionary[key]);
            }
            else
            {
                var newValue = createFactory();
                dictionary.Add(key, newValue);
            }
        }

        public static void UpdateOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = value;
            }
            else
            {
                dictionary.Add(key, value);
            }
        }

        public static void UpdateOrAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Action<TValue> updateAction) where TValue : new()
        {
            if (dictionary.ContainsKey(key))
            {
                updateAction(dictionary[key]);
            }
            else
            {
                var newValue = new TValue();
                dictionary.Add(key, newValue);
                updateAction(newValue);
            }
        }
    }
}
