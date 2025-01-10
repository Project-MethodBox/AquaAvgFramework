namespace AquaAvgFramework.Global
{
    public class ValueManager
    {
        private readonly Dictionary<string, int> _values = new();

        public static ValueManager Shared { get; set; } = new ValueManager();

        public void RegisterValue(string name, int value)
        {
            if (_values.ContainsKey("name"))
            {
                throw new ArgumentException("A value with the same name already exists." +
                                            " Please register this value with a different name");
            }

            _values.Add(name, value);
        }

        public bool UnregisterValue(string name) => _values.Remove(name);

        public int GetValue(string name) => _values[name];

        public bool ReSetValue(string name, int value)
        {
            if (!_values.ContainsKey(name)) return false;
            _values[name] = value;
            return true;
        }
    }
}
