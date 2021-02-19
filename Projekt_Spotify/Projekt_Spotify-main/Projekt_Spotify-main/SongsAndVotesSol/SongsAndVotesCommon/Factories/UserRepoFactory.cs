using System;

using SongsAndVotesCommon.Interfaces;
using SongsAndVotesCommon.Repos;



namespace SongsAndVotesCommon.Factories
{



    /// <summary>
    /// Exposes user-repo-related factory methods.
    /// </summary>
    public class UserRepoFactory
    {



        /// <summary>
        /// Gets an object implementing the user repo.
        /// </summary>
        /// <returns>Returns the user repo.</returns>
        public static IUserRepo GetUserRepo()
        {
            return new UserRepo();
        }



    }



}
