using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using System.Text;

namespace MultiServer
{
    class Program
    {
        private static readonly Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); //Initialise socket
        private static readonly List<Socket> clientSockets = new List<Socket>(); //Create list of users
        private const int BUFFER_SIZE = 2048; //Initialise buffer
        private const int PORT = 100; //Initialise port
        private static readonly byte[] buffer = new byte[BUFFER_SIZE]; //Create bytearray
        public static int UserCount = 0; //Initialise usercounter
        public static int GameID = 0; //Initialise GameID
        public static Random Ran = new Random(); //Initialise random number generator
        public static Socket Socket; //Initialise socket
        public static Socket Current; //Initialise socket

        static void Main()
        {
            Console.Title = "Server"; //Set title
            SetupServer(); //Call server connector
            Console.ReadLine(); // When we press enter close everything
            CloseAllSockets();
        }

        private static void SetupServer()
        {
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, PORT)); //Bind socket to port on IP
            serverSocket.Listen(0); //Start listening for connections
            serverSocket.BeginAccept(AcceptCallback, null); //Accept connections
            string GetIP = new WebClient().DownloadString("http://icanhazip.com");
            Console.WriteLine("The Server IP is: " + GetIP);
            Console.WriteLine("Server setup complete");
            GameID = Ran.Next(0, 999); //Generate random GameID
        }

        private static void CloseAllSockets()
        {
            foreach (Socket socket in clientSockets) //For every client
            {
                socket.Shutdown(SocketShutdown.Both); //Shutdown socket
                socket.Close(); //Close socket
            }
            serverSocket.Close(); //Kill server
        }

        private static void AcceptCallback(IAsyncResult AR)
        {
            try
            {
                Socket = serverSocket.EndAccept(AR); //Accept async connection
            }
            catch (ObjectDisposedException) //Catch exception 
            {
                return;
            }

            clientSockets.Add(Socket); //Add user to list
            Socket.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, Socket); //Listen for messages
            Console.WriteLine("Client connected, waiting for request..."); //Write to console
            serverSocket.BeginAccept(AcceptCallback, null); //Recieve
        }

        private static void ReceiveCallback(IAsyncResult AR)
        {
            Current = (Socket)AR.AsyncState; //Set socket info as current user
            int received; //Define recieved message
            try
            {
                received = Current.EndReceive(AR); //Set recieved as stream read
            }
            catch
            {
                Console.WriteLine("Client forcefully disconnected"); // Don't shutdown because the socket may be disposed and its disconnected anyway.
                Current.Close(); //Close client
                clientSockets.Remove(Current); //Remove from arraylist
                return;
            }

            byte[] recBuf = new byte[received]; //Create destination buffer
            Array.Copy(buffer, recBuf, received); //Copy into array
            string text = Encoding.ASCII.GetString(recBuf); //Get string of recieved text

            if (text.ToLower() == "ready") //Check for player ready
            {
                UserCount++; //Increment usercount
                while (UserCount <= 1) //While there aren't two users
                {
                    try
                    {
                        byte[] data = Encoding.ASCII.GetBytes("Waiting for player"); //Tell client we're waiting for another person
                        Current.Send(data); //Send it
                    }
                    catch (SocketException) //Catch exception
                    {
                        Console.WriteLine("Client disconnect"); //Tell them we've been disconnected
                        break;
                    }
                }
                if (UserCount == 2)
                {
                    byte[] data = Encoding.ASCII.GetBytes(GameID.ToString()); //Convert GameID to bytearray
                    Socket Client1 = (Socket)clientSockets[0]; //Get first player Socket
                    Socket Client2 = (Socket)clientSockets[1]; //Get second player Socket
                    Client1.Send(data); //Send player GameID
                    Client2.Send(data); //Send player GameID
                    Console.WriteLine("Game started"); //Log
                    UserCount = 0; //Reset usercount
                    GameID = Ran.Next(0, 999); //Generate new GameID
                    clientSockets.Clear(); //Clear list of users
                }
            }
            else if (text.StartsWith("a")) //Check if user is adding questions into database
            {
                string[] user = text.Split(','); //Define array with text split at every comma
                string Subject = user[1]; //Split into induvidual variables
                string Question = user[2]; //Split into induvidual variables
                string A = user[3]; //Split into induvidual variables
                string B = user[4]; //Split into induvidual variables
                string C = user[5]; //Split into induvidual variables
                string D = user[6]; //Split into induvidual variables
                string UserQuery = "INSERT INTO Questions (Subject, Question, CorrectAnswer, AnswerA, AnswerB, AnswerC) Values (@Subject, @Question, @CorrectAnswer, @AnswerA, @AnswerB, @AnswerC)"; //SQL statement to insert into Questions table
                SqlConnection UserConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["CsData"].ConnectionString); //Define connection string
                SqlCommand UserCmd = new SqlCommand(UserQuery, UserConnect); //Create command to execute

                UserCmd.Parameters.AddWithValue("@Subject", Subject);  //Define parameters
                UserCmd.Parameters.AddWithValue("@Question", Question); //Define parameters
                UserCmd.Parameters.AddWithValue("@CorrectAnswer", A); //Define parameters
                UserCmd.Parameters.AddWithValue("@AnswerA", B); //Define parameters
                UserCmd.Parameters.AddWithValue("@AnswerB", C); //Define parameters
                UserCmd.Parameters.AddWithValue("@AnswerC", D); //Define parameters
                UserConnect.Open(); //Opens the connection
                UserCmd.ExecuteNonQuery(); //Execute the query
                UserConnect.Close(); //Close the connection
                clientSockets.Remove(Current); //Remove the socket to prevent duplicate queries
            }
            else if (text.StartsWith("n")) //Check if user wants to register
            {
                string[] user = text.Split(','); //Define array with text split at every comma
                string Username = user[1]; //Split into induvidual variables
                string Password = user[2]; //Split into induvidual variables

                string UserQuery = "INSERT INTO Users (Username, Password) Values (@Username, @Password)"; //SQL statement to insert into Users table
                SqlConnection UserConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["CSData"].ConnectionString); //Define connection string
                SqlCommand UserCmd = new SqlCommand(UserQuery, UserConnect); //Create command to execute
                UserCmd.Parameters.AddWithValue("@Username", Username); //Define parameters
                UserCmd.Parameters.AddWithValue("@Password", Password); //Define parameters

                UserConnect.Open(); //Opens the connection
                UserCmd.ExecuteNonQuery(); //Execute the query
                UserConnect.Close(); //Close the connection
                //clientSockets.Remove(Current); //Remove the socket to prevent duplicate queries

            }
            else if (text.StartsWith("l")) //Check if user wants to login
            {
                string[] user = text.Split(','); //Define array with text split at every comma
                string Username = user[1]; //Split into induvidual variables
                string Password = user[2]; //Split into induvidual variables

                string LoginQuery = "SELECT * FROM Users WHERE Username=@Username AND Password=@Password"; //SQL statement to select from Users table
                SqlConnection LoginConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["CSData"].ConnectionString); //Define connection string
                SqlCommand LoginCmd = new SqlCommand(LoginQuery, LoginConnect); //Create command to execute
                LoginCmd.Parameters.AddWithValue("@Username", Username); //Define parameters
                LoginCmd.Parameters.AddWithValue("@Password", Password); //Define parameters

                LoginConnect.Open(); //Opens the connection
                SqlDataReader Reader = LoginCmd.ExecuteReader(); //Define reader to read from database
                int Users = 0; //Declaring counter

                while (Reader.Read()) //While it iterates
                {
                    Users++; //Increment if there is a user
                }
                LoginConnect.Close(); //Close the connection 

                if (Users > 0) //If the ueser exists
                {
                    byte[] data = Encoding.ASCII.GetBytes("True"); //Convert true message to bytearray
                    Current.Send(data); //Send results of check
                }
                else
                {
                    byte[] data = Encoding.ASCII.GetBytes("False"); //Convert true message to bytearray
                    Current.Send(data); //Send results of check
                }
                clientSockets.Remove(Current); //Remove the socket to prevent duplicate queries
                clientSockets.Clear(); //Remove the socket to prevent duplicate queries
            }
            else if (text.StartsWith("g")) //Check if user wants questions
            {
                string[] user = text.Split(','); //Define array with text split at every comma
                string QNum = user[1]; //Split into induvidual variables
                string Q = ""; //Split into induvidual variables
                string A = ""; //Split into induvidual variables
                string B = ""; //Split into induvidual variables
                string C = ""; //Split into induvidual variables
                string D = ""; //Split into induvidual variables

                string UserQuery = "SELECT * FROM Questions WHERE Question=@Question"; //SQL statement to select from Questions table
                SqlConnection UserConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["CSData"].ConnectionString); //Define connection string
                SqlCommand UserCmd = new SqlCommand(UserQuery, UserConnect); //Create command to execute
                UserCmd.Parameters.AddWithValue("@Question", QNum); //Define parameters

                UserConnect.Open(); //Open the connection
                SqlDataReader dr = UserCmd.ExecuteReader(); //Define reader to read from database
                while (dr.Read()) //While it iterates
                {
                    Q = dr["Question"].ToString(); //Set variable as result from table 
                    A = dr["CorrectAnswer"].ToString(); //Set variable as result from table
                    B = dr["AnswerA"].ToString(); //Set variable as result from table
                    C = dr["AnswerB"].ToString(); //Set variable as result from table
                    D = dr["AnswerC"].ToString(); //Set variable as result from table
                }
                UserConnect.Close(); //Close the connection

                string LS = Q + "," + A + "," + B + "," + C + "," + D; //Concatenate to send over the server
                byte[] data = Encoding.ASCII.GetBytes(LS); //Convert the message to bytearray
                Current.Send(data); //Send the data to the socket
                clientSockets.Remove(Current); //Remove the socket to prevent duplicate queries

            }
            else if (text.StartsWith("s")) //Check if user is submitting a score
            {
                string[] user = text.Split(','); //Define array with text split at every comma
                string Username = user[1]; //Split into induvidual variables
                string Score = user[2]; //Split into induvidual variables
                string GameID = user[3]; //Split into induvidual variables
                string Date = user[4]; //Split into induvidual variables


                string UserQuery = "INSERT INTO Results (Username, Score, GameID, Date) Values (@Username, @Score, @GameID, @Date)"; //SQL statement to insert into Results 
                SqlConnection UserConnect = new SqlConnection(ConfigurationManager.ConnectionStrings["CSData"].ConnectionString); //Define connection string
                SqlCommand UserCmd = new SqlCommand(UserQuery, UserConnect); //Create command to execute
                UserCmd.Parameters.AddWithValue("@Username", Username); //Define parameters
                UserCmd.Parameters.AddWithValue("@Score", Score); //Define parameters
                UserCmd.Parameters.AddWithValue("@GameID", GameID); //Define parameters
                UserCmd.Parameters.AddWithValue("@Date", Date); //Define parameters

                UserConnect.Open(); //Opens the connection
                UserCmd.ExecuteNonQuery(); //Execute the query
                UserConnect.Close(); //Close the connection
            }
            else
            {
                byte[] data = Encoding.ASCII.GetBytes("Invalid request"); //Convert error message to bytearray
                try
                {
                    Current.Send(data); //Send error to socket
                }
                catch
                {
                    Console.WriteLine("Client forcefully disconnected");
                }
                
            }
            Current.BeginReceive(buffer, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCallback, Current);
        }
    }
}


