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

            // Console.WriteLine(DayOfWeekResult("Sat", 23));

            string[] results = fibSequence(10);
          
            //PrintToScreen(string.Format("Welcome to the Fruit Basket State Machine! {0}", Environment.NewLine));

            //_fruitBasketService = new FruitBasketService();

            //PrintToScreen("Adding one apple...");

            //AddFruit(new Apple());

            //PrintToScreen("Adding another apple...");

            //AddFruit(new Apple());

            //ListAllFruitItems();

            //PrintToScreen("Adding a strawberry...");

            //AddFruit(new Strawberry());

            //PrintToScreen("Adding an orange...");

            //AddFruit(new Orange());

            //ListAllFruitItems();

            //PrintToScreen("Removing a pineapple...");

            //RemoveFruit(new Pineapple());

            //PrintToScreen("Removing an apple...");

            //RemoveFruit(new Apple());

            //ListAllFruitItems();

            //PrintToScreen("Adding a pineapple...");

            //AddFruit(new Pineapple());

            //PrintToScreen("Adding an apple...");

            //AddFruit(new Apple());

            //ListAllFruitItems();





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
            if (_fruitBasketService.RemvoeFruitItemFromBasket(fruitItem))
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

        private static string[] fibSequence(int fibSeqUenceRequest)
        {
            IList<string> fibList = new List<string> { "0", "1" };
            Int64 getNextResult = 0;
           

            for (int i = 0; i < fibSeqUenceRequest - 2; i++)
            {
                
                getNextResult = Convert.ToInt64(fibList[i]) + Convert.ToInt64(fibList[i + 1]);
                fibList.Add(getNextResult.ToString());
            }

            return (string[])fibList.ToArray();
        }


        private static string DayOfWeekResult(string S, int K)
        {


            string dayOfWeekResult = string.Empty;
            int startDOW = 0;
            int dayOfWeekBuffer = 0;


                switch(S)
                {     


                        case "Sun":
                            startDOW = 0;
                            break;

                        case "Mon":
                            startDOW = 1;
                            break;

                        case "Tue":
                            startDOW = 2;
                            break;

                        case "Wed":
                            startDOW = 3;
                            break;

                        case "Thur":
                            startDOW = 4;
                            break;

                        case "Fri":
                            startDOW = 5;
                            break;

                        case "Sat":
                            startDOW = 6;
                            break;
                    }

                    dayOfWeekBuffer = (startDOW + K) % 7;


                    return ((DayOfWeek)dayOfWeekBuffer).ToString().Substring(0,3);
        }
    }
}
