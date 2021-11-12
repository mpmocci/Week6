using Day29_Libri.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Day29_Libri
{
    public class DbAudioBookManager : IDbManagerAudioBook
    {

        public static List<AudioBook> audioBooks = new List<AudioBook>();


        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<AudioBook> GetAllBooks()
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.AudioBook";


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var titolo = (string)reader["Titolo"];
                    var autore = (string)reader["Autore"];
                    var codice = (string)reader["CodiceIBSN"];
                    var durata = (int)reader["Durata"];

                    AudioBook audioBook = new AudioBook(id, titolo, autore, codice, durata);

                    audioBooks.Add(audioBook);
                }
                connection.Close();

                return audioBooks;

            }




        }

        public AudioBook GetByTitle(string title)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.AudioBook WHERE Titolo = @t";
                command.Parameters.AddWithValue("@t", title);


                SqlDataReader reader = command.ExecuteReader();

                AudioBook audioBook = new AudioBook();
                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var titolo = (string)reader["Titolo"];
                    var autore = (string)reader["Autore"];
                    var codice = (string)reader["CodiceIBSN"];
                    var durata = (int)reader["Durata"];

                    audioBook = new AudioBook(id, titolo, autore, codice, durata);

                    audioBooks.Add(audioBook);
                }
                connection.Close();

                return audioBook;

            }



        }

        public bool InsertBook(AudioBook item)
        {

            bool isAdded = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO dbo.AudioBook VALUES (@t, @a, @c,@d) ";
                command.Parameters.AddWithValue("@t", item.Titolo);
                command.Parameters.AddWithValue("@a", item.Autore);
                command.Parameters.AddWithValue("@c", item.CodiceISBN);
                command.Parameters.AddWithValue("@d", item.Durata);

                int rigaInserita = command.ExecuteNonQuery();


                if (rigaInserita == 1)
                {
                   isAdded = true;
                }
                else
                {
                    isAdded = false;

                }

                connection.Close();

            }


            return isAdded;

        }

        public bool ModifyDuration(int id, int duration)
        {


            bool isAdded = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE dbo.AudioBook SET Durata = @d WHERE Id = @id";
                command.Parameters.AddWithValue("@d", duration);
                command.Parameters.AddWithValue("@id", id);

                int rigaInserita = command.ExecuteNonQuery();


                if (rigaInserita == 1)
                {
                    isAdded = true;
                }
                else
                {
                    isAdded = false;

                }

                connection.Close();

            }


            return isAdded;



        }
    }
}
