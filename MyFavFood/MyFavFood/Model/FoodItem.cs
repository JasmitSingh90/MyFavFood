
using System.Drawing;

using MyFavFood.Helpers;

namespace MyFavFood.Model
{
    public class FoodItem : BaseModel
    {
        public int FoodItemId { get; set; }
        public string FoodItemName { get; set; }

        private bool _isUserFavorite;
        public bool IsUserFavorite
        {
            get { return _isUserFavorite; }
            set
            {
                SetValue(ref _isUserFavorite, value);
                OnPropertyChanged(nameof(Color));
            }
        }

        public Color Color
        {
            get { return IsUserFavorite ? Color.DarkBlue : Color.Black; }
        }
    }
}
