using System;

using SongsAndVotesCommon.BusinessObjects;
using SongsAndVotesCommon.Interfaces;
using SongsAndVotesCommon.Factories;

using System.IO;
using System.Collections.Generic;

namespace SongsAndVotesCommon.Services
{



    /// <summary>
    /// Provides API methods related to the user management, login, logout etc.
    /// </summary>
    public class UserService : IUserRepo
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
            bool x = false;

            StreamReader sr = new StreamReader(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv");
            sr.ReadLine(); //aby se vynechala první lina jinak by šlo použít Username;Password jako login
            while (!sr.EndOfStream)
            {
                string oneLine = sr.ReadLine();
                string[] splitLineName = oneLine.Split(';');
                string lineName = splitLineName[0];

                if(lineName == Convert.ToString(user.Username))
                {
                    x = true;
                }
            }
            sr.Close();
            sr.Dispose();
            return x;
        }



        /// <summary>
        /// Checks with the database whether there is a given user with a given password.
        /// </summary>
        /// <param name="user">User to check for.</param>
        /// <returns>Returns true :-: the given combination of username/password is valid, false :-: the username and/or password are wrong.</returns>
        public bool CheckUsernameAndPassword(User user)
        {
            bool x = false;
            string daWay = (@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv");
            StreamReader sr = new StreamReader(daWay);
            sr.ReadLine();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] splitLine = line.Split(';');

                string name = splitLine[0];
                string pass = splitLine[1];

                if(name == user.Username && pass == user.Password)
                {
                    x = true;
                }
            }
            sr.Close();
            sr.Dispose();
            return x;
        }

        public IList<User> GetList(User user)
        {
            List<User> listOfUsers = new List<User>();
            StreamReader sr = new StreamReader(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv");

            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] splitLine = line.Split(';');
                User usr = new User(splitLine[0], splitLine[1]);
                //usr.Username = splitLine[0];
                //usr.Password = splitLine[1];

                listOfUsers.Add(usr);
            }
            sr.Close();
            sr.Dispose();
            return listOfUsers;
        }

        public IList<User> FindList(User user)
        {
            List<User> listOfUsers = new List<User>();
            StreamReader sr = new StreamReader(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv");

            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] splitLine = line.Split(';');
                User usr = new User(splitLine[0], null);

                listOfUsers.Add(usr);
            }
            sr.Close();
            sr.Dispose();
            return listOfUsers;
        }

        public bool Exists(User user)
        {
            bool x = false;

            StreamReader sr = new StreamReader(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string oneLine = sr.ReadLine();
                string[] splitLineName = oneLine.Split(';');
                string lineName = splitLineName[0];

                if (lineName == Convert.ToString(user.Username))
                {
                    x = true;
                }
            }
            sr.Close();
            sr.Dispose();
            return x;
        }

        public User Load(User user)
        {
            StreamReader sr = new StreamReader(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv");
            sr.ReadLine();
            User usr = null;

            try
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] splitLine = line.Split(';');
                    
                    if(splitLine[0] == user.Username)
                    {
                        usr = new User(splitLine[0], splitLine[1]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sr.Close();
                sr.Dispose();
            }

            if(usr != null)
            {
                return usr;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public void Store(User user)
        {
            
        }

        public void Add(User user)
        {
            
        }

        public void Remove(User user)
        {

        }
    }



}
