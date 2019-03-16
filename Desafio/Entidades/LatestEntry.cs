namespace Desafio.Entidades
{
    public class LatestEntry<T, K> where K : System.IComparable
    {
        public int Index { get; set; }
        public T Value { get; set; }
        public K Sorter { get; set; }

        public LatestEntry()
        {
            Index = default(int);
            Value = default(T);
            Sorter = default(K);
        }
    }
}
