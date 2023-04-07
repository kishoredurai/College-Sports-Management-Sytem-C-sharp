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

            /*
                        cmd.CommandText = "select * from Sports;";
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Console.WriteLine($"{reader.GetInt32(0)}     {reader.GetString(1).Trim()}   ");

                        }
                        reader.Close();*/

            // AddSports(connection);
            RemoveSport(connection);

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
            }


        }

        public static void AddScoreBoard(SqlConnection connection)
        {

            Console.WriteLine("The list of Tournament and Sports available are :");
            String getsportsquerry = "select * from Tournament_Sport;";
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
    }
}