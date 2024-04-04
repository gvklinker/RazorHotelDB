using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Rooms
{
    public class CreateRoomModel : PageModel
    {
        private IRoomService _serv;
        [BindProperty]
        public int HotelNr { get; set; }
        [BindProperty]
        public Room Room { get; set; }
        [BindProperty]
        public RoomType TheRoomType { get; set; }
        public IActionResult OnGet(int hotelnr)
        {
            HotelNr = hotelnr;
            return Page();
        }

        public CreateRoomModel(IRoomService rServ)
        {
            _serv = rServ;
        }

        public IActionResult OnPost(int hotelnr)
        {
            Room.HotelNr = hotelnr;
            Room.Types = TheRoomType.ToString()[0];
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}
            _serv.CreateRoom(hotelnr, Room);
            return RedirectToPage("Index");
        }
    }
}
