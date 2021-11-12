using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Week6_Paola_Mocci.Entities;

namespace Week6_Paola_Mocci
{
    public class DbManager : IDbManager
    {



        const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProvaAgenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public bool AddAgent(Agent agente)
        {
            bool isAdded=false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "INSERT INTO Agent VALUES (@n,@c, @cf,@ga,@a)";
                command.Parameters.AddWithValue("@n", agente.Nome);
                command.Parameters.AddWithValue("@c", agente.Cognome);
                command.Parameters.AddWithValue("@cf", agente.CodiceFiscale);
                command.Parameters.AddWithValue("@ga", agente.AreaGeografica);
                command.Parameters.AddWithValue("@a", agente.AnnoInizioAttivita);

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

                return isAdded;

            }



        }

        public List<Agent> GetAll()
        {

            List<Agent> agentList = new List<Agent>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Agent";


                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var cf = (string)reader["CodiceFiscale"];
                    var area = (string)reader["AreaGeografica"];
                    var annoInizio = (int)reader["AnnoInizioAttivita"];

                    Agent agente = new Agent(cf,nome,cognome,area,annoInizio);

                    agentList.Add(agente);
 
                }
                connection.Close();

                return agentList;

            }



        }

        public List<Agent> GetAllByGeographicArea(string area)
        {

            List<Agent> agentList = new List<Agent>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Agent WHERE AreaGeografica=@a";
                command.Parameters.AddWithValue("@a", area);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var cf = (string)reader["CodiceFiscale"];
                    var areaGeo = (string)reader["AreaGeografica"];
                    var annoInizio = (int)reader["AnnoInizioAttivita"];

                    Agent agente = new Agent(cf, nome, cognome, areaGeo, annoInizio);

                    agentList.Add(agente);

                }
                connection.Close();

                return agentList;

            }
        }

        public List<Agent> GetByYearsEqualGreaterThan(int years)
        {
             List<Agent> agentList = new List<Agent>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT * FROM Agent WHERE DATEPART(year, CURRENT_TIMESTAMP) - AnnoInizioAttivita >= @y";
                command.Parameters.AddWithValue("@y", years);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var nome = (string)reader["Nome"];
                    var cognome = (string)reader["Cognome"];
                    var cf = (string)reader["CodiceFiscale"];
                    var areaGeo = (string)reader["AreaGeografica"];
                    var annoInizio = (int)reader["AnnoInizioAttivita"];

                    Agent agente = new Agent(cf, nome, cognome, areaGeo, annoInizio);

                    agentList.Add(agente);

                }
                connection.Close();

                return agentList;

            }
        }








    }
}
