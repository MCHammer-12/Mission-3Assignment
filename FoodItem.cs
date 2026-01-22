using System;
using System.Collections.Generic;

namespace Mission3Assignment;

public class FoodItem
{
    // Makes FoodItem objects immutable -- they cannot be changed after created.
    public string itemName { get;}
    public string itemCategory { get;}
    public int itemQuantity { get;}
    public string itemExpDate { get;}

    // Constructor for the FoodItem Class
    public FoodItem(string name, string category, int quantity, string expDate)
    {
        this.itemName = name;
        this.itemCategory = category;
        this.itemQuantity = quantity;
        this.itemExpDate = expDate;
    }
    
    public void AddItem(List<FoodItem> foodItemsList)
    {
        // Get Item Information to Add
        Console.WriteLine("What is the item name? ");
        string itemName = Console.ReadLine();
        Console.WriteLine("What is the item category? ");
        string itemCategory = Console.ReadLine();

        int itemQuantity;
        while (true)
        {
            Console.WriteLine("What is the item quantity? ");
            string qtyInput = Console.ReadLine();
                
            // Try to parse the input as int
            if (int.TryParse(qtyInput, out itemQuantity) && itemQuantity > 0)
            {
                break; // valid positive number, exit loop
            }
                
            // If parsing fails or number is non-positive
            Console.WriteLine("Please enter a valid positive number.");
        }
        Console.WriteLine("What is the item expiration date? ");
        string itemExpDate = Console.ReadLine();
            
        // Declare and Instantiate a new FoodItem Object, pass needed variables to constructor.
        FoodItem itemObj = new FoodItem(itemName, itemCategory, itemQuantity, itemExpDate);
            
        // Add object to foodItemsList
        foodItemsList.Add(itemObj);
        Console.WriteLine("Item added successfully!");
    }
    
    public void DeleteItem(List<FoodItem> foodItemsList)
    {
        int index = 0;

        // System check to make sure there are items in the system prior to allowing the user to delete an item.
        if (foodItemsList.Count > 0)
        {
            Console.WriteLine("\nITEMS");
            // Print out items inside the foodItemsList.
            for (int i = 0; i < foodItemsList.Count; i++)
            {
                // Prints Item list with each individual menu item
                Console.WriteLine((i + 1) + ": " + foodItemsList[i].itemName 
                                  + " | " + foodItemsList[i].itemCategory 
                                  + " | " + foodItemsList[i].itemQuantity 
                                  + " | " + foodItemsList[i].itemExpDate);
            }
            // Get input on what item to delete
            Console.WriteLine(("\nWhat item would you like to delete? "));
            index = int.Parse(Console.ReadLine());
        
            // Convert the menu option to its corresponding list location
            foodItemsList.RemoveAt(index - 1);
            Console.WriteLine("Item deleted successfully!");
        }
        else
        {
            Console.WriteLine("There are currently no items in the system, so there is nothing to delete.");
        }
    }
    
    public void ViewItems(List<FoodItem> foodItemsList)
    {
        // If list is empty, print out message
        if (foodItemsList.Count == 0)
        {
            Console.WriteLine("\nThere are currently no items in the system, so there's nothing to see here.");
        }
        else
        {
            Console.WriteLine("\nITEMS");
            // Print out items inside the foodItemsList.
            for (int i = 0; i < foodItemsList.Count; i++)
            {
                // Prints Item list with each individual menu item
                Console.WriteLine((i + 1) + ": " + foodItemsList[i].itemName 
                                  + " | " + foodItemsList[i].itemCategory 
                                  + " | " + foodItemsList[i].itemQuantity 
                                  + " | " + foodItemsList[i].itemExpDate);
            }
        }
    }
}