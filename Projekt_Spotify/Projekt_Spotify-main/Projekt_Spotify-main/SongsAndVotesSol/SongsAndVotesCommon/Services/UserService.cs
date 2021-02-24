using System;

using SongsAndVotesCommon.BusinessObjects;
using SongsAndVotesCommon.Interfaces;
using SongsAndVotesCommon.Factories;
using SongsAndVotesCommon.Repos;

using System.IO;
using System.Collections.Generic;

namespace SongsAndVotesCommon.Services
{



    /// <summary>
    /// Provides API methods related to the user management, login, logout etc.
    /// </summary>
    public class UserService
    {



        /// <summary>Access to the user repo.</summary>
        private IUserRepo userRepo;



        /// <summary>
        /// Constructor.
        /// </summary>
        public UserService()
        {
            this.userRepo = UserRepoFactory.GetUserRepo();
        }
        public bool UserExists(User user)
        {
            return UserExists(user);
        }
        public bool CheckUsernameAndPassword(User user)
        {
            return UserExists(user);
        }
        public List<User> GetList(User user)
        {
            return GetList(user);
        }
        public List<User> asd()
        {
            re
        }



        /// <summary>
        /// Checks with the database whether a given user exists (given their name).
        /// </summary>
        /// <param name="user">User to check for.</param>
        /// <returns>Returns true :-: a user with the given username exists, false :-: no such user.</returns>

    }



}
