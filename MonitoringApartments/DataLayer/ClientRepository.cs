using DataLayer.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ClientRepository : IClientRepository
    {
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public List<Client> GetAllClients()
        {
            List<Client> listToReturn = new List<Client>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Clients";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Client c = new Client();

                    c.Identification_number = dataReader.GetString(0);
                    c.Name_Surname = dataReader.GetString(1);
                    c.Telephone_number = dataReader.GetString(2);

                    listToReturn.Add(c);
                }
            }
            return listToReturn;
        }

        public int InsertClient(Client c)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Clients VALUES (" +
                    c.Identification_number + ", '" +
                    c.Name_Surname + "', '" +
                    c.Telephone_number + "')";

                // koristi se za izvršenje INSERT, UPDATE ili DELETE SQL upita
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateClient(Client c)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Clients SET"
                    + " Name_Surname ='" + c.Name_Surname + "'"
                    + ", Telephone_number ='" + c.Telephone_number + "'" +
                    "WHERE Identification_number= " + c.Identification_number;

                // koristi se za izvršenje INSERT, UPDATE ili DELETE SQL upita
                return command.ExecuteNonQuery();
            }
        }

        public List<Client> GetClientByJMBG(string jmbg)
        {
            List<Client> listToReturn = new List<Client>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT Identification_number FROM Clients WHERE Identification_number = " + jmbg;

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Client c = new Client();

                    c.Identification_number = dataReader.GetString(0);
                    listToReturn.Add(c);
                }
            }
            return listToReturn;
        }
    }
}