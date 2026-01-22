using System;

namespace Mission3Assignment;

/// <summary>
/// Represents a food item in the inventory system.
/// Stores name, category, quantity, and expiration date.
/// </summary>
public class FoodItem
{
    public string Name { get; }
    public string Category { get; }
    public int Quantity { get; }
    public string ExpirationDate { get; }

    /// <summary>
    /// Constructor to initialize a FoodItem with all required information.
    /// </summary>
    /// <param name="name">The name of the food item</param>
    /// <param name="category">The category of the food item</param>
    /// <param name="quantity">The quantity of the food item (must be positive)</param>
    /// <param name="expirationDate">The expiration date of the food item</param>
    public FoodItem(string name, string category, int quantity, string expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity;
        ExpirationDate = expirationDate;
    }
}
