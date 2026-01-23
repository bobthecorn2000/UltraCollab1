using System.Runtime.CompilerServices;

namespace FrankenToilet.Core.Extensions;

public static class ValueExtensions
{
    extension<T>(T source) where T : struct
    {
        public T? AsNullable() => source;
        public StrongBox<T> Box() => new(source);
    }
}