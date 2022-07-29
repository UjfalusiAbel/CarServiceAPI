using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Reviews;
using Domain;

namespace API.Controllers
{
    public class ReviewsController:BaseController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<Review>> GetReview(Guid id, CancellationToken cancellationToken)
        {
            return await Mediator.Send(new ReviewDetails.Query{ Id = id }, cancellationToken);
        }

       [HttpPost]
        public async Task<IActionResult> CreatReview(Review review, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CreateReview.Command { Review = review }, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(Guid id, Review review, CancellationToken cancellationToken)
        {
            review.Id = id;
            return Ok(await Mediator.Send(new UpdateReview.Command { Review = review }, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new DeleteReview.Command { Id = id }, cancellationToken));
        }
    }
}