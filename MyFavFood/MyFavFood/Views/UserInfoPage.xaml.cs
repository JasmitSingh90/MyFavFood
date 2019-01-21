
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyFavFood.Helpers;
using MyFavFood.ViewModels;

namespace MyFavFood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserInfoPage : ContentPage
    {
        /// <summary>
        /// Init the req attributes
        /// </summary>
        public UserInfoPage()
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

            BindingContext = new UserInfoViewModel(AppGlobals.Instance.UserDetail, new PageService());
        }
    }
}