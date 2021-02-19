using System;
using System.Collections.Generic;

using SongsAndVotesCommon.BusinessObjects;
using SongsAndVotesCommon.Interfaces;
using SongsAndVotesCommon.Factories;



namespace SongsAndVotesMain
{



    internal class UserRepoTest
    {



        private const string NastaPassword = "abc";



        private IUserRepo userRepo;



        public UserRepoTest()
        {
            this.userRepo = UserRepoFactory.GetUserRepo();
        }



        public void GetListTest()
        {
            IList<User> users = this.userRepo.GetList();
            foreach (User user in users)
            {
                //Console.WriteLine($"Username: {user.Username}    Password: {user.Password}");
                Console.WriteLine($"Username: {user.Username}    Password: {"xxx"}");
            }
        }



        public void AddTest()
        {
            //User nasta = new User { Username = "nasta", Password = "abc" };
            User nasta = new User { Username = "nasta", Password = NastaPassword };
            User igor = new User { Username = "igor", Password = "xyz" };
            if ( ! this.userRepo.Exists(nasta) )
            {
                this.userRepo.Add(nasta);
            }
            if (!this.userRepo.Exists(igor))
            {
                this.userRepo.Add(igor);
            }
            //GetListTest();
        }



        public void RemoveTest()
        {
            AddTest();
            User dummy = new User { Username = "dummy", Password = "aaa" };
            if ( ! this.userRepo.Exists(dummy) )
            {
                this.userRepo.Add(dummy);
                Console.WriteLine("User dummy added.");
            }
            //GetListTest();
            if (this.userRepo.Exists(dummy))
            {
                this.userRepo.Remove(dummy);
                Console.WriteLine("User dummy removed.");
            }
            //GetListTest();
        }



        public void StoreTest()
        {
            AddTest();
            User nasta1 = new User { Username = "nasta", Password = "" };
            User nasta2 = this.userRepo.Load(nasta1);
            nasta2.Password = "ABCD";
            this.userRepo.Store(nasta2);
            User nasta3 = this.userRepo.Load(nasta1);
            nasta3.Password = NastaPassword;
            this.userRepo.Store(nasta3);
        }



        public static void LaunchTestSuite()
        {

            // Display the contents of the user repo.
            UserRepoTest testRepo = new UserRepoTest();
            testRepo.GetListTest();
            Console.WriteLine();
            Console.WriteLine();

            // Try to add users.
            testRepo.AddTest();
            testRepo.GetListTest();
            Console.WriteLine();
            Console.WriteLine();

            // Try to add and remove a user.
            testRepo.RemoveTest();
            testRepo.GetListTest();
            Console.WriteLine();
            Console.WriteLine();

            // Try to temporarily change a user's password.
            testRepo.StoreTest();
            testRepo.GetListTest();
            Console.WriteLine();
            Console.WriteLine();

        }



    }



}
