using Microsoft.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace College_Sports_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-7SPPOGN;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;MultipleActiveResultSets=True;");
            // SqlCommand cmd = connection.CreateCommand();
            connection.Open();
            
            while(true)
            {
                Console.WriteLine("=================================================");
                Console.WriteLine("             SPORT MANAGEMENT SYSTEM       ");
                Console.WriteLine("=================================================");
                Console.WriteLine("1.Add Sports");
                Console.WriteLine("2.Add Tournament");
                Console.WriteLine("3.Add Scoreboard");
                Console.WriteLine("4.Remove sport");
                Console.WriteLine("5.Remove Tournament");
                Console.WriteLine("6.view Scoreboard");
                Console.WriteLine("7.Edit Scoreboard");
                Console.WriteLine("8.Remove Player");

                Console.WriteLine("9.Exit");


                Console.WriteLine();
                Console.WriteLine("Enter Option : ");
                int option = Convert.ToInt16(Console.ReadLine());

              
                switch(option)
                {
                  

                    case 1:AddSports(connection);
                        Console.Clear();
                        break;
                    case 2:AddTournament(connection);
                        Console.Clear();
                        break;
                    case 3:AddScoreBoard(connection);
                        Console.Clear();
                        break;
                    case 4:RemoveSport(connection);
                        Console.Clear();
                        break;
                    case 5:RemoveTournament(connection);
                        Console.Clear();
                        break;
                    case 6:ViewScoreBoard(connection);
                        Console.Clear();
                        break;
                    case 7:EditScoreboard   (connection);
                        Console.Clear();
                        break;
                    case 8:RemovePlayer(connection);
                        Console.Clear();
                        break;
                    case 9:return;
                  
                }

            }

            // AddSports(connection);
            ViewScoreBoard(connection);

            connection.Close();


            /*Console.WriteLine("Hello, World!");
            */
        }


        public static void AddSports(SqlConnection connection)
        {
            Console.WriteLine("Enter Sports Name:");
            string SportName = Console.ReadLine();

            String querry = $"insert into Sports values('{SportName}')";
            using (SqlCommand command = new SqlCommand(querry, connection))
            {
                command.ExecuteReader();
                Console.WriteLine("Record Inserted Succesfully");
                Console.ReadLine();
            }

        }

        public static void AddTournament(SqlConnection connection)
        {
            Console.WriteLine("The list of sports available are :");
            String getsportsquerry = "select * from Sports;";
            using (SqlCommand command = new SqlCommand(getsportsquerry, connection))
            {
                Console.WriteLine("ID     Sports Name");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}        {reader.GetString(1).Trim()}   ");

                }
                reader.Close();

            }


            Console.WriteLine();

            Console.WriteLine("Enter Tournament Name:");
            string TournamentName = Console.ReadLine();
            Console.WriteLine("Enter Sports Id:");
            int SportId = Convert.ToInt32(Console.ReadLine());

            String InsertTournament = $"insert into Tournament values('{TournamentName}')";
            using (SqlCommand command = new SqlCommand(InsertTournament, connection))
            {
                command.BeginExecuteNonQuery();
                Console.WriteLine("Tournament Created Succesfully");

            }

            int Tournamentid = 0;
            String GetIdOfTournament = $"select tournament_id from Tournament where tournament_name = '{TournamentName}'";
            try
            {
                using (SqlCommand command = new SqlCommand(GetIdOfTournament, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Tournamentid = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            String InsertTournamentAndSports = $"insert into Tournament_Sport values({Tournamentid},{SportId})";
            using (SqlCommand command = new SqlCommand(InsertTournamentAndSports, connection))
            {
                command.ExecuteReader();
                Console.WriteLine("Tournament and Sports linked Succesfully");
            }

        }


        public static void RemoveSport(SqlConnection connection)
        {
            Console.WriteLine("Enter Sports Name:");
            String SportName = Console.ReadLine();
            String DeleteSports = $"delete from Sports where Sport_name = {SportName}";
            using (SqlCommand command = new SqlCommand(DeleteSports, connection))
            {
                command.ExecuteReader();
                Console.WriteLine("Sports Deleted Succesfully");
                Console.ReadLine();

            }


        }

        public static void RemoveTournament(SqlConnection connection)
        {
            Console.WriteLine("Enter Tournament Id:");
            int TournamentID = Convert.ToInt16(Console.ReadLine());
            String DeleteTournament = $"delete from Tournament where tournament_id = {TournamentID}";
            using (SqlCommand command = new SqlCommand(DeleteTournament, connection))
            {
                command.ExecuteReader();
                Console.WriteLine("Tournament Deleted Succesfully");
                Console.ReadLine();

            }


        }

        public static void AddScoreBoard(SqlConnection connection)
        {

            Console.WriteLine("The list of Tournament and Sports available are :");
            String getsportsquerry = "SELECT ts.id ,t.tournament_name, s.sport_name FROM Tournament_Sport ts JOIN Tournament t ON ts.tournament_id = t.tournament_id JOIN Sports s ON ts.sport_id = s.sport_id; ";
            using (SqlCommand command = new SqlCommand(getsportsquerry, connection))
            {
                Console.WriteLine("ID         Tournament Name                       Sport Name");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}        {reader.GetString(1).Trim()}          {reader.GetString(2).Trim()}");

                }
                reader.Close();

            }


            Console.WriteLine();

            Console.WriteLine("Enter Tournament ID:");
    
            int Tournament_sportid = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Team 1 ID:");

            int player1Id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Team 2 Id:");

            int player2Id = Convert.ToInt32(Console.ReadLine());

            String InsertScoreboard = $"insert into Scoreboard(tournament_sport_id,team1_Id,team2_Id,result) values('{Tournament_sportid}',{player1Id},{player2Id},'Match Not Started');";
            using (SqlCommand command = new SqlCommand(InsertScoreboard, connection))
            {
                command.BeginExecuteNonQuery();
                Console.WriteLine("ScoreBoard Created Succesfully");

            }
            Console.ReadLine();

        }

        public static void ViewScoreBoard(SqlConnection connection)
        {

            Console.WriteLine("The List of Tournament and Sports available are :");
            Console.WriteLine();
            String getsportsquerry = "SELECT ts.id ,t.tournament_name, s.sport_name FROM Tournament_Sport ts JOIN Tournament t ON ts.tournament_id = t.tournament_id JOIN Sports s ON ts.sport_id = s.sport_id; ";
            using (SqlCommand command = new SqlCommand(getsportsquerry, connection))
            {
                Console.WriteLine("ID         Tournament Name                       Sport Name");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}        {reader.GetString(1).Trim()}          {reader.GetString(2).Trim()}");

                }
                reader.Close();

            }


            Console.WriteLine();

            Console.WriteLine("Enter Tournament ID:");

            int Tournament_sportid = Convert.ToInt32(Console.ReadLine());


            String GetScoreboard = $"SELECT  scoreboard.scoreboard_id,  team1.player_name AS team1_name,     team2.player_name AS team2_name,   scoreboard.team1_score,    scoreboard.team2_score , scoreboard.result FROM    Scoreboard AS scoreboard    JOIN Player AS team1 ON scoreboard.team1_Id = team1.player_id    JOIN Player AS team2 ON scoreboard.team2_Id = team2.player_id WHERE scoreboard.tournament_sport_id = {Tournament_sportid}";
            using (SqlCommand command = new SqlCommand(GetScoreboard, connection))
            {
                Console.WriteLine("ID   TEAM A Name     TEAM B Name    TEAM A Score   TEAM B Score    Result");
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}        {reader.GetString(1).Trim()}            {reader.GetString(2).Trim()}              {reader.GetInt32(3)}                {reader.GetInt32(4)}        {reader.GetString(5).Trim()}");

                }
                reader.Close();

            }
            Console.ReadLine();

        }





        public static void EditScoreboard(SqlConnection connection)
        {

            Console.WriteLine("The List of Tournament and Sports available are :");
            Console.WriteLine();
            String getsportsquerry = "SELECT sb.scoreboard_id, t.tournament_name, s.sport_name, sb.team1_name, sb.team1_score, sb.team2_name, sb.team2_score, sb.result FROM Scoreboard sb JOIN Tournament_Sport ts ON sb.tournament_sport_id = ts.id JOIN Tournament t ON ts.tournament_id = t.tournament_id JOIN Sports s ON ts.sport_id = s.sport_id;";
            using (SqlCommand command = new SqlCommand(getsportsquerry, connection))
            {
                Console.WriteLine("ID  Tournament Name                           Sport Name  TEAM A Name     TEAM B Name    TEAM A Score   TEAM B Score    Result");
                Console.WriteLine("==============================================================================================================================");

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetInt32(0)}   {reader.GetString(1).Trim()}          {reader.GetString(2).Trim()}      {reader.GetString(3).Trim()}              {reader.GetInt32(4)}              {reader.GetString(5).Trim()}                {reader.GetInt32(6)}        {reader.GetString(7).Trim()}");

                }
                reader.Close();

            }


            Console.WriteLine();

            Console.WriteLine("Enter scoreboard ID:");

            int scoreboard = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Team A Score : ");
            int teamAscore = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Enter Team B Score : ");
            int teamBscore = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Match Result : ");
            String result = Console.ReadLine();

            String updatescoreboard = $"update Scoreboard set team1_score = {teamAscore}, team2_score = {teamBscore}, result = '{result}'  where scoreboard_id = {scoreboard}";
            using (SqlCommand command = new SqlCommand(updatescoreboard, connection))
            {
                command.ExecuteReader();
                Console.WriteLine("Scoreboard Updated Succesfully");

            }
            Console.ReadLine();

        }






        public static void RemovePlayer(SqlConnection connection)
        {

                      Console.WriteLine("Enter Player ID:");

            int playerId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Tournament Sport ID : ");
            int tournamentID = Convert.ToInt32(Console.ReadLine());



            String updatescoreboard = $"delete from Tournament_Sport_player where Tournament_Sport_id = {tournamentID} and player_id = {playerId}";
            using (SqlCommand command = new SqlCommand(updatescoreboard, connection))
            {
                command.ExecuteReader();
                Console.WriteLine("removed player from tournament Succesfully");

            }
            Console.ReadLine();

        }
    }



}