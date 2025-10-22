namespace Inventory;

public static class InventoryHelper
{
    public static bool IsLowStock(int quantity)
    {
        if (quantity < 10)
        {
            return true;
        }
        return false;
    }

    public static decimal CalculateTotalValue(decimal price, int quantity)
    {
        return price * quantity;
    }

    public static string FormatProductCode(string name)
    {
        name = name.ToUpper();
        string formattedName = "PROD-" + name;
        return formattedName;
    }
}