using System;
using System.Collections.Generic;



namespace SongsAndVotesCommon.BusinessObjects
{



    /// <summary>
    /// Represents a user in the SongsAndVotes app.
    /// </summary>
    public class User
    {



        /// <summary>Username for this user.</summary>
        public string Username { get; set; }

        /// <summary>The user's password.</summary>
        public string Password { internal get; set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public override string ToString()
        {
            return $"Username: {Username}";
        }



        public override bool Equals(object obj)
        {
            if (obj is User)
            {
                User objUser = (User)obj;
                return objUser.Username == Username;
            }
            return false;
        }



        public override int GetHashCode()
        {
            return Username.GetHashCode();
        }



        public static bool operator == (User user1, User user2)
        {
            if ((user1 == null) && (user2 == null))
            {
                return true;
            }
            if ((user1 == null) || (user2 == null))
            {
                return false;
            }
            return user1.Equals(user2);
        }



        public static bool operator != (User user1, User user2)
        {
            return !(user1 == user2);
        }



    }



}
