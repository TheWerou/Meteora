namespace Meteora.Main.Extentions
{
    public static class IndexExtention
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
    }
}
