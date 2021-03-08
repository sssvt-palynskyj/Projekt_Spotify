using System;
using System.Collections.Generic;

using SongsAndVotesCommon.BusinessObjects;
using System.Data.SqlClient;


namespace SongsAndVotesCommon.Interfaces
{



    /// <summary>
    /// Defines a contract for classes seeking to implement a user repository.
    /// </summary>
    public interface IUserRepo
    {
        SqlConnection ConnectToDatabase();


        /// <summary>
        /// Gets a complete list of all users.
        /// </summary>
        /// <returns>Returns the list of all users.</returns>
        IList<User> GetList();
        //done

        /// <summary>
        /// Finds all users matching given criteria (just the username at the moment).
        /// </summary>
        /// <param name="user">Criteria that the found users should match.</param>
        /// <returns>Returns a list of matching users.</returns>
        IList<User> FindList(User user);
        //done

        /// <summary>
        /// Checks the repo for a given user (their username).
        /// </summary>
        /// <param name="user">User to check the repo for.</param>
        /// <returns>Returns true :-: the user exists, false :-: the user does not exist.</returns>
        bool Exists(User user);
        //done

        /// <summary>
        /// Tries to load data about a given user (according to the username) and returns the information loaded.
        /// </summary>
        /// <param name="user">Information identifying the user to be loaded (their username).</param>
        /// <returns>Returns the requested user. If no such user exists, the method should throw an exception.</returns>
        User Load(User user);
        //done

        /// <summary>
        /// Tries to store (persist) data about a given user.
        /// </summary>
        /// <param name="user">User to be persisted in the repo.</param>
        void Store(User user);

        /// <summary>
        /// Adds a new user to the repo.
        /// </summary>
        /// <param name="user">User to add.</param>
        void Add(User user);

        /// <summary>
        /// Removes a given user from the repo.
        /// </summary>
        /// <param name="user">User to remove.</param>
        void Remove(User user);
        //done
    }
}
