
using System.Threading.Tasks;

using Xamarin.Forms;

using MyFavFood.Helpers.Interfaces;

namespace MyFavFood.Helpers
{
    public class PageService : IPageService
    {
        /// <summary>
        /// Method to display alert
        /// </summary>
        /// <param name="title"></param>
        /// <param name="message"></param>
        /// <param name="ok"></param>
        /// <param name="cancel"></param>
        /// <returns></returns>
        public async Task<bool> DisplayAlert(string title, string message, string ok, string cancel)
        {
            return await Application.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }

        /// <summary>
        /// Move's the tab
        /// </summary>
        /// <param name="pageInstance"></param>
        /// <param name="tabPageId"></param>
        public void MoveToTab(Page pageInstance, int tabPageId)
        {
            if (pageInstance != null && pageInstance.Parent != null) // Null check
            {
                // Check for the page instance
                if (pageInstance.Parent.Parent is TabbedPage tabbedPage)
                {
                    tabbedPage.CurrentPage = tabbedPage.Children[tabPageId]; // Change the tab
                }
            }
        }

        /// <summary>
        /// Method to push page on the stack
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public async Task PushAsync(Page page)
        {
            await AppGlobals.Instance.CurrentPageInstance.Navigation.PushAsync(page);
        }
    }
}
