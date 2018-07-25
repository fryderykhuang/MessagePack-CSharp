using System;
using System.Collections.Generic;
using System.Text;
using MessagePack.Formatters;
using MessagePack.Internal;

namespace MessagePack.Resolvers
{
    public sealed class ForcePrimitiveSizeContractlessStandardResolver : IFormatterResolver
    {
        public static readonly IFormatterResolver Instance = new ForcePrimitiveSizeContractlessStandardResolver();

#if NETSTANDARD
        public static readonly IMessagePackFormatter<object> ObjectFallbackFormatter =
            new DynamicObjectTypeFallbackFormatter(
                ForceSizePrimitiveObjectResolver.Instance, ContractlessStandardResolverCore.Instance);
#endif

        private ForcePrimitiveSizeContractlessStandardResolver()
        {
        }

        public IMessagePackFormatter<T> GetFormatter<T>()
        {
            return FormatterCache<T>.formatter;
        }

        private static class FormatterCache<T>
        {
            public static readonly IMessagePackFormatter<T> formatter;

            static FormatterCache()
            {
                if (typeof(T) == typeof(object))
                {
                    // final fallback
#if NETSTANDARD
                    formatter = (IMessagePackFormatter<T>) ObjectFallbackFormatter;
#else
                    formatter = PrimitiveObjectResolver.Instance.GetFormatter<T>();
                    #endif
                }
                else
                {
                    formatter = ContractlessStandardResolverCore.Instance.GetFormatter<T>();
                }
            }
        }
    }
}