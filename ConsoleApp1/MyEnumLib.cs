using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace ConsoleApp1
{
    
    public static class MyEnumLib
    {
        public static TSource Aggregate<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func)
        {
            TSource result = default;
            foreach (var val in source)
            {
                result=func(result, val); 
            }
            return result; 
        }

        public static TAccumulate Aggregate<TSource, TAccumulate>(this IEnumerable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            TAccumulate result = seed;
            foreach (var val in source)
            {
                result = func(result, val);
            }
            return result;
        }

        public static TResult Aggregate<TSource, TAccumulate, TResult>(
            this IEnumerable<TSource> source, 
            TAccumulate seed, 
            Func<TAccumulate, TSource, TAccumulate> func, 
            Func<TAccumulate, TResult> resultSelector)
        {
            TAccumulate result = seed;
            foreach (var val in source)
            {
                result = func(result, val);
            }
            return resultSelector(result);
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach (var val in source)
            {
                yield return selector(val);
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            int index = 0;
            foreach (var val in source)
            {
                yield return selector(val, index++);
            }
        }
        
        public static IEnumerable<TResult> SelectMany<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var val in source)
            {
                foreach (var v in selector(val))
                {
                    yield return v;
                }
            }
        }

        public static IEnumerable<TResult> SelectMany<TSource, TCollection, TResult>(this IEnumerable<TSource> source,
            Func<TSource, IEnumerable<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            foreach (var val in source)
            {
                foreach (var v in collectionSelector(val))
                {
                    yield return resultSelector(val, v);
                }
            }
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source)
        {
            foreach (var val in source)
            {
                return true;
            }
            return false;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var val in source)
            {
                if (!predicate(val))
                {
                    return false;
                }
            }
            return true;
        }

        public static IEnumerable<TSource> Append<TSource>(this IEnumerable<TSource> source, TSource element)
        {
            foreach (var val in source)
            {
                yield return val;
            }
            yield return element;
        }

        public static IEnumerable<TSource> AsEnumerable<TSource>(this IEnumerable<TSource> source)
        {
            foreach (var val in source)
            {
                yield return val;
            }
        }

        public static double Average<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector)
        {
            int count=default;
            int result = default;
            foreach (var val in source)
            {
                count++;
                result += selector(val);
            }
            return (double)result / count;
        }
                
        public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
        {
            foreach (var val in source)
            {
                yield return (TResult)val;
            }
        }

        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            foreach (var val in first)
            {
                yield return val;
            }
            foreach (var val in second)
            {
                yield return val;
            }
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
        {
            foreach (var val in source)
            {
                if (val.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            foreach (var val in source)
            {
                if (comparer.Equals(val, value))
                {
                    return true;
                }
            }
            return false;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            int counter = default;
            foreach (var val in source)
            {
                if (predicate(val))
                {
                    counter++;
                }
            }
            return counter;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            int counter = default;
            foreach (var val in source)
            {
                counter++;
            }
            return counter;
        }

        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source, TSource defaultValue)
        {
            if (source.Any())
            {
                foreach (var val in source)
                {
                    yield return val;
                }
            }
            else
            {
                yield return defaultValue;
            }
        }

        public static IEnumerable<TSource> DefaultIfEmpty<TSource>(this IEnumerable<TSource> source)
        {
            if (source.Any())
            {
                foreach (var val in source)
                {
                    yield return val;
                }
            }
            else
            {
                yield return default;
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
        {
            var unique = new HashSet<TSource>();
            foreach (var val in source)
            {
                if (!unique.Contains(val))
                {
                    unique.Add(val);
                    yield return val;    
                }
            }
        }

        public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
        {
            var unique = new HashSet<TSource>(comparer);
            foreach (var val in source)
            {
                if (!unique.Contains(val))
                {
                    unique.Add(val);
                    yield return val;
                }
            }
        }

        public static TSource ElementAt<TSource>(this IEnumerable<TSource> source, int index)
        {
            int i = default;
            foreach (var val in source)
            {
                if (i == index)
                {
                    return val;
                }
                i++;
            }
            throw new ArgumentOutOfRangeException();
        }

        public static TSource ElementAtOrDefault<TSource>(this IEnumerable<TSource> source, int index)
        {
            int i = default;
            foreach (var val in source)
            {
                if (i == index)
                {
                    return val;
                }
                i++;
            }
            return default;
        }
        
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            foreach (var valFirst in first)
            {
                if (!second.Contains(valFirst))
                {
                    yield return valFirst;
                }
            }
        }

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            foreach (var valFirst in first)
            {
                if (!second.Contains(valFirst, comparer))
                {
                    yield return valFirst;
                }
            }
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source)
        {
            foreach (var val in source)
            {
                return val;
            }
            throw new InvalidOperationException();
        }

        public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var val in source)
            {
                if (predicate(val))
                {
                    return val;
                }
            }
            throw new InvalidOperationException();
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            foreach (var val in source)
            {
                return val;
            }
            return default;
        }

        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var val in source)
            {
                if (predicate(val))
                {
                    return val;
                }
            }
            return default;
        }

        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            var buffer = new Dictionary<TKey, MyGrouping<TKey, TSource>>();
            foreach (var val in source)
            {
                TKey key = keySelector(val);
                buffer.TryAdd(key, new MyGrouping<TKey, TSource>(key));
                buffer[key].Add(val);
            }
            foreach (var g in buffer)
            {
                yield return g.Value;
            }
        }

        public static IEnumerable<IGrouping<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, 
            Func<TSource, TKey> keySelector, 
            Func<TSource, TElement> elementSelector, 
            IEqualityComparer<TKey> comparer)
        {
            var buffer = new Dictionary<TKey, MyGrouping<TKey, TElement>>(comparer);
            foreach (var val in source)
            {
                TKey key = keySelector(val);
                buffer.TryAdd(key, new MyGrouping<TKey, TElement>(key));
                buffer[key].Add(elementSelector(val));
            }
            foreach (var g in buffer)
            {
                yield return g.Value;
            }
        }

        public static IEnumerable<TResult> GroupBy<TSource, TKey, TElement, TResult>(
            this IEnumerable<TSource> source, 
            Func<TSource, TKey> keySelector, 
            Func<TSource, TElement> elementSelector, 
            Func<TKey, IEnumerable<TElement>, TResult> resultSelector, 
            IEqualityComparer<TKey> comparer)
        {
            var buffer = new Dictionary<TKey, MyGrouping<TKey, TElement>>(comparer);
            foreach (var val in source)
            {
                TKey key = keySelector(val);
                buffer.TryAdd(key, new MyGrouping<TKey, TElement>(key));
                buffer[key].Add(elementSelector(val));
            }
            foreach (var g in buffer)
            {
                yield return resultSelector(g.Key, g.Value);
            }
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector)
        {
            foreach (TOuter outerVal in outer)
            {
                foreach (TInner innerVal in inner)
                {
                    TKey keyOuter = outerKeySelector(outerVal);
                    TKey keyInner = innerKeySelector(innerVal);
                    if (keyOuter.Equals(keyInner))
                    {
                        yield return resultSelector(outerVal, innerVal);
                    }
                }
            }
        }

        public static IEnumerable<TResult> Join<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, TInner, TResult> resultSelector,
            IEqualityComparer<TKey> comparer)
        {
            foreach (TOuter outerVal in outer)
            {
                foreach (TInner innerVal in inner)
                {
                    TKey keyOuter = outerKeySelector(outerVal);
                    TKey keyInner = innerKeySelector(innerVal);
                    if (comparer.Equals(keyOuter, keyInner))
                    {
                        yield return resultSelector(outerVal, innerVal);
                    }
                }
            }
        }

        public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(
            this IEnumerable<TOuter> outer,
            IEnumerable<TInner> inner,
            Func<TOuter, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
        {
            var buffer = new Dictionary<TOuter, MyGrouping<TOuter, TInner>>();
            foreach (TOuter outerVal in outer)
            {
                foreach (TInner innerVal in inner)
                {
                    TKey keyOuter = outerKeySelector(outerVal);
                    TKey keyInner = innerKeySelector(innerVal);
                    if (keyOuter.Equals(keyInner))
                    {
                        buffer.TryAdd(outerVal, new MyGrouping<TOuter, TInner>(outerVal));
                        buffer[outerVal].Add(innerVal);
                    }
                }
            }
            foreach (var g in buffer)
            {
                yield return resultSelector(g.Key, g.Value);
            }
        }

        public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> source, int count)
        {
            int i = default;
            foreach (var val in source)
            {
                if (i < count)
                {
                    yield return val;
                    i++;
                }
            }
        }

        public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var val in source)
            {
                if (predicate(val))
                {
                    yield return val;
                }
            }
        }

        public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> source, int count)
        {
            int i = default;
            foreach (var val in source)
            {
                if (i >= count)
                {
                    yield return val;
                }
                i++;
            }
        }

        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            int i = default;
            foreach (var val in source)
            {
                if (!predicate(val, i))
                {
                    yield return val;
                }
                i++;
            }
        }

        public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var val in source)
            {
                if (!predicate(val))
                {
                    yield return val;
                }
            }
        }

        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            foreach (var val1 in first)
            {
                foreach (var val2 in second)
                {
                    if (val1.Equals(val2))
                    {
                        yield return val1;
                    }
                }
            }
        }

        public static bool SequenceEqual<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            int i = default;
            foreach (var val1 in first)
            {
                if (!(bool)second.ElementAtOrDefault(i++)?.Equals(val1))
                {
                    return false;
                }
            }
            return true;
        }
              
        //public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        //{
        //    var data = new OrderedEnumerable<TSource>(source);
        //    return data;
        //}
    }

    //public class OrderedEnumerable<T> : IOrderedEnumerable<T>
    //{
    //    private IEnumerable<T> data;

    //    public OrderedEnumerable(IEnumerable<T> source)
    //    {
    //        data = source ?? throw new ArgumentNullException(nameof(source));
    //    }

    //    public IOrderedEnumerable<T> CreateOrderedEnumerable<TKey1>(Func<T, TKey1> keySelector, IComparer<TKey1> comparer, bool descending)
    //    {
            
    //    }

    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return data.GetEnumerator();
    //    }
    //}

    public class MyGrouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        private readonly TKey _key;
        private readonly List<TSource> list;

        public MyGrouping(TKey key)
        {
            list = new List<TSource>();
            _key = key;
        }

        public TKey Key => _key;

        public IEnumerator<TSource> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TSource source)
        {
            list.Add(source);
        }
    }
}