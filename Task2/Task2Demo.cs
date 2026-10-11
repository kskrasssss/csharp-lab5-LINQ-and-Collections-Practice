using System.Text.RegularExpressions;

namespace Lab_5;

public static class Task2Demo
{
    private const string InputPath = "Data/task2_input.txt";
    private const string OutputPath = "Data/task2_output.txt";
    private const int ItemsPerLine = 7;

    public static void Run()
    {
        var lines = File.ReadAllLines(InputPath);
        if (lines.Length < 2)
        {
            Console.WriteLine("Файл має містити два рядки: L1 та L2.");
            return;
        }

        List<string> l1 = ParseWords(lines[0]);
        List<string> l2 = ParseWords(lines[1]);

        // L3 = слова з L1, які є в L2, у зворотному порядку відносно L1
        var inL2 = new HashSet<string>(l2);
        var l3 = new List<string>();
        for (int i = l1.Count - 1; i >= 0; i--)
        {
            if (inL2.Contains(l1[i])) l3.Add(l1[i]);
        }

        Console.WriteLine("L1: " + string.Join(" ", l1));
        Console.WriteLine("L2: " + string.Join(" ", l2));
        Console.WriteLine("L3: " + string.Join(" ", l3));

        SaveInChunks(OutputPath, l3, ItemsPerLine);
        Console.WriteLine($"\nРезультат збережено у {OutputPath} ({ItemsPerLine} елементів у рядку).");
    }

    private static List<string> ParseWords(string line)
    {
        var words = new List<string>();
        foreach (var w in line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
        {
            if (!Regex.IsMatch(w, "^[A-Z]+$"))
                throw new FormatException($"Слово '{w}' має складатися лише з великих латинських літер.");
            words.Add(w);
        }
        return words;
    }

    private static void SaveInChunks(string path, List<string> items, int perLine)
    {
        var outLines = new List<string>();
        for (int i = 0; i < items.Count; i += perLine)
        {
            int count = Math.Min(perLine, items.Count - i);
            outLines.Add(string.Join(" ", items.GetRange(i, count)));
        }
        File.WriteAllLines(path, outLines);
    }
}