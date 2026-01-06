namespace AquaAvgFramework.Global;

/// <summary>
/// The parameter manager of the engine, used to manage all parameters and variables
/// </summary>
public class ValueManager
{
    private readonly Dictionary<string, int> _values = new();

    /// <summary>
    /// Static objects in singleton mode
    /// </summary>
    public static ValueManager Shared { get; set; } = new ValueManager();

    /// <summary>
    /// Register new parameters in the manager
    /// </summary>
    /// <param name="name">Name of parameter</param>
    /// <param name="value">The value of the parameter</param>
    /// <param name="isSystem">Keep this param false</param>
    /// <exception cref="ArgumentException">Triggered when parameter name is invalid</exception>
    /// <exception cref="InvalidOperationException">Triggered when parameter names are repeated</exception>
    public void RegisterValue(string name, int value, bool isSystem = false)
    {
        if (!isSystem && (name == string.Empty || name[0] == '%'))
            throw new ArgumentException("The parameter name is invalid, please use a different name");
        if (_values.ContainsKey("name"))
            throw new InvalidOperationException("A value with the same name already exists.Please register this value with a different name");

        _values.Add(name, value);
    }

    /// <summary>
    /// Unregister new parameters in the manager
    /// </summary>
    /// <param name="name">Name of parameter</param>
    /// <returns>Result of whether the deletion was successful</returns>
    public bool UnregisterValue(string name) => _values.Remove(name);

    /// <summary>
    /// Get the value of the specified parameter
    /// </summary>
    /// <param name="name">Name of parameter</param>
    /// <returns>Value of the specified parameter</returns>
    public int GetValue(string name) => _values[name];

    /// <summary>
    /// Update the value of the specified parameter
    /// </summary>
    /// <param name="name">Name of parameter</param>
    /// <param name="value">The new value that hope to set for the parameter</param>
    /// <returns>Result of whether the update was successful</returns>
    public bool UpdateValue(string name, int value)
    {
        if (!_values.ContainsKey(name)) return false;
        _values[name] = value;
        return true;
    }
}