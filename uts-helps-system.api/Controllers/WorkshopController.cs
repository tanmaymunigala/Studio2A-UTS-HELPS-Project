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
    [Route("api/WorkshopController/")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly TokenManager _tokenManager;
        public WorkshopController(ApplicationDbContext context){
            _context = context;

        }
    

    [Route("CreateWorkshop/{WorkshopName}/{WorkshopDesc}/{WorkshopDateTime}")]
    public bool CreateWorkshop(int workshopId, string workshopName, string workshopDesc, DateTime workshopDateTime){
        
        var WorkshopModel = new Workshop(){
            WorkshopName = workshopName,
            WorkshopDesc = workshopDesc,
            WorkshopDateTime = workshopDateTime,

        };
        _context.WorkshopValues.Add(WorkshopModel);
        _context.SaveChanges();
        
        return true;
    }


    
}
}
