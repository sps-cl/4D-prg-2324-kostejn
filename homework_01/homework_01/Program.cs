public class CalculatorApp
{
    static void Main()
    {
        Console.Write("Zadej první číslo: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Zadej druhé číslo: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Zadej operaci: +, -, magic: ");
        string operace = Console.ReadLine();

        IOperation x;

        switch (operace)
        {
            case "+":
                x = new OpAdd();
                break;
            case "-":
                x = new OpSub();
                break;
            case "magic":
                x = new OpMagic();
                break;
            default:
                Console.Write("Rozbil jsi to :( (Zadal jsi nefunkční operaci)");
                return; //zde jsem podle ChatGPT změnil 'break' na 'return' protože se zde objevila chyba
        }


        CalculatorContext calculator = new CalculatorContext(x);
        Console.Write($"Výsledek je: {calculator.executeStrategy(a, b)}");
    }
}

public interface IOperation
{
    int Execute(int a, int b);
}

public class OpSub : IOperation
{
    public int Execute(int a, int b)
    {
        return a - b;
    }
}

public class OpAdd : IOperation
{
    public int Execute(int a, int b)
    {
        return a + b;
    }
}

public class OpMagic : IOperation
{
    public int Execute(int a, int b)
    {
        return a * b;
    }
}

public class CalculatorContext
{

    private IOperation opStrategy;

    public IOperation operace
    {
        get { return opStrategy; }
    }
    public CalculatorContext(IOperation opStrategy)
    {
        this.opStrategy = opStrategy;
    }

    public int executeStrategy(int a, int b)
    {
        return opStrategy.Execute(a, b);
    }
}
