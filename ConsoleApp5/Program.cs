Point p1 = new Point(3, 4);
p1.ShowData();

Counter count = new Counter();
Console.ReadLine();

Fraction f1 = new Fraction(1, 2);
Fraction f2 = new Fraction(3, 4);

Console.WriteLine($"f1: {f1.Numerator}/{f1.Denominator}");
Console.WriteLine($"f2: {f2.Numerator}/{f2.Denominator}");

// Task 1:
class Point
{
    public int x;
    public int y;

    public Point()
    {
        x = 0;
        y = 0;
    }
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public void ShowData()
    {
        Console.WriteLine($"Point: ({x}, {y})");
    }
}

//Task 2:
class Counter
{
    public Counter()
    {
        Console.Write("Başlangıç sayısını girin: ");
        int min = Convert.ToInt32(Console.ReadLine());

        Console.Write("Bitiş sayısını girin: ");
        int max = Convert.ToInt32(Console.ReadLine());

        int current = min;

        while (true)
        {
            Console.Clear();
            Console.WriteLine(current);
            Thread.Sleep(1000);
            Console.Clear();
            if (current == max)
            {
                current = min;
                Console.WriteLine(current);
                
                Console.WriteLine("Good bye!");
                break;
            }
            else
            {
                
                current++;
            }
        }
    }
}

//Task 4:

class Fraction
{
    private int _numerator; 
    private int _denominator; 

    public int Numerator
    {
        get { return _numerator; }
        set
        {
            if (value > 0 && value < 100)
                _numerator = value;
            else
                throw new ArgumentException("Number Error");
        }
    }

    public int Denominator
    {
        get { return _denominator; }
        set
        {
            if (value > 0 && value < 100)
                _denominator = value;
            else
                throw new ArgumentException("Denominator Error");
        }
    }

    public Fraction()
    {
        _numerator = 0;
        _denominator = 0;
    }

    public Fraction(int num, int den) : this()
    {
        Denominator = den;
        Numerator = num;
    }

    public Fraction(Fraction other) : this(other.Numerator, other.Denominator)
    {
        Console.WriteLine("Ctor Copy");
    }

    public Fraction Multiply(Fraction other)
    {
        int numerator = this._numerator * other._numerator;
        int denominator = this._denominator * other._denominator;

        return new Fraction(numerator, denominator);
    }

    public Fraction Add(Fraction other)
    {
        int denominator = this._denominator;
        int numerator = this._numerator + other._numerator;
        if (this._denominator != other._denominator)
        {
            denominator = this._denominator * other._denominator;
            numerator = (this._numerator * other._denominator) + (this._denominator * other._numerator);
        }

        return new Fraction(numerator, denominator);
    }

    public Fraction Minus(Fraction other)
    {
        int denominator = this._denominator;
        int numerator = this._numerator - other._numerator;
        if (this._denominator != other._denominator)
        {
            denominator = this._denominator * other._denominator;
            numerator = (this._numerator * other._denominator) - (this._denominator * other._numerator);
        }

        return new Fraction(numerator, denominator);
    }

    public Fraction Divide(Fraction other)
    {
        int denominator = this._denominator * other._numerator;
        int numerator = this._numerator * other._denominator;

        return new Fraction(numerator, denominator);
    }

    public Fraction Simplify()
    {
        int gcd = GCD(_numerator, _denominator);
        return new Fraction(_numerator / gcd, _denominator / gcd);
    }

    private int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }
}