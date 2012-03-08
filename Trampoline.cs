using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ProjectEuler
{
    public static class Trampoline
    {

        public static Func<T1, T2, TResult> MakeTrampoline<T1, T2, TResult>(this Func<T1, T2, Bounce<T1, T2, TResult>> function)
        {
            Func<T1, T2, TResult> trampolined = (T1 arg1, T2 arg2) =>
            {
                T1 currentArg1 = arg1;
                T2 currentArg2 = arg2;

                while (true)
                {
                    Bounce<T1, T2, TResult> result = function(currentArg1, currentArg2);

                    if (result.HasResult)
                    {
                        return result.Result;
                    }
                    else
                    {
                        currentArg1 = result.Param1;
                        currentArg2 = result.Param2;
                    }
                }
            };

            return trampolined;
        }

        public static Func<T1, TResult> MakeTrampoline<T1, TResult>(this Func<T1, Bounce<T1, TResult>> function)
        {
            Func<T1, TResult> trampolined = (T1 arg1) =>
            {
                T1 currentArg1 = arg1;

                while (true)
                {
                    Bounce<T1, TResult> result = function(currentArg1);

                    if (result.HasResult)
                    {
                        return result.Result;
                    }
                    else
                    {
                        currentArg1 = result.Param1;
                    }
                }
            };

            return trampolined;
        }

        public static Func<T1, IEnumerable<TResult>> MakeLazyTrampoline<T1, TResult>(this Func<T1, Bounce<T1, TResult>> function)
        {
            return (T1 param1) => LazyTrampoline(function, param1);   
        }

        public static Func<T1, T2, IEnumerable<TResult>> MakeLazyTrampoline<T1, T2, TResult>(this Func<T1, T2, Bounce<T1, T2, TResult>> function)
        {
            return (T1 param1, T2 param2) => LazyTrampoline(function, param1, param2);
        }

        private static IEnumerable<TResult> LazyTrampoline<T1, TResult>(Func<T1, Bounce<T1, TResult>> function, T1 param1)
        {
            T1 currentParam1 = param1;

            while (true)
            {
                Bounce<T1, TResult> result = function(currentParam1);

                if (result.HasResult)
                {
                    yield return result.Result;
                }

                if (!result.Recurse)
                {
                    yield break;
                }

                currentParam1 = result.Param1;  
            }
        }

        private static IEnumerable<TResult> LazyTrampoline<T1, T2, TResult>(Func<T1, T2, Bounce<T1, T2, TResult>> function, T1 param1, T2 param2)
        {
            T1 currentParam1 = param1;
            T2 currentParam2 = param2;

            while (true)
            {
                Bounce<T1, T2, TResult> result = function(currentParam1, currentParam2);

                if (result.HasResult)
                {
                    yield return result.Result;
                }

                if (!result.Recurse)
                {
                    yield break;
                }

                currentParam1 = result.Param1;
                currentParam2 = result.Param2;
            }
        }

        public static Bounce<T1, T2, TResult> YieldAndRecurse<T1, T2, TResult>(TResult result, T1 arg1, T2 arg2)
        {
            return new Bounce<T1, T2, TResult>(arg1, arg2, result);
        }

        public static Bounce<T1, T2, TResult> YieldBreak<T1, T2, TResult>()
        {
            return new Bounce<T1, T2, TResult>();
        }

        public static Bounce<T1, T2, TResult> YieldBreak<T1, T2, TResult>(TResult result)
        {
            return new Bounce<T1, T2, TResult>(result);
        }

        public static Bounce<T1, T2, TResult> Recurse<T1, T2, TResult>(T1 arg1, T2 arg2)
        {
            return new Bounce<T1, T2, TResult>(arg1, arg2);
        }

        public static Bounce<T1, T2, TResult> ReturnResult<T1, T2, TResult>(TResult result)
        {
            return new Bounce<T1, T2, TResult>(result);
        }

        public static Bounce<T1, TResult> Recurse<T1, TResult>(T1 arg1)
        {
            return new Bounce<T1, TResult>(arg1);
        }

        public static Bounce<T1, TResult> YieldAndRecurse<T1, TResult>(TResult result, T1 arg1)
        {
            return new Bounce<T1, TResult>(arg1, result);
        }

        public static Bounce<T1, TResult> YieldBreak<T1, TResult>()
        {
            return new Bounce<T1, TResult>();
        }

        public static Bounce<T1, TResult> YieldBreak<T1, TResult>(TResult result)
        {
            return new Bounce<T1, TResult>(result);
        }
    }

    public struct Bounce<T1, TResult>
    {
        public T1 Param1 { get; private set; }
        public TResult Result { get; private set; }
        public bool HasResult { get; private set; }
        public bool Recurse { get; private set; }

        public Bounce(T1 param1)
            : this()
        {
            Param1 = param1;
            HasResult = false;
            Recurse = true;
        }

        public Bounce(T1 param1, TResult result)
            : this()
        {
            Param1 = param1;
            Result = result;
            HasResult = true;
            Recurse = true;
        }

        public Bounce(TResult result)
            : this()
        {
            Result = result;
            Recurse = false;
        }
    }

    public struct Bounce<T1, T2, TResult>
    {
        public T1 Param1 { get; private set; }
        public T2 Param2 { get; private set; }
        public TResult Result { get; private set; }
        public bool HasResult { get; private set; }
        public bool Recurse { get; private set; }

        public Bounce(T1 param1, T2 param2)
            : this()
        {
            Param1 = param1;
            Param2 = param2;
            HasResult = false;
            Recurse = true;
        }

        public Bounce(T1 param1, T2 param2, TResult result)
            : this()
        {
            Param1 = param1;
            Param2 = param2;
            Result = result;
            HasResult = true;
            Recurse = true;
        }

        public Bounce(TResult result)
            : this()
        {
            Result = result;
            HasResult = true;
            Recurse = false;
        }
    }



}
