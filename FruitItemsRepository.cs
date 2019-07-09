using System;
using System.Collections.Generic;
using System.Text;

namespace fruitBasketStateMachine
{
    internal interface IRepository<T, P>
    {
        T Add(P p);

        T Remove(P p);

        IEnumerable<P> SelectAll();

    }
    internal sealed class FruitItemsRepository : IRepository<bool, FruitItem>
    {
        private IStateContext<FruitBasket> _fruitBasketState;

        internal FruitItemsRepository(IStateContext<FruitBasket> fruitBasketState)
        {
            _fruitBasketState = fruitBasketState;
        }

        bool IRepository<bool, FruitItem>.Add(FruitItem p)
        {
            bool result = false;

            if(_fruitBasketState.CanBeAdded(p))
            {
                _fruitBasketState.Context.Items[p.Key] = p;

                result = true;
            }

            return result;
        }

        bool IRepository<bool, FruitItem>.Remove(FruitItem p)
        {
            bool result = false;

            if (_fruitBasketState.CanBeRemoved(p))
            {
                _fruitBasketState.Context.Items.Remove(p.Key);

                result = true;
            }

            return result;
        }

        IEnumerable<FruitItem> IRepository<bool, FruitItem>.SelectAll()
        {
            return _fruitBasketState.Context.Items.Values;
        }
    }
}
