using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableProgram
{
    public class RemovePhrase<K, V>
    {
        //variables defining 
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        //creating parameterize constructor 
        public RemovePhrase(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        //get and set method 
        public struct KeyValue<k, v>
        {
            public k Key { get; set; }
            public v Value { get; set; }
        }

        public void Add(K key, V value)
        {
            int position = GetArrayPosition(key);

            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);

            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);
        }
        // Gets the value at the specified key.
        // using Generic Method to find the key value pair at the particular position
        public V Get(K key)
        {
            int position = GetArrayPosition(key);

            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }
        //to get position of array 
        protected int GetArrayPosition(K key)
        {
            //for finding position use key.Hash code() % size of array
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        //creating GetLinkedList method with initial position to return keyvalue pair and
        // gets the position of items array in linked list
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];

            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public void Remove(K key)
        {
            int position = GetArrayPosition(key);

            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            bool itemFound = false;

            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            foreach (KeyValue<K, V> item in linkedList)

            {
                if (item.Key.Equals(key))
                {
                    itemFound = true;
                    foundItem = item;
                }
            }
            if (itemFound)
            {
                linkedList.Remove(foundItem);
            }
        }

        //to get frequency of values using getfrequency method
        public int GetFrequency(V Values)
        {
            //initially our frequency is zero

            int frequency = 0;

            //using foreach loop to get the value in linked list

            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                    continue;

                foreach (KeyValue<K, V> check in list)
                {
                    if (check.Equals(null))
                    {
                        continue;
                    }
                    if (check.Value.Equals(Values))
                    {
                        frequency++;
                    }
                }
            }
            Console.WriteLine("\"{0}\" =>\t this word appears =>\t \"{1}\"  times", Values, frequency);
            return frequency;
        }
    }    
}