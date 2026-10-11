using Lab_5;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("\n=== Лабораторна робота №5 (варіант 8) ===");
    Console.WriteLine("1 - Generic StorageManager<BankAccount>");
    Console.WriteLine("2 - Списки (L1, L2 -> L3)");
    Console.WriteLine("3 - Двонаправлений словник");
    Console.WriteLine("4 - LINQ: базові запити");
    Console.WriteLine("5 - LINQ: агрегація та з'єднання");
    Console.WriteLine("0 - Вихід");
    Console.Write("Ваш вибір: ");

    switch (Console.ReadLine())
    {
        case "1": Task1Demo.Run(); break;
        case "2": Task2Demo.Run(); break;
        case "0": return;
        default: Console.WriteLine("Невірний вибір"); break;
    }
}