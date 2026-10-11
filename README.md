🇬🇧 **English** | 🇺🇦 [Українська](README.uk.md)

# 🏦 Bank Accounts Toolkit

A **C# / .NET** console application that demonstrates generics, collections and LINQ using bank accounts as the domain.

![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-6.0%2B-512BD4?logo=dotnet&logoColor=white)
![Platform](https://img.shields.io/badge/platform-Windows%20%7C%20Linux%20%7C%20macOS-lightgrey)

## 📖 About

The program consists of five independent modules launched from a main menu:

| Module | What it does |
|--------|--------------|
| **Storage** | A generic `StorageManager<T>` container: add, remove, find by key and filter by an arbitrary condition. Filtering returns a read-only result |
| **Lists** | Reads two word lists from a file, finds the common words, reverses their order and writes the result to a file, 7 words per line |
| **Bi-directional map** | A two-way dictionary: lookup by key and by value, with guaranteed consistency of both sides |
| **LINQ queries** | Filtering, sorting, pagination, first-match search and extremum search |
| **LINQ aggregation** | Grouping, per-group totals, and joining accounts with bank branches |

## 🛠 Tech stack

- **C#** and **.NET 6.0+**
- **Generics** and delegates (`Func<T, bool>`)
- **Collections:** `List<T>`, `Dictionary<TKey, TValue>`, `HashSet<T>`, `IReadOnlyList<T>`
- **LINQ:** `Where`, `OrderBy`, `Skip/Take`, `GroupBy`, `Join`, `GroupJoin`, `Aggregate`
- **File I/O:** `System.IO`
- **Git / GitHub** for version control

## 👤 Author

**_Kate Krasnikova_**
GitHub: [@kskrasssss](https://github.com/kskrasssss)

## ⬇️ Download

**With Git:**

```bash
git clone https://github.com/kskrasssss/csharp-lab5-LINQ-and-Collections-Practice
```

**Without Git:** on the repository page click **Code → Download ZIP**, extract the archive and open the folder in a terminal.

## ▶️ Run

1. Install the [.NET SDK 6.0 or newer](https://dotnet.microsoft.com/download).
2. Check the version:
```bash
   dotnet --version
```
3. From the project directory (the one containing the `.csproj` file) run:
```bash
   dotnet build
   dotnet run
```

> ⚠️ Run the app from the project root, because the input files are located via the relative path `Data/`.

## 🖥 Usage

After launch a menu appears. Enter a module number and press Enter. The console text is in Ukrainian:

| Input | Module |
|-------|--------|
| `1` | Generic `StorageManager<BankAccount>` |
| `2` | Lists (L1, L2 → L3) |
| `3` | Bi-directional dictionary |
| `4` | LINQ: basic queries |
| `5` | LINQ: aggregation and joins |
| `0` | Exit |

### Input files

| File | Format |
|------|--------|
| `Data/task2_input.txt` | Line 1: the first word list, line 2: the second. Words are uppercase Latin letters separated by spaces |
| `Data/task3_input.txt` | One `key;value` pair per line |

The **Lists** module writes its result to `Data/task2_output.txt`.

## 📁 Project structure

```text
├── Program.cs              # entry point and menu
├── Models/                 # BankAccount, BankBranch
├── Data/                   # sample data and input files
├── Task1/                  # StorageManager<T>
├── Task2/                  # list processing
├── Task3/                  # bi-directional dictionary
├── Task4/                  # LINQ: basic queries
└── Task5/                  # LINQ: grouping and joins
```

## 📝 License

Created for educational purposes. Feel free to use it.