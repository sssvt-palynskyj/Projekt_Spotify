using System;
using System.Collections.Generic;
using System.IO;

using SongsAndVotesCommon.BusinessObjects;
using SongsAndVotesCommon.Factories;
using SongsAndVotesCommon.Interfaces;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace SongsAndVotesCommon.Repos
{



    /// <summary>
    /// Provides database access to user-related data.
    /// </summary>
    public class UserRepo : IUserRepo
    {

        //-------------------------------------------------------------------------------------------
        private const string connectionString = "Server=localhost; Database=SongsAndVotesUsers; Integrated Security=true";
        public SqlConnection ConnectToDatabase()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }

        public void TestDatabase()
        {
            SqlConnection sqlConnection = ConnectToDatabase();
            sqlConnection.Open();

            SqlCommand command = new SqlCommand("Select * from UserData", sqlConnection);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine(reader.GetString(0));
            }

            SqlCommand sqlCommand = new SqlCommand("Insert ...", sqlConnection);
            ///sql
        }
        //-------------------------------------------------------------------------------------------

        /// <summary>Database table with user info.</summary>
        private const string RepoFile = @"..\..\..\Resources\Database\User.csv";

        /// <summary>Use this delimiter in the the repo.</summary>
        private const char Delimiter = ';';

        /// <summary>Header line in the repo.</summary>
        private const string HeaderLine = "Username;Password";


        //string FilePath = (@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv");
        
        public IList<User> GetList(User user)
        {
            string SelectAllUsernames = "Select Username from UserData";
            using (SqlCommand sqlCommand = new SqlCommand(SelectAllUsernames, ConnectToDatabase()))
            {
                IList<User> MatchingUserName = new List<User> { };
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                int i = 0;
                while(sqlDataReader.Read())
                {
                    i++;
                    User MatchingUser = new User(sqlDataReader.GetString(i), null);
                    MatchingUserName.Add(MatchingUser);
                    //UserNames.Add(sqlDataReader.GetString(i));
                }
                return MatchingUserName;
                //return (IList<User>)UserNames;
            }
            
            /*using (StreamReader sr = new StreamReader(FilePath))
            {
                List<User> listOfUsers = new List<User>();
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] splitLine = line.Split(';');

                    User usr = new User(splitLine[0], splitLine[1]);
                    listOfUsers.Add(usr);
                }
                return listOfUsers;
            }*/
        }

        public IList<User> FindList(User user)
        {
            string SelectMatchingUser = "Select Username from UserData where Username = " + Convert.ToString(user.Username);
            using (SqlCommand sqlCommand = new SqlCommand(SelectMatchingUser, ConnectToDatabase()))
            {
                    IList<User> MatchingUsers = new List<User> { };
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    int i = 0;
                    while (sqlDataReader.Read())
                    {
                        i++;
                        User MatchingUser = new User(sqlDataReader.GetString(i), null);
                        MatchingUsers.Add(MatchingUser);
                        //UserNames.Add(sqlDataReader.GetString(i));
                    }
                    return MatchingUsers;
                    //return (IList<User>)UserNames;
                
                /*
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    List<User> listOfMatchingUsers = new List<User>();
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] splitLine = line.Split(';');

                        User usr = new User(splitLine[0], null);
                        listOfMatchingUsers.Add(usr);
                    }
                    return listOfMatchingUsers;
                }*/
            }
        }

        public bool Exists(User user)
        {
            string UserExists = "Select COUNT(Username) from UserData where Username ='" + user.Username +
                "' and Password ='" + user.Password +"'";
            using (SqlCommand sqlCommand = new SqlCommand(UserExists, ConnectToDatabase()))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(UserExists, ConnectToDatabase());
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                if(dataTable.Rows[0][0].ToString() == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            /*using (StreamReader sr = new StreamReader(FilePath))
            {
                sr.ReadLine();
                bool x = false;
                while (!sr.EndOfStream)
                {
                    string oneLine = sr.ReadLine();
                    string[] splitLine = oneLine.Split(';');
                    User usr = new User(splitLine[0], null);

                    if (usr.Username == user.Username)
                    {
                        x = true;
                    }
                }
                return x;
            }*/
        }

        public User Load(User user)
        {
            if(Exists(user) == true)
            {
                return (User)FindList(user);
            }
            else
            {
                throw new NotImplementedException();
            }
            /*using(StreamReader sr = new StreamReader(FilePath))
            {
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

                if (usr != null)
                {
                    return usr;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }*/
        }

        public void Store(User user)
        {

            /*using (StreamWriter sw = new StreamWriter(FilePath, true))
            using (StreamReader sr = new StreamReader(FilePath))
            using (StreamReader sr2 = new StreamReader(FilePath))
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
            }*/
        }

        public void Add(User user)
        {
            if (Exists(user) == false)
            {
            }
        }

        public void Remove(User user)
        {
            if (Exists(user) == true)
            {
                string DeleteUser = "Delete from UserData where Username = '" + user.Username + "'";
                using (SqlCommand sqlCommand = new SqlCommand(DeleteUser, ConnectToDatabase())) { }
            }
            else
            {
                throw new NotImplementedException();
            }
            /*using (StreamReader sr = new StreamReader(@"E:\GitHub\local\Projekt\Projekt_Spotify\Projekt_Spotify-main\Projekt_Spotify-main\SongsAndVotesSol\Resources\Database\User.csv"))
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
            }*/
        }

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
    }
}
