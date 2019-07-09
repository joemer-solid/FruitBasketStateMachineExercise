using System;
using System.Collections.Generic;
using System.Linq;

namespace fruitBasketStateMachine
{
    internal class Program
    {
        private static IFruitBasketService _fruitBasketService;

        static void Main(string[] args)
        {

            PrintToScreen(string.Format("Welcome to the Fruit Basket State Machine! {0}", Environment.NewLine));

            _fruitBasketService = new FruitBasketService();

            PrintToScreen("Adding one apple...");

            AddFruit(new Apple());

            PrintToScreen("Adding another apple...");

            AddFruit(new Apple());

            ListAllFruitItems();

            PrintToScreen("Adding a strawberry...");

            AddFruit(new Strawberry());

            PrintToScreen("Adding an orange...");

            AddFruit(new Orange());

            ListAllFruitItems();

            PrintToScreen("Removing a pineapple...");

            RemoveFruit(new Pineapple());

            PrintToScreen("Removing an apple...");

            RemoveFruit(new Apple());

            ListAllFruitItems();

            PrintToScreen("Adding a pineapple...");

            AddFruit(new Pineapple());

            PrintToScreen("Adding an apple...");

            AddFruit(new Apple());

            ListAllFruitItems();



            Console.Read();

        }


        private static void ListAllFruitItems()
        {
            PrintToScreen("***************************************************");

            PrintToScreen("Current fruit items selected:");
            FruitBasket fruitBasket = _fruitBasketService.GetCurrentBasketContents();

            PrintToScreen(fruitBasket.Print());


            PrintToScreen("***************************************************");



        }

        private static void RemoveFruit(FruitItem fruitItem)
        {
            if (_fruitBasketService.RemoveFruitItemFromBasket(fruitItem))
            {
                PrintToScreen(string.Format("Removed the following fruit item: {0}", fruitItem.Name));
            }
            else
            {
                PrintToScreen(string.Format("The following fruit item is not in the basket and cannot be removed: {0}", fruitItem.Name));
            }
        }


        private static void AddFruit(FruitItem fruitItem)
        {
            if(_fruitBasketService.AddFruitToBasket(fruitItem))
            {
                PrintToScreen(string.Format("Added the following fruit item: {0}", fruitItem.Name));
            }
            else
            {
                PrintToScreen(string.Format("The following fruit item already exists and cannot be added: {0}", fruitItem.Name));
            }
        }



        private static void PrintToScreen(string message)
        {
            Console.WriteLine(message);
        }
       
    }
}
