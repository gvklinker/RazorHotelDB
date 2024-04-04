using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Rooms
{
    public class DeleteRoomModel : PageModel
    {
        private IRoomService _serv;

        [BindProperty]
        public Room DeleteRoom { get; set; }

        public DeleteRoomModel(IRoomService repo)
        {
            _serv = repo;
        }
        public IActionResult OnGet(int roomnr, int hotelnr)
        {
            DeleteRoom = _serv.GetRoomFromId(roomnr, hotelnr);
            return Page();
        }

        public IActionResult OnPostDelete(int hotelnr, int roomnr)
        {
            _serv.DeleteRoom(roomnr, hotelnr);
            return RedirectToPage("Index");
        }

        public IActionResult OnCancel()
        {
            return RedirectToPage("Index");
        }
    }
}
