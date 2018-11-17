using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataLayer
{
    public class MonitoringRepository : IMonitoringRepository
    {
        private string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];

        public List<Monitoring> GetAllLogs()
        {
            List<Monitoring> listToReturn = new List<Monitoring>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT m.id,c.Name,a.Address,a.Type,ow.OwnerNameSurname,m.Client_Identification_number,cl.Name_Surname,m.Date,m.Status, a.Id, cl.Telephone_number, a.Number FROM Monitoring m, Apartments a, Cities c, Clients cl, Owners ow WHERE c.Id=a.City_Id AND a.Id=m.Apartment_Id AND m.Client_Identification_number=cl.Identification_number AND ow.Id = a.Owner_Id";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Monitoring m = new Monitoring();
                    m.Id = dataReader.GetInt32(0);
                    m.CityName = dataReader.GetString(1);
                    m.ApartmentAddress = dataReader.GetString(2);
                    m.ApartmentType = dataReader.GetString(3);
                    m.OwnerNameSurname = dataReader.GetString(4);
                    m.Client_Identification_number = dataReader.GetString(5);
                    m.ClientNameSurname = dataReader.GetString(6);
                    m.Date = dataReader.GetDateTime(7);
                    m.Status = dataReader.GetString(8);
                    m.Apartment_id = dataReader.GetInt32(9);
                    m.Telephone = dataReader.GetString(10);
                    m.ApartmentNumber = dataReader.GetInt32(11);
                    listToReturn.Add(m);
                }
            }
            return listToReturn;
        }

        public List<Monitoring> GetAllLogsByDateBetween(DateTime date_od, DateTime date_do)
        {
            List<Monitoring> listToReturn = new List<Monitoring>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT m.id,c.Name,a.Address,a.Type,ow.OwnerNameSurname,m.Client_Identification_number,cl.Name_Surname,m.Date,m.Status, a.Id, cl.Telephone_number, a.Number  FROM Monitoring m, Apartments a, Cities c, Clients cl, Owners ow WHERE  c.Id=a.City_Id AND a.Id=m.Apartment_Id AND m.Client_Identification_number=cl.Identification_number AND ow.Id = a.Owner_Id AND m.Date BETWEEN '" + date_od + "' AND '" + date_do + "' ORDER BY m.Date ASC";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Monitoring m = new Monitoring();
                    m.Id = dataReader.GetInt32(0);
                    m.CityName = dataReader.GetString(1);
                    m.ApartmentAddress = dataReader.GetString(2);
                    m.ApartmentType = dataReader.GetString(3);
                    m.OwnerNameSurname = dataReader.GetString(4);
                    m.Client_Identification_number = dataReader.GetString(5);
                    m.ClientNameSurname = dataReader.GetString(6);
                    m.Date = dataReader.GetDateTime(7);
                    m.Status = dataReader.GetString(8);
                    m.Apartment_id = dataReader.GetInt32(9);
                    m.Telephone = dataReader.GetString(10);
                    m.ApartmentNumber = dataReader.GetInt32(11);
                    listToReturn.Add(m);
                }
            }
            return listToReturn;
        }

        public List<Monitoring> GetlogsFilterAll(string cname, string owname, string clname, string status)
        {
            List<Monitoring> listToReturn = new List<Monitoring>();
            using (SqlConnection dataConnection = new SqlConnection(this.ConnectionString))
            {
                dataConnection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = dataConnection;
                command.CommandText = "SELECT m.Id, m.Apartment_Id, cl.Telephone_number, a.Number, c.Name,a.Address,a.Type,ow.OwnerNameSurname,cl.Name_Surname,m.Client_Identification_number,m.Status, m.Date FROM Monitoring m, Apartments a, Cities c, Clients cl, Owners ow WHERE c.Id=a.City_Id AND a.Id=m.Apartment_Id AND m.Client_Identification_number=cl.Identification_number AND ow.Id = a.Owner_Id AND c.Name IN (" + cname + ")  AND ow.OwnerNameSurname IN (" + owname + ") AND cl.Name_Surname IN (" + clname + ")  AND m.Status IN (" + status + ")";
                SqlDataReader dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    Monitoring m = new Monitoring();
                    m.Id = dataReader.GetInt32(0);
                    m.Apartment_id = dataReader.GetInt32(1);
                    m.Telephone = dataReader.GetString(2);
                    m.ApartmentNumber = dataReader.GetInt32(3);
                    m.CityName = dataReader.GetString(4);
                    m.ApartmentAddress = dataReader.GetString(5);
                    m.ApartmentType = dataReader.GetString(6);
                    m.OwnerNameSurname = dataReader.GetString(7);
                    m.ClientNameSurname = dataReader.GetString(8);
                    m.Client_Identification_number = dataReader.GetString(9);
                    m.Status = dataReader.GetString(10);
                    listToReturn.Add(m);
                }
            }
            return listToReturn;
        }
    }
}