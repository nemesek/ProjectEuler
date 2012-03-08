using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler
{
    public static class Numeric
    {
        public static IEnumerable<long> Range(long first, long last)
        {
            if (first == last)
            {
                yield return first;
            }
            else if (first < last)
            {
                for (long l = first; l <= last; l++)
                {
                    yield return l;
                }
            }
            else
            {
                for (long l = first; l >= last; l--)
                {
                    yield return l;
                }
            }
        }

        

       

        public static bool IsDivisibleBy(this int number, long factor)
        {
            return number % factor == 0;
        }

    //public static int Product(this IEnumerable<int> factors)
    //{
    //    int product = 1;

    //    foreach (var factor in factors)
    //    {
    //        product *= factor;
    //    }

    //    return product;
    //}

        public static IList<PrimeFactor> PrimeFactors(this int number)
        {
            return ContinueFactorisation(new List<PrimeFactor> { PrimeFactor.Unity }, number);
        }

        public static IList<PrimeFactor> PrimeFactors(this long number)
        {
            return ContinueFactorisation(new List<PrimeFactor> { PrimeFactor.Unity }, number);
        }

        private static IList<PrimeFactor> ContinueFactorisation(IList<PrimeFactor> partialFactorisation, long remainder)
        {
            var factorGreaterThan = partialFactorisation.Last().Prime;

            // find next factor of number
            long nextFactor = Range(factorGreaterThan + 1, remainder)
                .SkipWhile(x => remainder % x > 0).FirstOrDefault();

            if (nextFactor == remainder)
            {
                return ExtendList<PrimeFactor>(partialFactorisation, new PrimeFactor { Prime = remainder, Multiplicity = 1 });
            }
            else
            {
                // find its multiplicity
                long multiplicity = Enumerable.Range(1, Int32.MaxValue).TakeWhile(x => remainder % (long)Math.Pow(nextFactor, x) == 0).Last();
                long quotient = remainder / (long)Math.Pow(nextFactor, multiplicity);

                PrimeFactor nextPrimeFactor = new PrimeFactor { Prime = nextFactor, Multiplicity = multiplicity };
                var extendedList = ExtendList<PrimeFactor>(partialFactorisation, nextPrimeFactor);
                
                if (quotient == 1)
                {
                    return  extendedList;
                }
                else
                {
                    return ContinueFactorisation(extendedList, quotient);
                }
            }
        }

        private static IList<T> ExtendList<T>(IList<T> list, T additionalItem)
        {
            List<T> extendedList = new List<T>(list);
            extendedList.Add(additionalItem);

            return extendedList;
        }
    }
}
