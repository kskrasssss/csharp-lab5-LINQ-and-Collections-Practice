namespace Lab5;

public static class SampleData
{
    public static List<BankAccount> Accounts => new()
    {
        new("UA-0001", "Іван Петренко",    "UAH", 120000m, false, "Deposit", 5,  1),
        new("UA-0002", "Олена Коваль",     "USD", 75000m,  false, "Current", 25, 1),
        new("UA-0003", "Марія Шевченко",   "EUR", 64000m,  false, "Deposit", 12, 2),
        new("UA-0004", "Андрій Бойко",     "USD", 8000m,   true,  "Current", 30, 2),
        new("UA-0005", "Сергій Мельник",   "EUR", 52000m,  false, "Current", 8,  1),
        new("UA-0006", "Ольга Ткаченко",   "UAH", 15000m,  false, "Current", 22, 3),
        new("UA-0007", "Дмитро Кравчук",   "USD", 52000m,  false, "Deposit", 3,  3),
        new("UA-0008", "Наталія Лисенко",  "EUR", 9500m,   false, "Current", 18, 2),
        new("UA-0009", "Тарас Олійник",    "UAH", 300000m, true,  "Deposit", 2,  1),
        new("UA-0010", "Юлія Гончар",      "EUR", 110000m, false, "Deposit", 27, 3),
        new("UA-0011", "Віктор Савчук",    "USD", 20000m,  false, "Current", 14, 2),
        new("UA-0012", "Катерина Мороз",   "EUR", 49999m,  false, "Current", 6,  1),
    };

    public static List<BankBranch> Branches => new()
    {
        new(1, "Центральне відділення", "Київ"),
        new(2, "Західне відділення",    "Львів"),
        new(3, "Південне відділення",   "Одеса"),
        new(4, "Нове відділення",       "Чернівці"), // без рахунків: для GroupJoin
    };
}