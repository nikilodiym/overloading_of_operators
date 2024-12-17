using System;

class Store
{
    private double area;

    public double Area
    {
        get { return area; }
        set
        {
            if (value >= 0)
                area = value;
            else
                throw new ArgumentException("Area cannot be negative.");
        }
    }

    public Store(double area)
    {
        Area = area;
    }

    public static Store operator +(Store store, double increase)
    {
        return new Store(store.Area + increase);
    }

    public static Store operator -(Store store, double decrease)
    {
        if (store.Area - decrease < 0)
            throw new ArgumentException("Resulting area cannot be negative.");
        return new Store(store.Area - decrease);
    }

    public static bool operator ==(Store store1, Store store2)
    {
        return store1.Area == store2.Area;
    }

    public static bool operator !=(Store store1, Store store2)
    {
        return !(store1 == store2);
    }

    public static bool operator <(Store store1, Store store2)
    {
        return store1.Area < store2.Area;
    }

    public static bool operator >(Store store1, Store store2)
    {
        return store1.Area > store2.Area;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Store other = (Store)obj;
        return this.Area == other.Area;
    }

    public override int GetHashCode()
    {
        return Area.GetHashCode();
    }

    public override string ToString()
    {
        return ($"Store with area: {Area} square meters");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Store store1 = new Store(100);
        Store store2 = new Store(150);

        Console.WriteLine(store1);
        Console.WriteLine(store2);

        store1 = store1 + 50;
        Console.WriteLine("After increasing area: " + store1);

        store2 = store2 - 20;
        Console.WriteLine("After decreasing area: " + store2);

        Console.WriteLine("store1 == store2: " + (store1 == store2));
        Console.WriteLine("store1 != store2: " + (store1 != store2));
        Console.WriteLine("store1 > store2: " + (store1 > store2));
        Console.WriteLine("store1 < store2: " + (store1 < store2));

        Console.WriteLine("store1.Equals(store2): " + store1.Equals(store2));
    }
}
