namespace Lab_5;

public static class Task3Demo
{
    private const string InputPath = "Data/task3_input.txt";

    public static void Run()
    {
        var map = new BiDirectionalMap();

        foreach (var line in File.ReadAllLines(InputPath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            var parts = line.Split(';');
            if (parts.Length != 2 || !int.TryParse(parts[1], out int value))
            {
                Console.WriteLine($"Пропущено некоректний рядок: {line}");
                continue;
            }

            if (!map.Add(parts[0].Trim(), value))
                Console.WriteLine($"Не додано (дублікат ключа або значення): {line}");
        }

        PrintMap("Початковий стан", map);

        // Безпечний доступ
        if (map.TryGetValue("Alice", out int id)) Console.WriteLine($"\nAlice -> {id}");
        if (map.TryGetKey(104, out string? name)) Console.WriteLine($"104 -> {name}");
        Console.WriteLine($"Ключ 'Zed' існує: {map.ContainsKey("Zed")}");

        // Додавання
        Console.WriteLine($"Додати Grace;106: {map.Add("Grace", 106)}");
        Console.WriteLine($"Додати Heidi;106 (значення зайняте): {map.Add("Heidi", 106)}");

        // Оновлення
        Console.WriteLine($"Оновити Bob -> 202: {map.Update("Bob", 202)}");
        Console.WriteLine($"Оновити Bob -> 101 (зайняте): {map.Update("Bob", 101)}");

        // Вилучення
        Console.WriteLine($"Видалити Charlie: {map.Remove("Charlie")}");
        Console.WriteLine($"Видалити за значенням 105: {map.RemoveByValue(105)}");

        PrintMap("Підсумковий стан", map);
        Console.WriteLine($"\nСловники узгоджені: {map.IsConsistent()}");
    }

    private static void PrintMap(string title, BiDirectionalMap map)
    {
        Console.WriteLine($"\n--- {title} (відсортовано за ключем першого словника) ---");
        foreach (var pair in map.SortedByKey())
        {
            map.TryGetKey(pair.Value, out string? back);
            Console.WriteLine($"{pair.Key,-10} -> {pair.Value,-5} | зворотний: {pair.Value} -> {back}");
        }
    }
}