using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zeiterfassungssystem.Model
{
    class User
    {
        public static Dictionary<Int32, User> userList = new Dictionary<Int32, User>();

        private Int32 userID;
        private String firstName;
        private String lastName;
        private Boolean isAdmin;
        private Boolean isLoggedIn;
        private Boolean isWorking;
        private String password;

        public User(Int32 userID, String firstName, String lastName, Boolean isAdmin, Boolean isLoggedIn, Boolean isWorking, String password) 
        {
            this.userID = userID;
            this.firstName = firstName;
            this.lastName = lastName;
            this.isAdmin = isAdmin;
            this.isLoggedIn = isLoggedIn;
            this.isWorking = isWorking;
            this.password = password;
            
        }
    }
}
