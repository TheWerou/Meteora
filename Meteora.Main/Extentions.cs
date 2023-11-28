namespace Meteora.Main
{
    public static class Extentions
    {
        public static IEnumerable<int> AllIndexesOf(this List<char> str, char searchChar)
        {
            int minIndex = str.IndexOf(searchChar);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchChar, minIndex + 1);
            }
        }

        public static T RandomElement<T>(this IEnumerable<T> enumerable)
        {
            return enumerable.RandomElementUsing<T>(new Random());
        }

        public static T RandomElementUsing<T>(this IEnumerable<T> enumerable, Random rand)
        {
            var index = rand.Next(0, enumerable.Count());
            return enumerable.ElementAt(index);
        }
    }
}
