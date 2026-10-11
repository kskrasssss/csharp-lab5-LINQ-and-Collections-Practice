namespace Lab5;

public record BankAccount(
    string Iban,
    string OwnerName,
    string Currency,
    decimal Balance,
    bool IsBlocked,
    string AccountType,
    int MonthlyTransactionsCount,
    int BranchId);