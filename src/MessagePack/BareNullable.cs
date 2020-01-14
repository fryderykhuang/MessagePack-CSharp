namespace MessagePack
{
    public readonly struct BareNullable<T>
    {
        public BareNullable(T value)
        {
            HasValue = true;
            Value = value;
        }
        
        public readonly bool HasValue;

        public readonly T Value;
    }
}