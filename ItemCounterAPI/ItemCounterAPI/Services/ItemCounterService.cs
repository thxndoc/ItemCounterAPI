namespace ItemCounterAPI.Services
{
    public class ItemCounterService
    {
        public Dictionary<T, int> CountItems<T>(IEnumerable<T> items)
        {
            var itemCounts = new Dictionary<T, int>();

            foreach (var item in items)
            {
                if (itemCounts.ContainsKey(item))
                    itemCounts[item]++;
                else
                    itemCounts[item] = 1;
            }

            return itemCounts;
        }
    }
}
