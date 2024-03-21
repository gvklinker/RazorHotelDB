using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;

namespace RazorHotelDB.Pages.Hotels
{
    public class DeleteHotelModel : PageModel
    {
        private IHotelService _serv;

        //[BindProperty]
        public Hotel DeleteHotel { get; set; }


        public DeleteHotelModel(IHotelService repo)
        {
            _serv = repo;
        }
        public IActionResult OnGet(int hotelnr)
        {
            DeleteHotel = _serv.GetHotelFromId(hotelnr);
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            _serv.DeleteHotel(id);
            return RedirectToPage("GetAllHotels");
        }

        public IActionResult OnCancel()
        {
            return RedirectToPage("GetAllHotels");
        }
    }
}
