namespace MessagePack
{
    public struct BareNullable<T>
    {
        public BareNullable(bool isNull, T value)
        {
            IsNull = isNull;
            Value = value;
        }
        public BareNullable(bool isNull)
        {
            IsNull = isNull;
            Value = default;
        }
        
        public BareNullable(T value)
        {
            IsNull = false;
            Value = value;
        }

        public readonly bool IsNull;

        public readonly T Value;
    }
}