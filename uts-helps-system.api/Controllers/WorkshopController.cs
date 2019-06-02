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
    

    [Route("CreateWorkshop/{WorkshopId}/{WorkshopName}/{WorkshopDesc}/{WorkshopDateTime}")]
    public bool CreateWorkshop(int WorkshopId, string WorkshopName, string WorkshopDesc, DateTime WorkshopDateTime){
        Workshop WorkshopModel = null;
        WorkshopModel.WorkshopId = WorkshopId;
        WorkshopModel.WorkshopName = WorkshopName;
        WorkshopModel.WorkshopDesc = WorkshopDesc;
        WorkshopModel.WorkshopDateTime = WorkshopDateTime;
        _context.WorkshopValues.Add(WorkshopModel);
        
        return true;
    }


    
}
}
