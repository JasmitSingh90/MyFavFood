
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyFavFood.Helpers;
using MyFavFood.ViewModels;

namespace MyFavFood.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AvailableFoodPage : ContentPage
	{
        // Set the ViewModel property
        public AvailableFoodItemViewModel ViewModel
        {
            get { return BindingContext as AvailableFoodItemViewModel; }
            set { BindingContext = value; }
        }

        /// <summary>
        /// Init the req attributes
        /// </summary>
        public AvailableFoodPage()
        {
            ViewModel = new AvailableFoodItemViewModel(new PageService()); // Set the binding context

            InitializeComponent(); // Init the components/ UI elements before accessing 
        }

        /// <summary>
        /// Invoked everytime on view appearance
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            AppGlobals.Instance.CurrentPageInstance = this; // Store the current page instance
        }

        /// <summary>
        /// Handles the OnFoodItem selected click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnFoodItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectFoodItemCommand.Execute(e.SelectedItem);
        }
    }
}