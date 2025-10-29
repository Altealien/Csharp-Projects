while (true)
{
    try
    {
        Console.Write("Enter first number: ");
        string? input1 = Console.ReadLine();
        if(input1?.ToLower() == "exit")
        {
            Console.WriteLine("Calculator closed");
            break;
        }
        int num1 = int.Parse(input1);
        Console.Write("Enter operation (+, -, *, /): ");
        char operation = char.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        string? input2 = Console.ReadLine();
        int num2 = int.Parse(input2);
        int result = operation switch{
            '+' => num1 + num2,
            '-' => num1 - num2,
            '*' => num1 * num2,
            '/' => num1 / num2,
            _ => throw new InvalidOperationException($"Invalid Operation: {operation}")
        };
        Console.WriteLine($"Result: {num1} {operation} {num2} = {result}\n");
    }
    catch (FormatException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (OverflowException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (DivideByZeroException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }

}
Console.ReadKey();