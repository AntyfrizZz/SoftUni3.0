namespace _11Tuple
{
    class Tuple<K, V>
    {
        public Tuple(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }

        public K Key { get; private set; }
        public V Value { get; private set; }

        public override string ToString()
        {
            return this.Key + " -> " + this.Value;
        }
    }
}
