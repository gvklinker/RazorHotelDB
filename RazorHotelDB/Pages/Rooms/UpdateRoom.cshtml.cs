using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Rooms
{
    public class UpdateRoomModel : PageModel
    {
        [BindProperty]
        public Room RoomToUpdate { get; set; }
        private IRoomService _serv;
        [BindProperty]
        public RoomType TheRoomType { get; set; }

        public UpdateRoomModel(IRoomService romServ)
        {
            _serv = romServ;
        }

        public void OnGet(int hotelnr, int roomnr)
        {
            RoomToUpdate = _serv.GetRoomFromId(roomnr, hotelnr);
        }

        public IActionResult OnPostUpdate(int roomnr, int hotelnr)
        {
            RoomToUpdate.Types = TheRoomType.ToString()[0];
            bool ok = _serv.UpdateRoom(RoomToUpdate, roomnr, hotelnr);
            if (ok)
            {
                return RedirectToPage("Index");
            }
            else
                return Page();
        }
    }
}
