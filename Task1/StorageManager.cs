namespace Lab_5;

public class StorageManager<T>
{
    private readonly List<T> _items = new();

    public int Count => _items.Count;

    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
    }

    public bool Remove(T item) => _items.Remove(item);

    // Видаляє всі елементи за критерієм, повертає кількість видалених.
    // Йдемо з кінця, щоб видалення не зсувало ще не перевірені індекси.
    public int RemoveWhere(Func<T, bool> criterion)
    {
        int removed = 0;
        for (int i = _items.Count - 1; i >= 0; i--)
        {
            if (criterion(_items[i]))
            {
                _items.RemoveAt(i);
                removed++;
            }
        }
        return removed;
    }

    // Пошук першого елемента за критерієм (null/default, якщо не знайдено).
    public T? FindBy(Func<T, bool> criterion)
    {
        foreach (var item in _items)
        {
            if (criterion(item)) return item;
        }
        return default;
    }

    // Фільтрація лише циклами, без LINQ. Повертає нову колекцію тільки для читання.
    public IReadOnlyList<T> Filter(Func<T, bool> predicate)
    {
        var result = new List<T>();
        foreach (var item in _items)
        {
            if (predicate(item)) result.Add(item);
        }
        return result.AsReadOnly();
    }
}