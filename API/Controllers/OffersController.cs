using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Domain;
using Application.Offers;
using Persistance;

namespace API.Controllers
{
    public class OffersController:BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOffer(Guid id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new OfferDetails.Query{ Id = id }, cancellationToken);
        }

       [HttpPost]
        public async Task<IActionResult> CreateOffer(Offer offer, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateOffer.Command{ Offer = offer }, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOffer(Guid id, Offer offer, CancellationToken cancellationToken)
        {
            offer.Id = id;
            return Ok(await Mediator.Send(new UpdateOffer.Command{ Offer = offer }, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteOffer.Command { Id = id }, cancellationToken));
        }
    }
}