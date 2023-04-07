using Microsoft.Data.SqlClient;

namespace College_Sports_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-7SPPOGN;Initial Catalog=SportsManagement;Integrated Security=True;Encrypt=False;");
            SqlCommand cmd = con.CreateCommand();
            con.Open();


            cmd.CommandText = "select * from Sports;";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetInt32(0)}     {reader.GetString(1).Trim()}   ");

            }
            reader.Close();

            AddSports(con);


            con.Close();

            
/*Console.WriteLine("Hello, World!");
*/        }


        public static void AddSports(SqlConnection con)
        {
            Console.WriteLine("Enter Sports Name:");
            string SportName = Console.ReadLine();

            String querry = $"insert into Sports values('{SportName}')";
            using (SqlCommand command = new SqlCommand(querry, con))
            {
                command.ExecuteReader();
                Console.WriteLine("Record Inserted Succesfully");
            }

        }

    }       
}