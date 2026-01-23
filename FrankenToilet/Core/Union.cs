using System;
using JetBrains.Annotations;

namespace FrankenToilet.Core;
[PublicAPI]
public sealed class Union<T1, T2>
{
    public bool IsT1 { get; }
    public bool IsT2 => !IsT1;
    public T1? T1Obj => IsT1 ? field : throw new InvalidOperationException();
    public T2? T2Obj => IsT2 ? field : throw new InvalidOperationException();

    public Union(T1 item)
    {
        IsT1 = true;
        T1Obj = item;
    }
    public Union(T2 item)
    {
        IsT1 = false;
        T2Obj = item;
    }

    public Union(object obj)
    {
        switch (obj)
        {
            case T1 t1:
                IsT1 = true;
                T1Obj = t1;
                break;
            case T2 t2:
                IsT1 = false;
                T2Obj = t2;
                break;
            default:
                throw new ArgumentException(
                    $"Object must be of type {typeof(T1)} or {typeof(T2)}");
        }
    }
    public static implicit operator Union<T1, T2>(T1 item) => new(item);
    public static implicit operator Union<T1, T2>(T2 item) => new(item);
}

[PublicAPI]
public sealed class Union<T1, T2, T3>
{
    public enum UnionType : byte { T1, T2, T3 }

    public readonly UnionType unionType;
    public bool IsT1 => unionType == UnionType.T1;
    public bool IsT2 => unionType == UnionType.T2;
    public bool IsT3 => unionType == UnionType.T3;

    public T1 T1Obj => IsT1 ? field! : throw new InvalidOperationException();
    public T2 T2Obj => IsT2 ? field! : throw new InvalidOperationException();
    public T3 T3Obj => IsT3 ? field! : throw new InvalidOperationException();
    public object RawObj =>
        unionType switch
        {
            UnionType.T1 => T1Obj!,
            UnionType.T2 => T2Obj!,
            UnionType.T3 => T3Obj!,
            _            => throw new InvalidOperationException()
        };

    private Union(UnionType unionType) => this.unionType = unionType;

    public Union(T1 item) : this(UnionType.T1) => T1Obj = item;
    public Union(T2 item) : this(UnionType.T2) => T2Obj = item;
    public Union(T3 item) : this(UnionType.T3) => T3Obj = item;

    public Union(object obj)
    {
        switch (obj)
        {
            case T1 t1:
                unionType = UnionType.T1;
                T1Obj = t1;
                break;
            case T2 t2:
                unionType = UnionType.T2;
                T2Obj = t2;
                break;
            case T3 t3:
                unionType = UnionType.T3;
                T3Obj = t3;
                break;
            default:
                throw new ArgumentException(
                    $"Object must be of type {typeof(T1)} or {typeof(T2)} or {typeof(T3)}");
        }
    }

    public static implicit operator Union<T1, T2, T3>(T1 item) => new(item);
    public static implicit operator Union<T1, T2, T3>(T2 item) => new(item);
    public static implicit operator Union<T1, T2, T3>(T3 item) => new(item);

    public bool Equals(T1 other) => IsT1 && T1Obj!.Equals(other);
    public bool Equals(T2 other) => IsT2 && T2Obj!.Equals(other);
    public bool Equals(T3 other) => IsT3 && T3Obj!.Equals(other);
}