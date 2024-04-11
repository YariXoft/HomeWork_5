using System;

public class Journal
{
    // скількі працівників
    private int employeeCount;

    public int EmployeeCount
    { // доступ до кількості працівників
        get { return employeeCount; }
        set
        {

            if (value >= 0)
            {
                employeeCount = value;
            }
            else // якщо меньше нуля
            {
                Console.WriteLine("Кількість працівників не може бути менше нуля.");
            }
        }
    }

    // Пер. оператор +
    public static Journal operator +(Journal journal, int increment)
    {
        journal.EmployeeCount += increment;
        return journal;
    }

    // Пер. оператор -
    public static Journal operator -(Journal journal, int decrement)
    {
        journal.EmployeeCount -= decrement;
        return journal;
    }

    // Пер. оператор ==
    public static bool operator ==(Journal journal1, Journal journal2)
    {
        return journal1.EmployeeCount == journal2.EmployeeCount;
    }

    // Пер. оператор !=
    public static bool operator !=(Journal journal1, Journal journal2)
    {
        return !(journal1 == journal2);
    }

    // Пер. оператор <
    public static bool operator <(Journal journal1, Journal journal2)
    {
        return journal1.EmployeeCount < journal2.EmployeeCount;
    }

    // Пер. оператор > (до пари з <)
    public static bool operator >(Journal journal1, Journal journal2)
    {
        return journal1.EmployeeCount > journal2.EmployeeCount;
    }

    // Перевантажили Equals
    public override bool Equals(object obj)
    {
        if (obj is Journal other)
        {
            return this == other;
        }
        return false;
    }

    // Перевантажили GetHashCode
    public override int GetHashCode()
    {
        return EmployeeCount.GetHashCode();
    }

    // Перевантажили ToString
    public override string ToString()
    {
        return $"Журнал з {EmployeeCount} працiвниками.";
    }
}

class Program
{
    static void Main()
    {
        Journal journal1 = new Journal();
        Journal journal2 = new Journal();

        // скільки працівників
        journal1.EmployeeCount = 10;
        journal2.EmployeeCount = 15;

        // Перевірка
        Console.WriteLine($"\nЖурнал 1 == Журнал 2: {journal1 == journal2}");
        Console.WriteLine($"Журнал 1 != Журнал 2: {journal1 != journal2}");
        Console.WriteLine($"Журнал 1 < Журнал 2: {journal1 < journal2}");
        Console.WriteLine($"Журнал 1 > Журнал 2: {journal1 > journal2}");
        journal1 += 5;// перевантажуємо + тест
        journal2 -= 5;// перевантажуємо - тест

        Console.WriteLine($"\nПiсля змiни значень:\n");
        Console.WriteLine($"Журнал 1: {journal1}");
        Console.WriteLine($"Журнал 2: {journal2}\n");
    }
}
