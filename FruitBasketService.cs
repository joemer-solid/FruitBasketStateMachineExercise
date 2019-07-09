using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace fruitBasketStateMachine
{

    internal interface IFruitBasketService
    {
        bool AddFruitToBasket(FruitItem fruitItem);

        bool RemoveFruitItemFromBasket(FruitItem fruitItem);

        FruitBasket GetCurrentBasketContents();
    }
    internal sealed class FruitBasketService : IFruitBasketService
    {
        private IStateContext<FruitBasket> _fruitBasketState;
        private IRepository<bool, FruitItem> _fruitBasketRepository;

        internal FruitBasketService()
        {
            _fruitBasketState = new FruitBasketState(new FruitBasket());
            _fruitBasketRepository = new FruitItemsRepository(_fruitBasketState);
        }

        public bool AddFruitToBasket(FruitItem fruitItem)
        {
            bool result = false;

            result =_fruitBasketRepository.Add(fruitItem);

            return result;
        }


        public FruitBasket GetCurrentBasketContents()
        {
            return _fruitBasketState.Context;
        }

        public bool RemoveFruitItemFromBasket(FruitItem fruitItem)
        {
            bool result = false;

            result = _fruitBasketRepository.Remove(fruitItem);

            return result;
        }


    }
}
