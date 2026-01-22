using System;
using System.Collections.Generic;
using Mission3Assignment;

// Food Bank Inventory System
// Manages food donations, tracks inventory, and monitors expiration dates

List<FoodItem> inventory = new List<FoodItem>();

while (true)
{
    DisplayMenu();
    string? choice = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(choice))
    {
        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 4.\n");
        continue;
    }

    if (!int.TryParse(choice, out int menuChoice))
    {
        Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 4.\n");
        continue;
    }

    switch (menuChoice)
    {
        case 1:
            AddFoodItem();
            break;
        case 2:
            DeleteFoodItem();
            break;
        case 3:
            PrintFoodItems();
            break;
        case 4:
            Console.WriteLine("\nThank you for using the Food Bank Inventory System. Goodbye!");
            return;
        default:
            Console.WriteLine("\nInvalid choice. Please enter a number between 1 and 4.\n");
            break;
    }
}

void DisplayMenu()
{
    Console.WriteLine("\n=== Food Bank Inventory System ===");
    Console.WriteLine("1. Add Food Items");
    Console.WriteLine("2. Delete Food Items");
    Console.WriteLine("3. Print List of Current Food Items");
    Console.WriteLine("4. Exit the Program");
    Console.Write("\nPlease select an option (1-4): ");
}

void AddFoodItem()
{
    Console.WriteLine("\n--- Add Food Item ---");
    
    Console.Write("Enter the item name: ");
    string? name = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(name))
    {
        Console.WriteLine("Error: Item name cannot be empty. Item not added.\n");
        return;
    }

    Console.Write("Enter the item category (e.g., Canned Goods, Dairy, Produce): ");
    string? category = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(category))
    {
        Console.WriteLine("Error: Category cannot be empty. Item not added.\n");
        return;
    }

    int quantity = 0;
    bool validQuantity = false;
    while (!validQuantity)
    {
        Console.Write("Enter the quantity: ");
        string? qtyInput = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(qtyInput))
        {
            Console.WriteLine("Error: Quantity cannot be empty. Please try again.");
            continue;
        }

        if (!int.TryParse(qtyInput, out quantity))
        {
            Console.WriteLine("Error: Please enter a valid number for quantity.");
            continue;
        }

        if (quantity <= 0)
        {
            Console.WriteLine("Error: Quantity must be a positive number. Please try again.");
            continue;
        }

        validQuantity = true;
    }

    Console.Write("Enter the expiration date: ");
    string? expirationDate = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(expirationDate))
    {
        Console.WriteLine("Error: Expiration date cannot be empty. Item not added.\n");
        return;
    }

    FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
    inventory.Add(newItem);
    Console.WriteLine($"\nSuccessfully added: {name} ({quantity} units)\n");
}

void DeleteFoodItem()
{
    Console.WriteLine("\n--- Delete Food Item ---");
    
    if (inventory.Count == 0)
    {
        Console.WriteLine("There are no items in the inventory to delete.\n");
        return;
    }

    PrintFoodItems();
    
    int itemIndex = -1;
    bool validIndex = false;
    while (!validIndex)
    {
        Console.Write("\nEnter the number of the item to delete: ");
        string? indexInput = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(indexInput))
        {
            Console.WriteLine("Error: Please enter a number.");
            continue;
        }

        if (!int.TryParse(indexInput, out itemIndex))
        {
            Console.WriteLine("Error: Please enter a valid number.");
            continue;
        }

        if (itemIndex < 1 || itemIndex > inventory.Count)
        {
            Console.WriteLine($"Error: Please enter a number between 1 and {inventory.Count}.");
            continue;
        }

        validIndex = true;
    }

    FoodItem itemToDelete = inventory[itemIndex - 1];
    inventory.RemoveAt(itemIndex - 1);
    Console.WriteLine($"\nSuccessfully deleted: {itemToDelete.Name}\n");
}

void PrintFoodItems()
{
    Console.WriteLine("\n--- Current Food Items ---");
    
    if (inventory.Count == 0)
    {
        Console.WriteLine("The inventory is currently empty.\n");
        return;
    }

    Console.WriteLine($"\nTotal items in inventory: {inventory.Count}\n");
    Console.WriteLine("Item # | Name                | Category          | Quantity | Expiration Date");
    Console.WriteLine("-------|---------------------|-------------------|----------|----------------");
    
    for (int i = 0; i < inventory.Count; i++)
    {
        FoodItem item = inventory[i];
        Console.WriteLine($"{i + 1,6} | {item.Name,-19} | {item.Category,-17} | {item.Quantity,8} | {item.ExpirationDate}");
    }
    
    Console.WriteLine();
}
