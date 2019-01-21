
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyFavFood.Helpers.Interfaces
{
    public interface IPageService
    {
        Task PushAsync(Page page);

        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);

        void MoveToTab(Page pageInstance, int tabPageId);
    }
}
