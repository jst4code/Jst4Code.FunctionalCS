﻿namespace Jst4Code.Monads
{
    public abstract class Option<T>
    {
        public static implicit operator Option<T>(T value)
            => value == null
                ? new None<T>()
                : (Option<T>)new Some<T>(value);

        public static implicit operator Option<T>(None none) =>
            new None<T>();
    }

    public class Some<T> : Option<T>
    {
        private T Content { get; }

        public Some(T content)
            => Content = content;

        public static implicit operator T(Some<T> value)
            => value.Content;
    }

    public class None<T> : Option<T> { }

    public class None
    {
        public static None Value { get; } = new None();
        private None() { }
    }
}
