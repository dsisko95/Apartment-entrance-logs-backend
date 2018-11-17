using DataLayer.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class CityRepository : ICityRepository
    {
        private string ConnectionString;

        public CityRepository()
        {
            ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public List<City> GetAllCities()
        {
            List<City> lstToReturn = new List<City>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Cities";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    City c = new City();
                    c.Id = reader.GetInt32(0);
                    c.Name = reader.GetString(1);
                    c.Country = reader.GetString(2);
                    lstToReturn.Add(c);
                }
            }
            return lstToReturn;
        }

        public int InsertCity(City c)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO Cities VALUES('" + c.Name + "', '" + c.Country + "')";
                return cmd.ExecuteNonQuery();
            }
        }

        public int UpdateCity(City c)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE Cities SET Name = '" + c.Name + "' WHERE Id = " + c.Id + "";
                return cmd.ExecuteNonQuery();
            }
        }

        public List<City> GetCityByName(string cityName)
        {
            List<City> lstToReturn = new List<City>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT DISTINCT Name FROM Cities WHERE Name = '" + cityName + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    City c = new City();
                    c.Name = reader.GetString(0);
                    lstToReturn.Add(c);
                }
            }
            return lstToReturn;
        }

        public int DeleteCity(int id)
        {
            using (SqlConnection dataConnection = new SqlConnection(ConnectionString))
            {
                dataConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "DELETE FROM Cities WHERE Id = " + id;
                return command.ExecuteNonQuery();
            }
        }
    }
}