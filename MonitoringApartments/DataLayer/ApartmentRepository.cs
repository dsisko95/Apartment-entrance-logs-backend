using DataLayer.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class ApartmentRepository : IApartmentRepository

    {
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public List<Apartment> GetAllApartments()
        {
            List<Apartment> listToReturn = new List<Apartment>();

            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT a.Id, a.Address, a.Type, a.Number, c.Name, o.OwnerNameSurname FROM Apartments a, Cities c, Owners o WHERE c.Id = a.City_Id AND a.Owner_Id = o.Id";

                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Apartment a = new Apartment();
                    a.Id = dataReader.GetInt32(0);
                    a.Address = dataReader.GetString(1);
                    a.Type = dataReader.GetString(2);
                    a.Number = dataReader.GetInt32(3);
                    a.CityName = dataReader.GetString(4);
                    a.OwnerNameSurname = dataReader.GetString(5);
                    listToReturn.Add(a);
                }
            }
            return listToReturn;
        }

        public int InsertApartment(Apartment a)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "INSERT INTO Apartments VALUES (" +
                    a.City_id + ", '" +
                    a.Address + "', '" +
                    a.Type + "', '" +
                    a.Number + "', '" +
                    a.OwnerId + "')";
                // koristi se za izvršenje INSERT, UPDATE ili DELETE SQL upita
                return command.ExecuteNonQuery();
            }
        }

        public int UpdateApartment(Apartment a)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "UPDATE Apartments SET"
                    + " City_id ='" + a.City_id + "'"
                    + ", Address ='" + a.Address + "'"
                    + ", Type ='" + a.Type + "'"
                    + ", Number ='" + a.Number + "'"
                    + ", Owner_Id ='" + a.OwnerId + "'" +
                    "WHERE Id= " + a.Id;

                // koristi se za izvršenje INSERT, UPDATE ili DELETE SQL upita
                return command.ExecuteNonQuery();
            }
        }
    }
}