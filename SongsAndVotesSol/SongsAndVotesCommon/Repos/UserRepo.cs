using System;
using System.Collections.Generic;
using System.IO;

using SongsAndVotesCommon.BusinessObjects;
using SongsAndVotesCommon.Factories;
using SongsAndVotesCommon.Interfaces;

namespace SongsAndVotesCommon.Repos
{



    /// <summary>
    /// Provides database access to user-related data.
    /// </summary>
    public class UserRepo : IUserRepo
    {



        /// <summary>Database table with user info.</summary>
        private const string RepoFile = @"..\..\..\Resources\Database\User.csv";

        /// <summary>Use this delimiter in the the repo.</summary>
        private const char Delimiter = ';';

        /// <summary>Header line in the repo.</summary>
        private const string HeaderLine = "Username;Password";



    }



}
