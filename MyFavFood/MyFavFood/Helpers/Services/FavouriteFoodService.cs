
using System.Collections.Generic;

using Xamarin.Forms;

using MyFavFood.Helpers.Interfaces;
using MyFavFood.Model;

namespace MyFavFood.Helpers.Services
{
    public class FavouriteFoodService : IFavouriteFoodService
    {
        StackLayout favFoodItemsStackLayout;

        /// <summary>
        /// Assign variables
        /// </summary>
        /// <param name="favFoodItemsStackLayout"></param>
        public FavouriteFoodService(StackLayout favFoodItemsStackLayout)
        {
            this.favFoodItemsStackLayout = favFoodItemsStackLayout;
        }

        /// <summary>
        /// Add favourite food items
        /// </summary>
        /// <param name="favFoodItemList"></param>
        public void AddFavouriteFoodItems(List<FoodItem> favFoodItemList)
        {
            favFoodItemsStackLayout.Children.Clear(); // Remove all the childs first
            // Null check
            if (favFoodItemList != null && favFoodItemList.Count > 0)
            {
                // Iterate and add available food items 
                for (int index = 0; index < favFoodItemList.Count; index++)
                {
                    var label = new Label
                    {
                        Text = string.Format("{0}) " + favFoodItemList[index].FoodItemName, (index + 1)),
                        FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                        VerticalOptions = LayoutOptions.StartAndExpand,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                    };

                    // Add item to the parent layout
                    favFoodItemsStackLayout.Children.Add(label);
                }
            }
            else
            { // Display message, since we don't have fav food item/s selected
                var label = new Label
                {
                    Text = "No favourite food item selected yet",
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };

                // Add item to the parent layout
                favFoodItemsStackLayout.Children.Add(label);
            }
        }
    }
}
