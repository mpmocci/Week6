using Day29_Libri.Entities;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Day29_Libri
{
    public class DbPaperBookManager : IDbManagerPaperBook
    {

        public static List<PaperBook> paperBooks = new List<PaperBook>();
  
        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Books;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        public List<PaperBook> GetAllBooks()
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.PaperBook";


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var titolo = (string)reader["Titolo"];
                    var autore = (string)reader["Autore"];
                    var codice = (string)reader["CodiceIBSN"];
                    var numeroPagine = (int)reader["NumeroPagine"];
                    var quantita = (int)reader["Quantita"];

                    PaperBook paperBook = new PaperBook(id, titolo, autore, codice, numeroPagine, quantita);

                    paperBooks.Add(paperBook);
                }
                connection.Close();

                return paperBooks;

            }
        }

        public PaperBook GetByTitle(string title)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM dbo.PaperBook WHERE Titolo =@t";
                command.Parameters.AddWithValue("@t", title);


                SqlDataReader reader = command.ExecuteReader();

                PaperBook paperBook = new PaperBook();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var titolo = (string)reader["Titolo"];
                    var autore = (string)reader["Autore"];
                    var codice = (string)reader["CodiceIBSN"];
                    var numeroPagine = (int)reader["NumeroPagine"];
                    var quantita = (int)reader["Quantita"];

                    paperBook = new PaperBook(id, titolo, autore, codice, numeroPagine, quantita);

                    paperBooks.Add(paperBook);
                }

                connection.Close();

                return paperBook;
            }

        }

        public bool InsertBook(PaperBook item)
        {

            bool isAdded = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO dbo.PaperBook VALUES (@t, @a, @c,@n, @q) ";
                command.Parameters.AddWithValue("@t", item.Titolo);
                command.Parameters.AddWithValue("@a", item.Autore);
                command.Parameters.AddWithValue("@c", item.CodiceISBN);
                command.Parameters.AddWithValue("@n", item.NumeroPagine);
                command.Parameters.AddWithValue("@q", item.QuantitaMagazzino);

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

        public bool ModifyQuantity(int id, int quantity)
        {


            bool isAdded = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "UPDATE dbo.PaperBook SET Quantita = @q WHERE Id = @id";
                command.Parameters.AddWithValue("@q", quantity);
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
