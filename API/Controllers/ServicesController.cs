using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain;
using Application.Services;
using Persistance;

namespace API.Controllers
{
    public class ServicesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetServices()
        {
            return await Mediator.Send(new ServiceList.Query());
        }

        [HttpGet("{id}")] // services/id
        public async Task<ActionResult<Service>> GetService(Guid id)
        {
            return await Mediator.Send(new ServiceDetails.Query { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(Service service)
        {
           return Ok(await Mediator.Send(new CreateService.Command {Service = service}));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(Guid id, Service service)
        {
           service.Id = id;
           return Ok(await Mediator.Send(new UpdateService.Command{ Service = service }));
        }

    }
}