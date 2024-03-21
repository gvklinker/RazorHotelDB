using RazorHotelDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB.Interfaces;

namespace RazorHotelDB.Pages.Hotels
{
    public class GetAllHotelsModel : PageModel
    {
        private IHotelService _hotelService;

        public List<Hotel> Hotels { get; set; }

        public GetAllHotelsModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public void OnGet()
        {
            Hotels = _hotelService.GetAllHotel();
        }
    }
}
