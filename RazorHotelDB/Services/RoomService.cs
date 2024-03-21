using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorHotelDB.Services
{
    public class RoomService : Connection, IRoomService
    {

        private String queryString = "SELECT * FROM Room WHERE Hotel_No = @HNo";
        private String queryStringFromID = "SELECT * From Room where Hotel_No = @HNo AND Room_No = @ID";
        private String insertSql = "insert into Room Values (@ID, @HNo, @RType, @RPrice)";
        private String deleteSql = "delete from Room where Hotel_No = @HNo AND Room_No = @ID";
        private String updateSql = "update Room " +
                                   "set Room_No= @RoomID, Types=@RType, Price=@RPris " +
                                   "where Hotel_No = @HNo AND Room_No = @ID";
        public bool CreateRoom(int hotelNr, Room room)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(insertSql, connection);
                    command.Parameters.AddWithValue("@ID", room.RoomNr);
                    command.Parameters.AddWithValue("@HNo", room.HotelNr);
                    command.Parameters.AddWithValue("@RType", room.Types);
                    command.Parameters.AddWithValue("@RPrice", room.Pris);
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
            List<Room> rooms = new List<Room>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("@HNo", hotelNr);
                    command.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //int hotelNr = reader.GetInt32("Hotel_No");//.GetInt32(0);
                        int roomNr = reader.GetInt32("Room_No");
                        string type = reader.GetString("Types");
                        double price = reader.GetDouble("Price");
                        Room room = new Room(roomNr, type[0], price, hotelNr);
                        rooms.Add(room);
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Database error " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl " + ex.Message);
                }
                finally
                {
                    //her kommer man altid
                }
            }
            return rooms;
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
