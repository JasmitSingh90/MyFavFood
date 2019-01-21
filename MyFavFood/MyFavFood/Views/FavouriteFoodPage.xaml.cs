using MyFavFood.Helpers;
using MyFavFood.Helpers.Services;
using MyFavFood.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFavFood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavouriteFoodPage : ContentPage
	{
        // Set the ViewModel property
        public FavouriteFoodViewModel ViewModel
        {
            get { return BindingContext as FavouriteFoodViewModel; }
            set { BindingContext = value; }
        }

        /// <summary>
        /// Init the req attributes
        /// </summary>
        public FavouriteFoodPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Invoked everytime on view appearance
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            AppGlobals.Instance.CurrentPageInstance = this; // Store the current page instance

            ViewModel = new FavouriteFoodViewModel(new FavouriteFoodService(favFoodItemsStackLayout));
        }
	}
}