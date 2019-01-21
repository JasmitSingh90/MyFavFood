
using System.Collections.Generic;

using MyFavFood.Model;

namespace MyFavFood.Helpers.Interfaces
{
    public interface IFavouriteFoodService
    {
        void AddFavouriteFoodItems(List<FoodItem> favFoodItemList);
    }
}
