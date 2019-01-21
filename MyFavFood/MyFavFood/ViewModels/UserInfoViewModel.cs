
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

using Xamarin.Forms;

using MyFavFood.Repositories.Entities;
using MyFavFood.Helpers;
using MyFavFood.Model;
using MyFavFood.Helpers.Interfaces;

namespace MyFavFood.ViewModels
{
    class UserInfoViewModel : BaseModel
    {
        private readonly IPageService pageService;

        // Handles the User data
        private UserDetail userInfo;
        public UserDetail UserInfo
        {
            get { return userInfo; }
            set { SetValue(ref userInfo, value); }
        }

        // Get the available gender types to display
        public IList<string> GenderTypes
        {
            get
            {
                return GetAvailableGenderTypes().Select(genderType => genderType.Title).ToList();
            }
        }

        // Get the selected gender type
        string selectedGenderTitle;
        public string SelectedGenderTitle
        {
            get { return selectedGenderTitle; }
            set { SetValue(ref selectedGenderTitle, value); }
        }

        // Handles the job to update user data
        public ICommand UpdateUserDataCommand { get; private set; }

        /// <summary>
        /// Init properties and restore the Userdetail state
        /// </summary>
        public UserInfoViewModel(UserDetail userData, IPageService pageService)
        {
            this.pageService = pageService; // Assign the service

            // Null check
            if (userData == null)
            {
                userData = new UserDetail();
            }

            // Restore the UserData
            UserInfo = new UserDetail()
            {
                Name = userData.Name,
                DateOfBirth = userData.DateOfBirth,
                Gender = userData.Gender,
                Comment = userData.Comment
            };

            // Check for the gender and update the attribute so as to notify the same to the View
            if (UserInfo.Gender != null)
            {
                SelectedGenderTitle = UserInfo.Gender.Title;
            }

            // Init Commands
            UpdateUserDataCommand = new Command(async vm => await UpdateUserData());
        }

        /// <summary>
        /// Updates the user data post validation
        /// </summary>
        private async Task UpdateUserData()
        {
            if (ValidateUserData()) // Validate the changes
            {
                // Update the global data
                if (AppGlobals.Instance.UserDetail == null) // Null check
                {
                    AppGlobals.Instance.UserDetail = new UserDetail();
                }

                AppGlobals.Instance.UserDetail.Name = UserInfo.Name;
                AppGlobals.Instance.UserDetail.DateOfBirth = UserInfo.DateOfBirth;
                AppGlobals.Instance.UserDetail.Gender = GetAvailableGenderTypes().First(genderType => genderType.Title == SelectedGenderTitle);
                AppGlobals.Instance.UserDetail.Comment = UserInfo.Comment;
                
                // Display message
                if (await pageService.DisplayAlert("Success", "Do you want to select your favourite food items?", "ok", "cancel"))
                {
                    // Move to the available food tab
                    pageService.MoveToTab(AppGlobals.Instance.CurrentPageInstance, 2);
                }
            }
        }

        /// <summary>
        /// Validates the user data
        /// </summary>
        private bool ValidateUserData()
        {
            if (string.IsNullOrEmpty(UserInfo.Name))
            {
                pageService.DisplayAlert("Warning", "Please enter first name", "ok", "cancel");
                return false;
            }
            else if (string.IsNullOrEmpty(SelectedGenderTitle))
            {
                pageService.DisplayAlert("Warning", "Please select gender", "ok", "cancel");
                return false;
            }
            else if (string.IsNullOrEmpty(UserInfo.Comment))
            {
                pageService.DisplayAlert("Warning", "Please express your food love in comment section", "ok", "cancel");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the available gender types
        /// </summary>
        /// <returns></returns>
        public IList<Gender> GetAvailableGenderTypes()
        {
            return new List<Gender>
                   {
                       new Gender{ Id = 1, Title = "Male"},
                       new Gender{ Id = 2, Title = "Female"}
                   };
        }
    }
}
