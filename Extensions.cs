using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace ProjectEuler
{
public static class Extensions
{

    public static bool IsDivisibleBy(this long number, long factor)
    {
        return number % factor == 0;
    }

    public static IEnumerable<long> OddNumbersGreaterThan(this long prime)
    {
        return (prime + 2).Unfold(item => item + 2);
    }

    public static IEnumerable<int> To(this int first, int last)
    {
        if (first == last)
        {
            yield return first;
        }
        else if (first < last)
        {
            for (var l = first; l <= last; l++)
            {
                yield return l;
            }
        }
        else
        {
            for (var l = first; l >= last; l--)
            {
                yield return l;
            }
        }
    }

    public static IEnumerable<long> To(this long first, long last)
    {
        if (first == last)
        {
            yield return first;
        }
        else if (first < last)
        {
            for (var l = first; l <= last; l++)
            {
                yield return l;
            }
        }
        else
        {
            for (var l = first; l >= last; l--)
            {
                yield return l;
            }
        }
    }

    public static IEnumerable<T> RangeFrom<T>(this IList<T> list, int startIndex, int count)
    {
        for (var i = startIndex; i < startIndex + count; i++)
        {
            yield return list[i];
        }
    }

    public static bool IsPalindromic(this long number)
    {
        char[] characters = number.ToString().ToCharArray();
        return characters.SequenceEqual(characters.Reverse());
    }

    public static bool IsInteger(this string value) 
    {
        int number;
        return int.TryParse(value, out number);
    }

    public static bool IsEven(this int value)
    {
        return (value & 1) == 0;
    }

    public static bool IsEven(this long value)
    {
        return (value & 1) == 0;
    }

    public static int Gcd(this int a, int b)
    {
        if (b == 0)
        {
            return a;
        }
        else
        {
            return Gcd(b, a % b);
        }
    }

    public static int Product(this IEnumerable<int> factors)
    {
        int product = 1;

        foreach (var factor in factors)
        {
            product *= factor;
        }

        return product;
    }

    public static void DisplayAndPause(this object result)
    {
        Console.WriteLine(result);
        Console.ReadLine();
    }

    public static IEnumerable<string> ReadLines(this TextReader reader)
    {
        while (true)
        {
            yield return reader.ReadLine();
        }
    }

    public static IEnumerable<T> Validate<T>(this IEnumerable<T> sequence, Func<T,bool> predicate, string invalidItemMessage)
    {
        foreach (var item in sequence)
        {
            if (predicate(item))
            {
                yield return item;
            }
            else
            {
                Console.WriteLine(invalidItemMessage);
            }
        }
    }
    public static IEnumerable<T> Concat<T>(this IEnumerable<IEnumerable<T>> sequences)
    {
        return sequences.SelectMany(sequence => sequence);
    }

    public static IEnumerable<T> Concat<T>(this IEnumerable<T[]> sequences)
    {
        return Concat(sequences.Cast<IEnumerable<T>>());
    }

    public static IEnumerable<IEnumerable<T>> Zip<T>(this IEnumerable<IEnumerable<T>> sequences)
    {
        // get the enumerators for each sequence
        var enumerators = sequences.Select(sequence => sequence.GetEnumerator()).ToList();

        var activeEnumerators = new List<IEnumerator<T>>();
        var items = new List<T>();

        while (enumerators.Count > 0)
        {
            items.Clear();
            activeEnumerators.Clear();

            foreach (var enumerator in enumerators)
            {
                if (enumerator.MoveNext())
                {
                    items.Add(enumerator.Current);
                    activeEnumerators.Add(enumerator);
                }
            }

            if (items.Count > 0)
            {
                yield return items;
            }

            enumerators.Clear();
            enumerators.AddRange(activeEnumerators);
        }
    }

    public static long ToLong(this string value)
    {
        return long.Parse(value);
    }

    public static IEnumerable<int> Digits(this int number)
    {
        return number.ToString().ToCharArray().Select(character => int.Parse(character.ToString()));
    }

    public static T MaxItem<T, TCompare>(this IEnumerable<T> sequence, Func<T, TCompare> comparatorSelector) where TCompare : IComparable<TCompare>
    {
        T max = sequence.First();
        TCompare maxComparator = comparatorSelector(max);

        foreach (var item in sequence)
        {
            var comparator = comparatorSelector(item);

            if (comparator.CompareTo(maxComparator) > 0)
            {
                max = item;
                maxComparator = comparator;
            }
        }

        return max;

    }
}
}
