
using System.Collections.ObjectModel;
using System.Windows.Input;

using Xamarin.Forms;

using MyFavFood.Helpers;
using MyFavFood.Model;
using MyFavFood.Repositories;
using MyFavFood.Helpers.Interfaces;

namespace MyFavFood.ViewModels
{
    public class AvailableFoodItemViewModel : BaseModel
    {
        // Class properties
        private readonly IPageService pageService;
        public ObservableCollection<FoodItem> FoodItemlists { get; private set; }

        private FoodItem selectedFoodItem;
        public FoodItem SelectedFoodItem
        {
            get { return selectedFoodItem; }
            set { SetValue(ref selectedFoodItem, value); }
        }

        public ICommand SelectFoodItemCommand { get; private set; }

        /// <summary>
        /// Init the req attributes
        /// </summary>
        public AvailableFoodItemViewModel(IPageService pageService)
        {
            this.pageService = pageService; // Assign the page service

            SetFoodItemList(); // Set the dummy food item list
            SelectFoodItemCommand = new Command<FoodItem>(vm => SelectFoodItem(vm)); // Set the command action
        }

        /// <summary>
        /// Set food item list
        /// </summary>
        private void SetFoodItemList()
        {
            FoodItemlists = new ObservableCollection<FoodItem>();

            // Map to the model class
            foreach (var item in FoodItemsRepository.GetAvailableFoodItemList())
            {
                var foodItem = new FoodItem
                {
                    FoodItemId = item.ItemId,
                    FoodItemName = item.ItemName
                };

                FoodItemlists.Add(foodItem); // Add item
            }
        }

        /// <summary>
        /// Invokes on the food item selection
        /// </summary>
        /// <param name="foodItem"></param>
        private void SelectFoodItem(FoodItem foodItem)
        {
            if (foodItem == null)
                return;

            // Check if we have user details
            // If yes then add to the global list else prompt the user
            if (AppGlobals.Instance.UserDetail != null)
            {
                if (AppGlobals.Instance.UserDetail.UserFavouriteFoodItemIdList == null) {
                    AppGlobals.Instance.UserDetail.UserFavouriteFoodItemIdList = new System.Collections.Generic.List<int>();
                }

                // Update the global data
                if (foodItem.IsUserFavorite) 
                {
                    // The item is already present, so remove the same 
                    foodItem.IsUserFavorite = false;
                    AppGlobals.Instance.UserDetail.UserFavouriteFoodItemIdList.Remove(foodItem.FoodItemId);
                } else
                {
                    // The item isn't present, so add the same
                    foodItem.IsUserFavorite = true;
                    AppGlobals.Instance.UserDetail.UserFavouriteFoodItemIdList.Add(foodItem.FoodItemId);
                }
            } else
            {
                pageService.MoveToTab(AppGlobals.Instance.CurrentPageInstance, 1);
                pageService.DisplayAlert("Warning", "Please fill in the user details first", "ok", "cancel");
            }
            
            // Unselect the selected list item
            SelectedFoodItem = null;
        }
    }
}
