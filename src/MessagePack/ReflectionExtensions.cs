namespace MessagePack
{
    public static class ReflectionExtensions
    {
        public static bool IsBareNullable(this System.Reflection.TypeInfo type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(BareNullable<>);
        }
    }
}
