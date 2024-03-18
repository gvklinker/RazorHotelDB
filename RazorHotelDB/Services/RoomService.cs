using HotelDB24ConsoleStart.Interfaces;
using HotelDB24ConsoleStart.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorHotelDB.Services
{
    public class RoomService : IRoomService
    {

        private string insertSql = "INSERT INTO Room VALUES (@RoNum, @Type, @Price, HoNum)";
        public bool CreateRoom(int hotelNr, Room room)
        {
            using (SqlConnection connection = new SqlConnection(insertSql))
            {
                try
                {
                    SqlCommand command = new SqlCommand(insertSql, connection);
                    //command.Parameters.AddWithValue("@ID", hotel.HotelNr);
                    // command.Parameters.AddWithValue("@Name", hotel.Navn);
                    //command.Parameters.AddWithValue("@Address", hotel.Adresse);
                    command.Connection.Open();
                    int noOfRows = command.ExecuteNonQuery();
                    return noOfRows == 1;
                }
                catch (SqlException sqlExp) { Console.WriteLine(sqlExp.Message); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { }

            }
            return false;
        }

        public Room DeleteRoom(int roomNr, int hotelNr)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRoom(int hotelNr)
        {
            throw new NotImplementedException();
        }

        public Room GetRoomFromId(int roomNr, int hotelNr)
        {
            throw new NotImplementedException();
        }

        public bool UpdateRoom(Room room, int roomNr, int hotelNr)
        {
            throw new NotImplementedException();
        }
    }
}
