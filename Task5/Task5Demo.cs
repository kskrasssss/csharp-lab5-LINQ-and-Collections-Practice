namespace Lab_5;

public static class Task5Demo
{
    public static void Run()
    {
        List<BankAccount> accounts = SampleData.Accounts;
        List<BankBranch> branches = SampleData.Branches;

        // 1. Групування: кількість рахунків у кожному відділенні
        var counts = accounts
            .GroupBy(a => a.BranchId)
            .Select(g => new { BranchId = g.Key, Count = g.Count() })
            .OrderBy(x => x.BranchId);
        Console.WriteLine("--- 1. Кількість рахунків за відділеннями ---");
        foreach (var c in counts)
            Console.WriteLine($"Відділення {c.BranchId}: {c.Count}");

        // 2. Агрегація в групах: сумарний баланс на відділення
        var sums = accounts
            .GroupBy(a => a.BranchId)
            .Select(g => new { BranchId = g.Key, Total = g.Sum(a => a.Balance) })
            .OrderBy(x => x.BranchId);
        Console.WriteLine("\n--- 2. Сумарний баланс за відділеннями ---");
        foreach (var s in sums)
            Console.WriteLine($"Відділення {s.BranchId}: {s.Total}");

        // 3. Join (inner): номер рахунку, баланс, назва відділення
        var joined = accounts.Join(
            branches,
            a => a.BranchId,
            b => b.Id,
            (a, b) => new { a.Iban, a.Balance, BranchName = b.Name });
        Console.WriteLine("\n--- 3. Join: рахунок + відділення ---");
        foreach (var j in joined)
            Console.WriteLine($"{j.Iban} | {j.Balance} | {j.BranchName}");

        // 4. GroupJoin: для кожного відділення список його рахунків
        var grouped = branches.GroupJoin(
            accounts,
            b => b.Id,
            a => a.BranchId,
            (b, accs) => new { b.Name, Accounts = accs.ToList() });
        Console.WriteLine("\n--- 4. GroupJoin: відділення та їх рахунки ---");
        foreach (var g in grouped)
        {
            var list = g.Accounts.Count == 0
                ? "(рахунків немає)"
                : string.Join(", ", g.Accounts.Select(a => a.Iban));
            Console.WriteLine($"{g.Name}: {list}");
        }

        // 5. Aggregate: загальний баланс усіх рахунків (числова сума без урахування валюти)
        decimal total = accounts.Aggregate(0m, (acc, a) => acc + a.Balance);
        Console.WriteLine($"\n--- 5. Aggregate: загальний баланс = {total}");
    }
}