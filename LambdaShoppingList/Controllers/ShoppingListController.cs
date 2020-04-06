using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambdaShoppingList.Models;
using LambdaShoppingList.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LambdaShoppingList.Controllers
{
    // The route is where we target the app then, can be seen demonstrated in the working example projet
    [Route("v1/shoppingList")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;
        
        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        // Below I define the three API requests that I created, get, delete
       
        [HttpGet]
        public IActionResult GetShoppingList()
        {
            var result = _shoppingListService.GetItemsFromShoppingList();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddItemToShoppingList([FromBody] ShoppingListModel shoppingList)
        {
            _shoppingListService.AddItemsToShoppingList(shoppingList);

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteItemsFromShoppingList([FromBody] ShoppingListModel shoppingList)
        {
            _shoppingListService.RemoveItem(shoppingList.Name);

            return Ok();
        }

    }
}