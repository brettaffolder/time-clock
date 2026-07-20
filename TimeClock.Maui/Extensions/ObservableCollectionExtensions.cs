using System.Collections.ObjectModel;

namespace TimeClock.Maui.Extensions;

public static class ObservableCollectionExtensions
{
    extension<TSource>(ObservableCollection<TSource> source)
    {
        public void AddRange(IEnumerable<TSource> items)
        {
            foreach (TSource? item in items)
            {
                source.Add(item);
            }
        }

        public void SortBy<TKey>(Func<TSource, TKey> keySelector)
        {
            IEnumerable<TSource> items = [.. source.OrderBy(keySelector)];

            source.Clear();

            foreach (TSource? item in items)
            {
                source.Add(item);
            }
        }

        public void SortByDescending<TKey>(Func<TSource, TKey> keySelector)
        {
            IEnumerable<TSource> items = [.. source.OrderByDescending(keySelector)];

            source.Clear();

            foreach (TSource? item in items)
            {
                source.Add(item);
            }
        }
    }
}
