using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ADO
{
    class DbManager : IDBManager
    {

        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog = Videoteca; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void GetAllFilm()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;

                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.Films"; //crea comando per leggere tabella

                SqlDataReader reader = command.ExecuteReader();//reader memorizza il risultato dell'esecuzione

                while (reader.Read()) //fintanto che ci sono righe da leggere
                {
                    var id = reader["FilmId"]; //reader legge i nomi delle colonne
                    var titolo = reader["Titolo"];
                    var genere = reader["Genere"];
                    var durata = reader["Durata"];

                    Console.WriteLine($"{id} - {titolo} - {genere} - {durata}");

                }

                connection.Close();
            }


        }

        public void GetFilmByDurataMax(int durataMax)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT * FROM dbo.Films WHERE Durata < @d";
                command.Parameters.AddWithValue("@d", durataMax);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["FilmId"]; //reader legge i nomi delle colonne
                    var titolo = reader["Titolo"];
                    var gen = reader["Genere"];
                    var durata = reader["Durata"];

                    Console.WriteLine($"{id} - {titolo} - {gen} - {durata}");

                }

                connection.Close();
            }

        }

        public void GetFilmByGenere(string genere)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT * FROM dbo.Films WHERE Genere = @g";
                command.Parameters.AddWithValue("@g", genere);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["FilmId"]; //reader legge i nomi delle colonne
                    var titolo = reader["Titolo"];
                    var gen = reader["Genere"];
                    var durata = reader["Durata"];

                    Console.WriteLine($"{id} - {titolo} - {gen} - {durata}");

                }

                connection.Close();
            }

        }

        public void GetFilmByGenereEDurataMin(string genere, int durataMin)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT * FROM Film WHERE Genere= @g AND Durata >@d";
                command.Parameters.AddWithValue("@g", genere);
                command.Parameters.AddWithValue("@d", durataMin);


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["FilmId"]; //reader legge i nomi delle colonne
                    var tit = reader["Titolo"];
                    var gen = reader["Genere"];
                    var dur = reader["Durata"];

                    Console.WriteLine($"{id} - {tit} - {gen} - {dur}");

                }
                connection.Close();
            }
        }

        public void InserisciFilm(string title, string genre, int length)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "insert into dbo.Films values( @Titolo, @Durata, @Genere)";
                command.Parameters.AddWithValue("@Titolo", title);
                command.Parameters.AddWithValue("@Durata", length);
                command.Parameters.AddWithValue("@Genere", genre);

                int rigaInserita = command.ExecuteNonQuery();
                if (rigaInserita == 1)
                {
                    Console.WriteLine("Film inserito correttamente");
                }
                else
                {
                    Console.WriteLine("Errore.Non è stato possibile inserire il film");
                }
            }

        }

        public void GetFilmByTitolo(string titolo)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT * FROM dbo.Films WHERE Titolo = @t";
                command.Parameters.AddWithValue("@t", titolo);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = reader["FilmId"]; //reader legge i nomi delle colonne
                    var tit = reader["Titolo"];
                    var gen = reader["Genere"];
                    var durata = reader["Durata"];

                    Console.WriteLine($"{id} - {tit} - {gen} - {durata}");

                }
                connection.Close();
            }

        }

        public void GetNumeroDiFilm()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;

                command.CommandText = "SELECT COUNT(*) FROM dbo.Films";

                int numFilm = (int)command.ExecuteScalar();



                Console.WriteLine($"Numero totale di film: {numFilm}");



                connection.Close();
            }


        }

        public void InserisciFlm(string title, string genre, int length)
        {
            throw new NotImplementedException();
        }

        public void EliminaFilm(int idFilmDaEliminare)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "DELETE FROM dbo.Films WHERE FilmId=@id ";
                command.Parameters.AddWithValue("@id", idFilmDaEliminare);


                int rigaModificata = command.ExecuteNonQuery();
                if (rigaModificata == 1)
                {
                    Console.WriteLine("Il film è stato eliminato correttamente.");


                }
                else
                {
                    Console.WriteLine("Errore.Non è stato possibile eliminare il film");
                }


            }
        }

        public void ModificaDurataFilm(int idFilmDaModificare, int NewDurata)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE dbo.Films SET Durata=@dur WHERE FilmId=@id ";
                command.Parameters.AddWithValue("@id", idFilmDaModificare);
                command.Parameters.AddWithValue("@dur", NewDurata);


                int rigaModificata = command.ExecuteNonQuery();
                if (rigaModificata == 1)
                {
                    Console.WriteLine("La durata è stata modificata correttamente.");


                }
                else
                {
                    Console.WriteLine("Errore.Non è stato possibile trovare il film");
                }


            }


        }
    }
}
