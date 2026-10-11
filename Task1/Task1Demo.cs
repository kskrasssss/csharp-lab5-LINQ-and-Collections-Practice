namespace Lab_5;

public static class Task1Demo
{
    public static void Run()
    {
        var storage = new StorageManager<BankAccount>();
        foreach (var account in SampleData.Accounts) storage.Add(account);
        Console.WriteLine($"Рахунків у сховищі: {storage.Count}");

        // Пошук за IBAN
        Console.Write("Введіть IBAN для пошуку (Enter = UA-0003): ");
        var iban = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(iban)) iban = "UA-0003";
        var found = storage.FindBy(a => a.Iban == iban);
        Console.WriteLine(found is null ? "Рахунок не знайдено" : found.ToString());

        // Три предикати варіанту
        Func<BankAccount, bool> highBalance = a => a.Balance >= 50000m;
        Func<BankAccount, bool> activeUsd = a => a.Currency == "USD" && !a.IsBlocked;
        Func<BankAccount, bool> depositOrActive =
            a => a.AccountType == "Deposit" || a.MonthlyTransactionsCount > 20;

        Print("1. balance >= 50000", storage.Filter(highBalance));
        Print("2. currency == USD AND isBlocked == false", storage.Filter(activeUsd));
        Print("3. accountType == Deposit OR transactions > 20", storage.Filter(depositOrActive));

        // Видалення
        int removed = storage.RemoveWhere(a => a.Iban == "UA-0004");
        Console.WriteLine($"\nВидалено рахунків: {removed}. Залишилось: {storage.Count}");
    }

    private static void Print(string title, IReadOnlyList<BankAccount> items)
    {
        Console.WriteLine($"\n--- {title} (знайдено: {items.Count}) ---");
        foreach (var a in items)
            Console.WriteLine($"{a.Iban} | {a.OwnerName} | {a.Currency} | {a.Balance} | {a.AccountType} | tx={a.MonthlyTransactionsCount}");
    }
}