using DataLayer.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class OwnerRepository : IOwnerRepository
    {
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public List<Owner> GetAllOwners()
        {
            List<Owner> listToReturn = new List<Owner>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Owners";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Owner o = new Owner();

                    o.Id = dataReader.GetInt32(0);
                    o.OwnerNameSurname = dataReader.GetString(1);
                    o.Username = dataReader.GetString(2);
                    o.Password = dataReader.GetString(3);
                    o.Role = dataReader.GetString(4);

                    listToReturn.Add(o);
                }
            }
            return listToReturn;
        }

        public int InsertOwner(Owner o)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Owners VALUES ('" + o.OwnerNameSurname + "', '" + o.Username + "', '" + o.Password + "', '" + o.Role + "', '" + o.SecureQuestion1 + "', '" + o.SecureQuestion2 + "')";
                // koristi se za izvršenje INSERT, UPDATE ili DELETE SQL upita
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateOwner(Owner o)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Owners SET"
                    + " OwnerNameSurname ='" + o.OwnerNameSurname + "'"
                    + ",Role ='" + o.Role + "'" +
                    "WHERE Id= " + o.Id;

                // koristi se za izvršenje INSERT, UPDATE ili DELETE SQL upita
                return command.ExecuteNonQuery();
            }
        }

        public Owner GetOwnerLogin(string username, string password)
        {
            Owner ow = new Owner();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT Id, Username, Password, OwnerNameSurname, Role FROM Owners WHERE Username  = '" + username + "' AND Password = '" + password + "'";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ow.Id = dataReader.GetInt32(0);
                    ow.Username = dataReader.GetString(1);
                    ow.Password = dataReader.GetString(2);
                    ow.OwnerNameSurname = dataReader.GetString(3);
                    ow.Role = dataReader.GetString(4);
                }
            }
            return ow;
        }

        public Owner CheckDuplicateUsername(string username)
        {
            Owner ow = new Owner();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT Username FROM Owners WHERE Username  = '" + username + "'";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    ow.Username = dataReader.GetString(0);
                }
            }
            return ow;
        }

        public int DeleteOwner(int id)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Owners WHERE Id = " + id;
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateOwnerPassword(Owner o)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Owners SET"
                    + " Password ='" + o.Password + "'" +
                    "WHERE Id= " + o.Id;

                // koristi se za izvršenje INSERT, UPDATE ili DELETE SQL upita
                return command.ExecuteNonQuery();
            }
        }

        public List<Owner> GetAllOwnersByRoleOwner()
        {
            List<Owner> listToReturn = new List<Owner>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT * FROM Owners WHERE Role = 'Vlasnik'";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Owner o = new Owner();

                    o.Id = dataReader.GetInt32(0);
                    o.OwnerNameSurname = dataReader.GetString(1);
                    o.Username = dataReader.GetString(2);
                    o.Password = dataReader.GetString(3);
                    o.Role = dataReader.GetString(4);

                    listToReturn.Add(o);
                }
            }
            return listToReturn;
        }

        public List<Owner> GetCheckUsernameBySecQuestion(string username, string secQuestion1, string secQuestion2)
        {
            List<Owner> listToReturn = new List<Owner>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT Username FROM Owners WHERE Username  = '" + username + "' AND SecureQuestion1 = '" + secQuestion1 + "' AND SecureQuestion2 = '" + secQuestion2 + "'";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Owner o = new Owner();
                    o.Username = dataReader.GetString(0);

                    listToReturn.Add(o);
                }
            }
            return listToReturn;
        }

        public int UpdateOwnerPasswordByUsername(Owner o)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Owners SET "
                    + "Password ='" + o.Password + "'" +
                    " WHERE Username = '" + o.Username + "'";

                // koristi se za izvršenje INSERT, UPDATE ili DELETE SQL upita
                return command.ExecuteNonQuery();
            }
        }
    }
}