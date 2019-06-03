using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using uts_helps_system.api.Models;
using uts_helps_system.api.Data;
using uts_helps_system.api.Security;
using uts_helps_system.api.ResourceManagement;
using Microsoft.Extensions.Logging;

namespace uts_helps_system.api.Controllers
{
    [Route("api/BookingController/")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;
        private readonly ILogger _logger;
        public BookingController(ILoggerFactory loggerFactory, ApplicationDbContext context)
        {
            _context = context;
            _tokenManager = new TokenManager(_context);
            _logger = loggerFactory.CreateLogger<BookingController>();
        }

        [Route("CreateBooking/{tokenId}/{WorkshopId}/")]
        public async Task<Boolean> CreateBooking(string tokenId, int workshopId)
        {
            var bookingModel = new Booking()
            {
                UserId = _tokenManager.GetUserIdFromToken(tokenId),
                WorkshopId = workshopId,
                BookingDate = DateTime.UtcNow,
            };
            await _context.BookingValues.AddAsync(bookingModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Booking added is {bookingModel}");
            return true;
        }

        [Route("ListAllBookings")]
        public List<Booking> ListAllBooking()
        {
            if (_context.BookingValues.Count() > 0)
            {
                var bookingList = _context.BookingValues.ToList();
                _logger.LogInformation($"Booking List found is {bookingList}");
                return bookingList;
            }
            else
            {
                _logger.LogInformation("There are no bookings currently");
                return null;
            }
        }

        [Route("DeleteBooking/{bookingId}")]
        public async Task<Boolean> DeleteBooking(int bookingId)
        {
            if (_context.BookingValues.Count() > 0)
            {
                var foundBooking = _context.BookingValues.Find(bookingId);
                if (foundBooking != null)
                {
                    _context.BookingValues.Remove(foundBooking);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Booking deleted is {foundBooking}");
                    return true;
                }
                else
                {
                    _logger.LogInformation("No booking found with given ID");
                    return false;
                }
            }
            else
            {
                _logger.LogInformation("There are no bookings to delete");
                return false;
            }
        }

        [Route("GetBooking/{bookingId}")]
        public Booking GetBooking(int bookingId)
        {
            if (_context.BookingValues.Count() > 0)
            {
                var foundBooking = _context.BookingValues.Find(bookingId);
                if (foundBooking != null)
                {
                    _logger.LogInformation($"Booking found is {foundBooking}");
                    return foundBooking;
                }
                else
                {
                    _logger.LogInformation("No booking found with given ID");
                    return null;
                }
            }
            else
            {
                _logger.LogInformation("There are no bookings currently");
                return null;
            }
        }
    }
}
