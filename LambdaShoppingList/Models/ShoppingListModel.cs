using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LambdaShoppingList.Models
{
    public class ShoppingListModel
    {
        
        // Created a model for the requests I'm going to make in the working example or via POSTMan

        // Name of the item to be added to the shopping list
        public string Name { get; set; }
        // Quantity of the item to be added to the item
        public int Quantity { get; set; }
    }
}
