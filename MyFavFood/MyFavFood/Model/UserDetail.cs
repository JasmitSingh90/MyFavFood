
using System;
using System.Collections.Generic;

using MyFavFood.Helpers;
using MyFavFood.Repositories.Entities;

namespace MyFavFood.Model
{
    public class UserDetail : BaseModel
    {
        string name;
        public string Name
        {
            get { return name; }
            set { SetValue(ref name, value); }
        }

        DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { SetValue(ref dateOfBirth, value); }
        }

        Gender gender;
        public Gender Gender
        {
            get { return gender; }
            set { SetValue(ref gender, value); }
        }

        string comment;
        public string Comment
        {
            get { return comment; }
            set { SetValue(ref comment, value); }
        }

        List<int> favouriteFoodItemIdList;
        public List<int> UserFavouriteFoodItemIdList
        {
            get { return favouriteFoodItemIdList;  }
            set { SetValue(ref favouriteFoodItemIdList, value);  }
        }
    }
}
