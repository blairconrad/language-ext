﻿using System;
using LanguageExt;
using static LanguageExt.Prelude;

public static class __Tuple3
{
    /// <summary>
    /// Append an extra item to the tuple
    /// </summary>
    public static Tuple<T1, T2, T3, T4> Append<T1, T2, T3, T4>(this Tuple<T1, T2, T3> self, T4 fourth) =>
        Tuple(self.Item1, self.Item2, self.Item3, fourth);

    /// <summary>
    /// Sum
    /// </summary>
    public static int Sum(this Tuple<int, int, int> self) =>
        self.Item1 + self.Item2 + self.Item3;

    /// <summary>
    /// Sum
    /// </summary>
    public static double Sum(this Tuple<double, double, double> self) =>
        self.Item1 + self.Item2 + self.Item3;

    /// <summary>
    /// Sum
    /// </summary>
    public static float Sum(this Tuple<float, float, float> self) =>
        self.Item1 + self.Item2 + self.Item3;

    /// <summary>
    /// Sum
    /// </summary>
    public static decimal Sum(this Tuple<decimal, decimal, decimal> self) =>
        self.Item1 + self.Item2 + self.Item3;

    /// <summary>
    /// Map to R
    /// </summary>
    public static R Map<T1, T2, T3, R>(this Tuple<T1, T2, T3> self, Func<T1, T2, T3, R> map) =>
        map(self.Item1, self.Item2, self.Item3);

    /// <summary>
    /// Map to tuple
    /// </summary>
    public static Tuple<R1, R2, R3> Map<T1, T2, T3, R1, R2, R3>(this Tuple<T1, T2, T3> self, Func<Tuple<T1, T2, T3>, Tuple<R1, R2, R3>> map) =>
        map(self);

    /// <summary>
    /// Tri-map to tuple
    /// </summary>
    public static Tuple<R1, R2, R3> Map<T1, T2, T3, R1, R2, R3>(this Tuple<T1, T2, T3> self, Func<T1, R1> firstMap, Func<T2, R2> secondMap, Func<T3, R3> thirdMap) =>
        Tuple(firstMap(self.Item1),secondMap(self.Item2), thirdMap(self.Item3));

    /// <summary>
    /// First item-map to tuple
    /// </summary>
    public static Tuple<R1, T2, T3> MapFirst<T1, T2, T3, R1>(this Tuple<T1, T2, T3> self, Func<T1, R1> firstMap) =>
        Tuple(firstMap(self.Item1), self.Item2, self.Item3);

    /// <summary>
    /// Second item-map to tuple
    /// </summary>
    public static Tuple<T1, R2, T3> MapSecond<T1, T2, T3, R2>(this Tuple<T1, T2, T3> self, Func<T2, R2> secondMap) =>
        Tuple(self.Item1, secondMap(self.Item2), self.Item3);

    /// <summary>
    /// Second item-map to tuple
    /// </summary>
    public static Tuple<T1, T2, R3> MapThird<T1, T2, T3, R3>(this Tuple<T1, T2, T3> self, Func<T3, R3> thirdMap) =>
        Tuple(self.Item1, self.Item2, thirdMap(self.Item3));

    /// <summary>
    /// Map to tuple
    /// </summary>
    public static Tuple<R1, R2, R3> Select<T1, T2, T3, R1, R2, R3>(this Tuple<T1, T2, T3> self, Func<Tuple<T1, T2, T3>, Tuple<R1, R2, R3>> map) =>
        map(self);

    /// <summary>
    /// Iterate
    /// </summary>
    public static Unit Iter<T1, T2, T3>(this Tuple<T1, T2, T3> self, Action<T1, T2, T3> func)
    {
        func(self.Item1, self.Item2, self.Item3);
        return Unit.Default;
    }

    /// <summary>
    /// Iterate
    /// </summary>
    public static Unit Iter<T1, T2, T3>(this Tuple<T1, T2, T3> self, Action<T1> first, Action<T2> second, Action<T3> third)
    {
        first(self.Item1);
        second(self.Item2);
        third(self.Item3);
        return Unit.Default;
    }

    /// <summary>
    /// Fold
    /// </summary>
    public static S Fold<T1, T2, T3, S>(this Tuple<T1, T2, T3> self, S state, Func<S, T1, T2, T3, S> fold) =>
        fold(state, self.Item1, self.Item2, self.Item3);
    
    /// <summary>
    /// Tri-fold
    /// </summary>
    public static S Fold<T1, T2, T3, S>(this Tuple<T1, T2, T3> self, S state, Func<S,T1,S> firstFold, Func<S,T2,S> secondFold, Func<S, T3, S> thirdFold) =>
        thirdFold(secondFold(firstFold(state,self.Item1),self.Item2),self.Item3);

    /// <summary>
    /// Tri-fold
    /// </summary>
    public static S FoldBack<T1, T2, T3, S>(this Tuple<T1, T2, T3> self, S state, Func<S, T3, S> firstFold, Func<S, T2, S> secondFold, Func<S, T1, S> thirdFold) =>
        thirdFold(secondFold(firstFold(state, self.Item3), self.Item2), self.Item1);
}
