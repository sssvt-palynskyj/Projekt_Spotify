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

                if (lineName == Convert.ToString(user.Username))
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

                if (name == user.Username && pass == user.Password)
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

                    if (splitLine[0] == user.Username)
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

            if (usr != null)
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
            using (StreamWriter sw = new StreamWriter(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv", true))
            using (StreamReader sr = new StreamReader(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv"))
            using (StreamReader sr2 = new StreamReader(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv"))
            {
                int i = 0;
                //List<User> usercsv = new List<User>();
                //User usr = new User(null, null);
                string line;
                //string[] splitLine;

                while (!sr.EndOfStream)
                {
                    //line = sr.ReadLine();
                    //splitLine = line.Split(';');
                    //usr.Username = splitLine[0];
                    //usr.Password = splitLine[1];

                    //usercsv.Add(usr);
                    i++;
                }
                //usercsv.Add((user));

                //for (int x = 0; x <= i; x++)
                //{
                string writeLine = user.Username + ";" + user.Password;
                sw.WriteLine(writeLine); //usercsv.LastIndexOf 
                //}
            }
        }

        public void Add(User user)
        {
            if (Exists(user) == false)
            {
                StreamWriter sw = new StreamWriter(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv", );
            }
        }

        public void Remove(User user)
        {
            using (StreamReader sr = new StreamReader(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv"))
            {
                //string tempFile = Path.GetTempFileName();
                string readLine;
                string delLine = user.Username + ";" + user.Password;
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    readLine = sr.ReadLine();
                    if (readLine == delLine)
                    {
                        //
                    }
                }
            }
        }
    }



}
