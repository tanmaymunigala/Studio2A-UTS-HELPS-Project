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
    [Route("api/WorkshopController/")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;
        public WorkshopController(ILoggerFactory loggerFactory, ApplicationDbContext context)
        {
            _logger = loggerFactory.CreateLogger<WorkshopController>();
            _context = context;
        }

        [Route("CreateWorkshop/{WorkshopName}/{WorkshopDesc}/{WorkshopDateTime}")]
        public async Task<Boolean> CreateWorkshop(int workshopId, string workshopName, string workshopDesc, DateTime workshopDateTime)
        {
            var workshopModel = new Workshop()
            {
                WorkshopName = workshopName,
                WorkshopDesc = workshopDesc,
                WorkshopDateTime = workshopDateTime,
            };
            _context.WorkshopValues.Add(workshopModel);
            await _context.SaveChangesAsync();
            _logger.LogInformation($"Workshop added is {workshopModel}");
            return true;
        }

        [Route("ListWorkshops")]
        public List<Workshop> ListWorkshops()
        {
            if (_context.WorkshopValues.Count() > 0)
            {
                var workshopList = _context.WorkshopValues.ToList();
                _logger.LogInformation($"Workshop found is {workshopList}");
                return workshopList;
            }
            else
            {
                _logger.LogInformation("There are no workshops available currently");
                return null;
            }
        }

        [Route("DeleteWorkshop/{workShopId}")]
        public async Task<Boolean> DeleteWorkshop(int workshopId)
        {
            if (_context.WorkshopValues.Count() > 0)
            {
                var foundWorkshop = _context.WorkshopValues.Find(workshopId);
                if (foundWorkshop != null)
                {
                    _context.WorkshopValues.Remove(foundWorkshop);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation($"Workshop deleted is {foundWorkshop}");
                    return true;
                }
                else
                {
                    _logger.LogInformation("No workshop found with given ID");
                    return false;
                }
            }
            else
            {
                _logger.LogInformation("There are no workshops available currently");
                return false;
            }
        }

        [Route("GetWorkshop/{workShopId}")]
        public Workshop GetWorkshop(int workshopId)
        {
            if (_context.WorkshopValues.Count() > 0)
            {
                var foundWorkshop = _context.WorkshopValues.Find(workshopId);
                if (foundWorkshop != null)
                {
                    _logger.LogInformation($"Workshop found is {foundWorkshop}");
                    return foundWorkshop;
                }
                else
                {
                    _logger.LogInformation("No workshop found with given ID");
                    return null;
                }
            }
            else
            {
                _logger.LogInformation("There are no workshops currently");
                return null;
            }
        }
    }
}
