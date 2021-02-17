using System;

using SongsAndVotesCommon.BusinessObjects;
using SongsAndVotesCommon.Interfaces;
using SongsAndVotesCommon.Factories;



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



        /// <summary>
        /// Checks with the database whether a given user exists (given their name).
        /// </summary>
        /// <param name="user">User to check for.</param>
        /// <returns>Returns true :-: a user with the given username exists, false :-: no such user.</returns>
        public bool UserExists(User user)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Checks with the database whether there is a given user with a given password.
        /// </summary>
        /// <param name="user">User to check for.</param>
        /// <returns>Returns true :-: the given combination of username/password is valid, false :-: the username and/or password are wrong.</returns>
        public bool CheckUsernameAndPassword(User user)
        {
            throw new NotImplementedException();
        }



    }



}
