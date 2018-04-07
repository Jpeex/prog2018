using System;
using System.Collections.Generic;

namespace HashTable
{
    public class HashTable

    {
        class KeyValuePair
        {
            public object Key { get; set; }
            public object Value { get; set; }
        }

        List<List<KeyValuePair>> list;

        public HashTable(int size)
        {
            list = new List<List<KeyValuePair>>();
            for (int i = 0; i < size; i++)
            {
                list.Add(new List<KeyValuePair>());
            }
        }

        public void PutPair(object key, object value)
        {
            var boolshi = GetBucketNumber(key);
            foreach (var e in list[boolshi])
            {
                if (Equals(e.Key, key))
                {
                    e.Value = value;
                    return;
                }
            }

            list[boolshi].Add(new KeyValuePair { Key = key, Value = value });
        }

        public object GetValueByKey(object key)
        {
            var boolshi = GetBucketNumber(key);
            foreach (var e in list[boolshi])
            {
                if (Equals(e.Key, key))
                {
                    return e.Value;
                }
            }

            return null;
        }

        private int GetBucketNumber(object key)
        {
            return Math.Abs(key.GetHashCode()) % list.Count;
        }
    }
}