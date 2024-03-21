using RazorHotelDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;
using RazorHotelDB.Pages.Hotels;

namespace RazorHotelDB.Pages.Hotels
{
    public class CreateHotelModel : PageModel
    {
        private IHotelService _hotelService;
        [BindProperty]
        public Hotel Hotel { get; set; }
        public void OnGet()
        {
        }

        public CreateHotelModel(IHotelService hServ)
        {
            _hotelService = hServ;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                return Page();
            }
            _hotelService.CreateHotel(Hotel);
            return RedirectToPage("GetAllHotels");
        }
    }
}
