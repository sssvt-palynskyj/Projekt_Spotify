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

        public List<User> GetList(User user)
        {
            return GetList(user);
        } //vrátí list uživatelů
        
        public IList<User> FindUser(User user)
        {
            return this.userRepo.FindList(user);
        } //vrátí t-najde uživatele nebo f-nenajde

        public bool UserExists(User user)
        {
            return this.userRepo.Exists(user);
        } //najde jestli se už dané jméno používá

        public User ReturnUser(User user)
        {
            return this.userRepo.Load(user);
        } //vrátí daného uživatele

        public bool CheckUsernameAndPassword(User user)
        {
            return UserExists(user);
        }

        /// <summary>
        /// Checks with the database whether a given user exists (given their name).
        /// </summary>
        /// <param name="user">User to check for.</param>
        /// <returns>Returns true :-: a user with the given username exists, false :-: no such user.</returns>
    }
}
