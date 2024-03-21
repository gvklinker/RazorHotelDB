using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Rooms
{
    public class IndexModel : PageModel
    {

        public List<Room> Rooms { get; private set; }

        [BindProperty(SupportsGet = true)]
        public int Hotel_nr { get; set; }

        IRoomService roomService;
        public IndexModel(IRoomService service)
        {
            this.roomService = service;
        }

        public void OnGet(int hotelnr)
        {
            Rooms = roomService.GetAllRoom(hotelnr);
            //FilterRooms();
        }

        //public void OnGetMyRooms(int cid)
        //{
        //    Hotel_nr = cid;
        //    OnGet();
        //}
    }
}
