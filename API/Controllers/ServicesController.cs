using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Persistance;

namespace API.Controllers
{
    public class ServicesController:BaseController
    {
        [HttpGet]
         public async Task<ActionResult<List<Service>>> GetServices()
         {
             List<Service> services = await Task.Run(() => MongoCRUD.LoadCollection<Service>("Services"));
             return services;
         }

        [HttpGet("{id}")]
         public async Task<ActionResult<Service>> GetService(Guid id)
         {
             Service service = await Task.Run(() => MongoCRUD.LoadDocumentByID<Service>("Services", id));
             return service;
         }

         
    }
}