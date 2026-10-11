namespace Lab_5;

public static class Task4Demo
{
    public static void Run()
    {
        List<BankAccount> accounts = SampleData.Accounts;

        // 1. Фільтрація: активні рахунки із залишком понад 10000
        var active = accounts
            .Where(a => !a.IsBlocked && a.Balance > 10000m)
            .ToList();
        PrintAccounts("1. Активні рахунки, баланс > 10000", active);

        // 2. Сортування та проєкція: валюта (зростання), баланс (спадання) -> імена власників
        var owners = active
            .OrderBy(a => a.Currency)
            .ThenByDescending(a => a.Balance)
            .Select(a => a.OwnerName)
            .ToList();
        Console.WriteLine("\n--- 2. Власники: валюта ↑, баланс ↓ ---");
        owners.ForEach(Console.WriteLine);

        // 3. Пагінація: пропустити 3, взяти наступні 3 (стабільне сортування за IBAN)
        var page = accounts
            .OrderBy(a => a.Iban)
            .Skip(3)
            .Take(3)
            .ToList();
        PrintAccounts("3. Пагінація: Skip(3).Take(3)", page);

        // 4. Пошук одного елемента: перший рахунок у євро із залишком понад 50000
        var firstEur = accounts.FirstOrDefault(a => a.Currency == "EUR" && a.Balance > 50000m);
        Console.WriteLine("\n--- 4. Перший EUR-рахунок з балансом > 50000 ---");
        Console.WriteLine(firstEur is null ? "Такого рахунку немає" : firstEur.ToString());

        // 5. Екстремум: найбільша кількість щомісячних транзакцій
        var busiest = accounts.MaxBy(a => a.MonthlyTransactionsCount);
        Console.WriteLine("\n--- 5. Найбільше транзакцій на місяць ---");
        Console.WriteLine(busiest is null ? "Колекція порожня" : busiest.ToString());
    }

    private static void PrintAccounts(string title, IEnumerable<BankAccount> items)
    {
        Console.WriteLine($"\n--- {title} ---");
        foreach (var a in items)
            Console.WriteLine($"{a.Iban} | {a.OwnerName} | {a.Currency} | {a.Balance} | blocked={a.IsBlocked}");
    }
}