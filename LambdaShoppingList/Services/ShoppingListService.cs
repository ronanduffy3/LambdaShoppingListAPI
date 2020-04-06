using LambdaShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaShoppingList.Services
{
    public class ShoppingListService : IShoppingListService
    {
        // This file contains the methods for the services and inherits from the interface IShoppingListService


        // Creates a dictionary
        private readonly Dictionary<string, int> _shoppingListStorage = new Dictionary<string, int>();

        // Method for the GET request where we return the shopping list
        public Dictionary<string, int> GetItemsFromShoppingList()
        {
            return _shoppingListStorage;
        }

        // Method for POST request. 
        public void AddItemsToShoppingList(ShoppingListModel shoppingList)
        {
            // Pass the shopping list model and then target the Name and Quantity properties
            _shoppingListStorage.Add(shoppingList.Name, shoppingList.Quantity);
        }

        // Method for the DELETE request
        public void RemoveItem(string shoppingListName)
        {
            _shoppingListStorage.Remove(shoppingListName);
             
        }
    }
}
