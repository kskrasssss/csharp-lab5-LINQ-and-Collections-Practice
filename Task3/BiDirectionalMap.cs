namespace Lab_5;

public class BiDirectionalMap
{
    private readonly Dictionary<string, int> _forward = new();
    private readonly Dictionary<int, string> _reverse = new();

    public int Count => _forward.Count;

    public bool ContainsKey(string key) => _forward.ContainsKey(key);
    public bool ContainsValue(int value) => _reverse.ContainsKey(value);
    public bool TryGetValue(string key, out int value) => _forward.TryGetValue(key, out value);
    public bool TryGetKey(int value, out string key) => _reverse.TryGetValue(value, out key!);

    // Синхронне додавання: і ключ, і значення мають бути унікальними.
    public bool Add(string key, int value)
    {
        if (_forward.ContainsKey(key) || _reverse.ContainsKey(value)) return false;
        _forward.Add(key, value);
        _reverse.Add(value, key);
        return true;
    }

    // Оновлення значення для існуючого ключа в обох словниках.
    public bool Update(string key, int newValue)
    {
        if (!_forward.TryGetValue(key, out int oldValue)) return false;
        if (oldValue == newValue) return true;
        if (_reverse.ContainsKey(newValue)) return false; // значення вже зайняте

        _reverse.Remove(oldValue);
        _reverse.Add(newValue, key);
        _forward[key] = newValue;
        return true;
    }

    // Синхронне вилучення за ключем.
    public bool Remove(string key)
    {
        if (!_forward.TryGetValue(key, out int value)) return false;
        _forward.Remove(key);
        _reverse.Remove(value);
        return true;
    }

    // Синхронне вилучення за значенням.
    public bool RemoveByValue(int value)
    {
        if (!_reverse.TryGetValue(value, out string? key)) return false;
        return Remove(key);
    }

    // Пари першого словника, відсортовані за ключем.
    public IEnumerable<KeyValuePair<string, int>> SortedByKey() =>
        _forward.OrderBy(p => p.Key, StringComparer.Ordinal);

    // Перевірка, що обидва словники відповідають один одному.
    public bool IsConsistent()
    {
        if (_forward.Count != _reverse.Count) return false;
        foreach (var pair in _forward)
        {
            if (!_reverse.TryGetValue(pair.Value, out string? key) || key != pair.Key)
                return false;
        }
        return true;
    }
}