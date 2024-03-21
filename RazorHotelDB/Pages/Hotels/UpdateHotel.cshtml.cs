using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Models;
using RazorHotelDB.Services;

namespace RazorHotelDB.Pages.Hotels
{
    public class UpdateHotelModel : PageModel
    {
        [BindProperty]
        public Hotel HotelToUpdate { get; set; }
        private IHotelService _serv;

        public UpdateHotelModel(IHotelService hotServ)
        {
            _serv = hotServ;
        }

        public void OnGet(int hotelnr)
        {
            HotelToUpdate = _serv.GetHotelFromId(hotelnr);
        }

        public IActionResult OnPostUpdate()
        {
            bool ok = _serv.UpdateHotel(HotelToUpdate, HotelToUpdate.HotelNr);
            if (ok)
            {
                return RedirectToPage("GetAllHotels");
            }
            else
                return Page();
        }
    }
}
