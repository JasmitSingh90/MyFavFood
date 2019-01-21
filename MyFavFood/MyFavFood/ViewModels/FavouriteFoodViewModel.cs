
using System;
using System.Collections.Generic;
using System.Linq;

using MyFavFood.Helpers;
using MyFavFood.Helpers.Interfaces;
using MyFavFood.Model;
using MyFavFood.Repositories;

namespace MyFavFood.ViewModels
{
    public class FavouriteFoodViewModel : BaseModel
    {
        private readonly IFavouriteFoodService favouriteFoodService;

        public UserDetail UserInfo // Bindable user object to fill in details 
        {
            get { return AppGlobals.Instance.UserDetail; }
        }

        public string UserAge // Bindable user age field
        {
            get { return CalculateUserAge(); }
        }

        /// <summary>
        /// Init/assign the variables
        /// </summary>
        /// <param name="favouriteFoodService"></param>
        public FavouriteFoodViewModel(IFavouriteFoodService favouriteFoodService)
        {
            this.favouriteFoodService = favouriteFoodService; // Assign the page service

            // Get the favourite food items
            var favFoodItemlists = GetFavouriteFoodItems();

            // Add the favourite fooditems to the parent
            favouriteFoodService.AddFavouriteFoodItems(favFoodItemlists);
        }

        /// <summary>
        /// Get's the favourite food items
        /// </summary>
        /// <returns></returns>
        private List<FoodItem> GetFavouriteFoodItems()
        {
            List<FoodItem> favFoodItemlists = null;

            if (UserInfo != null && UserInfo.UserFavouriteFoodItemIdList != null &&
                UserInfo.UserFavouriteFoodItemIdList.Count > 0)
            {
                favFoodItemlists = new List<FoodItem>();

                // Get the actual liked food items
                var tempFavFoodItemlist = FoodItemsRepository.GetAvailableFoodItemList()
                    .Where(availFooditem => UserInfo.UserFavouriteFoodItemIdList
                    .Any(favfoodId => favfoodId == availFooditem.ItemId));

                // Map response to the model 
                foreach (var item in tempFavFoodItemlist)
                {
                    var foodItem = new FoodItem
                    {
                        FoodItemId = item.ItemId,
                        FoodItemName = item.ItemName
                    };

                    favFoodItemlists.Add(foodItem);
                }
            }

            return favFoodItemlists;
        }

        /// <summary>
        /// Calculate users age
        /// </summary>
        /// <returns></returns>
        public string CalculateUserAge()
        {
            int age = 0;
            age = DateTime.Now.Year - AppGlobals.Instance.UserDetail.DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < AppGlobals.Instance.UserDetail.DateOfBirth.DayOfYear)
                age = age - 1;

            return string.Format("{0} years", age);
        }
    }
}
