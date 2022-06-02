using System;
using System.Linq;
using System.Collections.Generic;
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
        [HttpGet]
        public async Task<ActionResult<List<Offer>>> GetOffers()
        {
            return await Mediator.Send(new OfferList.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOffer(Guid id)
        {
            return await Mediator.Send(new OfferDetails.Query{ Id = id });
        }

       [HttpPost]
        public async Task<IActionResult> CreateOffer(Offer offer)
        {
            return Ok(await Mediator.Send(new CreateOffer.Command{ Offer = offer }));
        }
    }
}