﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Jst4Code.FunctionalCS.Composition
{
    public static class FunctionComposition
    {
        // Input: TResult1 -> TResult2, T -> TResult1.
        // Output: T -> TResult2
        public static Func<T, TResult2> After<T, TResult1, TResult2>(
            this Func<TResult1, TResult2> second, Func<T, TResult1> first) =>
            value => second(first(value));

        // Input: T -> TResult1, TResult1 -> TResult2.
        // Output: T -> TResult2
        public static Func<T, TResult2> Then<T, TResult1, TResult2>(
            this Func<T, TResult1> first, Func<TResult1, TResult2> second) =>
            value => second(first(value));

        // Input, T, T -> TResult.
        // Output TResult.
        public static TResult Map<T, TResult>(this T value, Func<T, TResult> function) =>
            function(value);
    }
}
