string? response = " ";
int result = 0;
bool running = true;
while (running)
{
    try
    {
        Console.Write("Enter first number: ");
        response = Console.ReadLine();
        if(response == "exit" || response == "Exit")
        {
            running = false;
            return;
        }
        int num1 = int.Parse(response);
        Console.Write("Enter operation (+, -, *, /): ");
        char operation = char.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        response = Console.ReadLine();
        int num2 = int.Parse(response);

        if (operation == '+')
        {
            result = num1 + num2;
        }
        else if (operation == '-')
        {
            result = num1 - num2;
        }
        else if (operation == '*')
        {
            result = num1 * num2;
        }
        else if (operation == '/')
        {
            result = num1 / num2;
        }
        else
        {
            Console.WriteLine("Invalid Operation");
        }
        Console.WriteLine($"Result: {num1} {operation} {num2} = {result} ");
        Console.WriteLine();
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