namespace Aegis.WebOld.Helpers
{
    public static class Extentions
    {
        public static bool AddUnique<T>(this List<T> list, T item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
                return true;
            }
            return false;
        }
    }
}
