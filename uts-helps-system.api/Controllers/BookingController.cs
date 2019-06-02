using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uts_helps_system.api.Models;
using uts_helps_system.api.Data;
using uts_helps_system.api.Security;
using uts_helps_system.api.ResourceManagement;

namespace uts_helps_system.api.Controllers
{
    [Route("api/BookingController/")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;
        public BookingController(ApplicationDbContext context){
            _context = context;
            _tokenManager = new TokenManager(_context);


        }
    

    [Route("CreateBooking/{tokenId}/{WorkshopId}/")]
    public async Task<Boolean> CreateBooking(string tokenId, int workshopId){
        var BookingModel = new Booking(){
            UserId = _tokenManager.GetUserIdFromToken(tokenId),
            WorkshopId = workshopId,
            BookingDate = DateTime.Now,
        };
        _context.BookingValues.Add(BookingModel);
        await _context.SaveChangesAsync();
        
        return true;
    }
        [Route("ListAllBookings")]
    public List<Booking> ListAllBooking(){

       return _context.BookingValues.ToList();

    }


        [Route("DeleteBooking/{bookingId}")]
    public async Task<Boolean> DeleteBooking(int bookingId){
        var FoundBooking = _context.BookingValues.Find(bookingId);
        _context.BookingValues.Remove(FoundBooking);
        await _context.SaveChangesAsync();

       return true;

    }

            [Route("GetBooking/{bookingId}")]
    public Booking GetWorkshop(int bookingId){
        var FoundBooking = _context.BookingValues.Find(bookingId);
       return FoundBooking;

    }



    
}
}
