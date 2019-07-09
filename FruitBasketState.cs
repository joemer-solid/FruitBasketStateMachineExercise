using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fruitBasketStateMachine
{
    internal enum Fruit
    {
        Apple,      
        Orange,      
        Pineapple,
        Strawberry       
    }
    internal sealed class FruitBasket
    {
        internal FruitBasket()
        {
            Items = new Dictionary<Fruit, FruitItem>();
        }

        internal string Print()
        {
            StringBuilder builder = new StringBuilder();

            IList<FruitItem> fruitItems = Items.Values.OrderBy(x => x.Name).ToList();

            foreach(FruitItem fruitItem in fruitItems)
            {
                builder.Append(fruitItem.ToString());
                builder.AppendLine();
            }

            return builder.ToString();
          
        }


        internal IDictionary<Fruit, FruitItem> Items { get; set; }
    }

    #region Domain models

    internal abstract class FruitItem 
    {        
        internal FruitItem(Fruit key, string fruitName)
        {
            Key = key;
            Name = fruitName;
        }

        internal Fruit Key { get; set; }

        internal string Name { get; set; }

        public override string ToString()
        {
            return string.Format("Item Id: {0} Item Name: {1}", ((int)Key).ToString(), Name);
        }
    }

    internal sealed class Apple : FruitItem
    {
        internal Apple() : base(Fruit.Apple, "Apple") { }
    }

    internal sealed class Strawberry : FruitItem
    {
        internal Strawberry() : base(Fruit.Strawberry, "Strawberry") { }
    }

    internal sealed class Orange : FruitItem
    {
        internal Orange() : base(Fruit.Orange, "Orange") { }
    }


    internal sealed class Pineapple : FruitItem
    {
        internal Pineapple() : base(Fruit.Pineapple, "Pineapple") { }
    }

    #endregion


    #region State Management

    internal interface IStateContext<T>
    {
        bool CanBeAdded(FruitItem fruitItem);

        bool CanBeRemoved(FruitItem fruitItem);

        T Context { get; set; }

    }


    internal sealed class FruitBasketState : IStateContext<FruitBasket>
    {
        private FruitBasket _currentContext;
      
        internal FruitBasketState(FruitBasket currentFruitBasket)
        {
            _currentContext = currentFruitBasket;
        }
       
        FruitBasket IStateContext<FruitBasket>.Context
        {
            get { return _currentContext; }

            set { _currentContext = value; }
        }

        bool IStateContext<FruitBasket>.CanBeAdded(FruitItem fruitItem)
        {
            return !_currentContext.Items.ContainsKey(fruitItem.Key);
        }

        bool IStateContext<FruitBasket>.CanBeRemoved(FruitItem fruitItem)
        {
            return _currentContext.Items.ContainsKey(fruitItem.Key);
        }
    }

    #endregion
}
