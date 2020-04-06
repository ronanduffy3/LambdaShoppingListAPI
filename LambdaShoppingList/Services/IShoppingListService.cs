using LambdaShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaShoppingList.Services
{
    public interface IShoppingListService
    {
        // This interface includes the two services , adding and removing to the dictionary
        // Could of potentially implemented DynamoDB here but I decided to use a dictionary and store it locally as it was easier to demonstrate

        Dictionary<string, int> GetItemsFromShoppingList();
        void AddItemsToShoppingList(ShoppingListModel shoppingList);
        void RemoveItem(string name);
    }
}
