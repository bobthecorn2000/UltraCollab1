using System;
using JetBrains.Annotations;

namespace FrankenToilet.Core.Extensions;

[PublicAPI]
public static class ClassExtensions
{
    extension<T>(T source) where T : class
    {
        public WeakReference<T> AsWeakReference() => new(source);
    }
}