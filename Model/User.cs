using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungssystem.Model
{
    class User
    {
        public static Dictionary<int, User> userList = new Dictionary<Int32, User>();
        public static User aktiveUser;
        private int userID;
        private String firstName;
        private String lastName;
        private Boolean isAdmin;
        private Boolean isLoggedIn;
        private Boolean isWorking;
        private String password;

        public User(int userID, String firstName, String lastName, Boolean isAdmin, Boolean isLoggedIn, Boolean isWorking, String password) 
        {
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.isAdmin = isAdmin;
            this.isLoggedIn = isLoggedIn;
            this.isWorking = isWorking;
            this.password = password;
            
            userList.Add(userID, this);
        }

        public Boolean IsAdmin
        {
            get { return isAdmin; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public String FirstName
        {
            get { return firstName; } 
        }

        public String LastName
        {
            get { return lastName; }
        }

        public Boolean IsWorking
        {
            get { return isWorking; }
        }

        public int UserID
        {
            get { return userID; }
        }
    }
}
