using System;

public class Journal
{
    private int employeeCount;

    public int EmployeeCount
    {
        get { return employeeCount; }
        set
        {
            if (value >= 0)
                employeeCount = value;
            else
                throw new ArgumentException("Employee count cannot be negative.");
        }
    }

    public string Name { get; set; }

    public Journal(string name, int initialEmployeeCount)
    {
        Name = name;
        EmployeeCount = initialEmployeeCount;
    }

    public static Journal operator +(Journal journal, int count)
    {
        journal.EmployeeCount += count;
        return journal;
    }

    public static Journal operator -(Journal journal, int count)
    {
        if (journal.EmployeeCount - count < 0)
            throw new InvalidOperationException("Employee count cannot become negative.");
        journal.EmployeeCount -= count;
        return journal;
    }

    public static bool operator ==(Journal j1, Journal j2)
    {
        return j1.EmployeeCount == j2.EmployeeCount;
    }

    public static bool operator !=(Journal j1, Journal j2)
    {
        return !(j1 == j2);
    }

    public static bool operator <(Journal j1, Journal j2)
    {
        return j1.EmployeeCount < j2.EmployeeCount;
    }

    public static bool operator >(Journal j1, Journal j2)
    {
        return j1.EmployeeCount > j2.EmployeeCount;
    }

    public override bool Equals(object obj)
    {
        if (obj is Journal otherJournal)
        {
            return this.EmployeeCount == otherJournal.EmployeeCount;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return EmployeeCount.GetHashCode();
    }

    public override string ToString()
    {
        return $"Journal: {Name}, Employee Count: {EmployeeCount}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Journal journal1 = new Journal("Tech Times", 10);
        Journal journal2 = new Journal("Daily News", 15);

        Console.WriteLine(journal1);
        Console.WriteLine(journal2);

        journal1 += 5;
        Console.WriteLine("After adding employees: " + journal1);

        journal2 -= 7;
        Console.WriteLine("After removing employees: " + journal2);

        Console.WriteLine("Are employee counts equal? " + (journal1 == journal2));
        Console.WriteLine("Is journal1 > journal2? " + (journal1 > journal2));
        Console.WriteLine("Is journal1 < journal2? " + (journal1 < journal2));

        Console.WriteLine("Using Equals: " + journal1.Equals(journal2));
    }
}
