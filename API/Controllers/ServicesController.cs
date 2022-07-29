using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Domain;

namespace API.Controllers
{
    public class ServicesController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<Service>>> GetServices(CancellationToken cancellationToken)
        {
            return await Mediator.Send(new ServiceList.Query(), cancellationToken);
        }

        [HttpGet("{id}")] // services/id
        public async Task<ActionResult<Service>> GetService(Guid id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new ServiceDetails.Query { Id = id }, cancellationToken);
        }

        [HttpGet("{county}/{town}")]
        public async Task<ActionResult<List<Service>>> GetServicesByLocation(string county, string town, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new ServiceListByLocation.Query { County = county, Town = town });
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(Service service, CancellationToken cancellationToken)
        {
           return Ok(await Mediator.Send(new CreateService.Command {Service = service}, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(Guid id, Service service, CancellationToken cancellationToken)
        {
           service.Id = id;
           return Ok(await Mediator.Send(new UpdateService.Command{ Service = service }, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteService.Command{ Id = id }, cancellationToken));
        }

    }
}