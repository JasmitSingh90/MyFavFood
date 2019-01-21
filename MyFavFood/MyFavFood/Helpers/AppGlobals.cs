
using Xamarin.Forms;

using MyFavFood.Model;

namespace MyFavFood.Helpers
{
    public class AppGlobals
    {
        private static AppGlobals instance;
        public static AppGlobals Instance
        {
            get
            {
                if (instance == null)
                    instance = new AppGlobals();
                return instance;
            }
        }

        // Restrict user from instantiating class
        private AppGlobals() { }

        // Get and set userdetail attribute
        public UserDetail UserDetail { get; set; }

        // Get and set current page instance
        public Page CurrentPageInstance { get; set; }
    }
}
