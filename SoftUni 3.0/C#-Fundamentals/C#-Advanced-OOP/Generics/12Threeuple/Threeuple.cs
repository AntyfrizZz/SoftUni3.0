namespace _12Threeuple
{
    class Threeuple<K, V, V1>
    {
        public Threeuple(K key, V value, V1 secondValue)
        {
            this.Key = key;
            this.Value = value;
            this.SecondValue = secondValue;
        }

        public K Key { get; private set; }

        public V Value { get; private set; }

        public V1 SecondValue { get; private set; }

        public override string ToString()
        {
            return this.Key + " -> " + this.Value + " -> " + this.SecondValue;
        }
    }
}
