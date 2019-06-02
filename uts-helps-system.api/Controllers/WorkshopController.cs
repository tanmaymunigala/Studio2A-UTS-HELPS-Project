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
    public async Task<Boolean> CreateWorkshop(int workshopId, string workshopName, string workshopDesc, DateTime workshopDateTime){
        
        var WorkshopModel = new Workshop(){
            WorkshopName = workshopName,
            WorkshopDesc = workshopDesc,
            WorkshopDateTime = workshopDateTime,

        };
        _context.WorkshopValues.Add(WorkshopModel);
        await _context.SaveChangesAsync();
        
        return true;
    }
        [Route("ListWorkshops")]
    public List<Workshop> ListWorkshops(){

       return _context.WorkshopValues.ToList();

    }


        [Route("DeleteWorkshop/{workShopId}")]
    public async Task<Boolean> DeleteWorkshop(int workshopId){
        var FoundWorkshop = _context.WorkshopValues.Find(workshopId);
        _context.WorkshopValues.Remove(FoundWorkshop);
        await _context.SaveChangesAsync();

       return true;

    }

            [Route("GetWorkshop/{workShopId}")]
    public Workshop GetWorkshop(int workshopId){
        var FoundWorkshop = _context.WorkshopValues.Find(workshopId);
       return FoundWorkshop;

    }



    
}
}
