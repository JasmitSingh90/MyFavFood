
using System.Windows.Input;

using MyFavFood.Helpers;
using MyFavFood.Helpers.Interfaces;
using MyFavFood.Views;

using Xamarin.Forms;

namespace MyFavFood.ViewModels
{
    public class HomeViewModel : BaseModel
    {
        private readonly IPageService pageService;
        public ICommand NavigateToUserDetailsScreenCommand { get; private set; }

        /// <summary>
        /// Init variables
        /// </summary>
        /// <param name="pageService"></param>
        public HomeViewModel(IPageService pageService)
        {
            this.pageService = pageService; // Assign the service

            // Init command
            NavigateToUserDetailsScreenCommand = new Command(NavigateToUserDetailsScreen);
        }

        // Navigate to the other screen
        private void NavigateToUserDetailsScreen()
        {
            // Check if we have user details or not
            if (AppGlobals.Instance.UserDetail != null)
            {
                pageService.PushAsync(new FavouriteFoodPage());
            } else
            { // User hasn't filled the data yet so display the appropriate message and redirect user to the 
                // required tab
                pageService.MoveToTab(AppGlobals.Instance.CurrentPageInstance, 1);
                pageService.DisplayAlert("Warning", "Please fill in the user details first", "ok", "cancel");
            }
        }
    }
}
