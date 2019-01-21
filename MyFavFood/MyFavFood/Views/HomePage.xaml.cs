
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyFavFood.Helpers;
using MyFavFood.ViewModels;

namespace MyFavFood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        // Set the ViewModel property
        public HomeViewModel ViewModel
        {
            get { return BindingContext as HomeViewModel; }
            set { BindingContext = value; }
        }

        /// <summary>
        /// Init the req attributes
        /// </summary>
        public HomePage()
        {
            InitializeComponent();

            ViewModel = new HomeViewModel(new PageService());
        }

        /// <summary>
        /// Invoked everytime on view appearance
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            AppGlobals.Instance.CurrentPageInstance = this; // Store the current page instance
        }
	}
}