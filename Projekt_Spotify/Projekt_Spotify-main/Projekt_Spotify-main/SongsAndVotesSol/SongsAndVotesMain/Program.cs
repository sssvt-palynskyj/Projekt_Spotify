using System;
using SongsAndVotesCommon;

using SongsAndVotesCommon.Repos;

namespace SongsAndVotesMain
{



    public class Program
    {



        public static void Main(string[] args)
        {

            // Test the user repo.
            //UserRepoTest.LaunchTestSuite();
            UserRepo userRepo = new UserRepo();
            userRepo.ConnectToDatabase();
            Console.ReadKey(true);

        }

    }
}
