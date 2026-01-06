namespace AquaAvgFramework.Global
{
    internal class Numbering
    {
        private Dictionary<string, int> numbersList;

        public static Numbering Shared = new Numbering();

        private Numbering()
        {
            numbersList = new Dictionary<string, int>();
        }

        public int GetNumber(string identifier)
        {
            numbersList.TryAdd(identifier, 0);
            return numbersList[identifier]++;
        }
    }
}