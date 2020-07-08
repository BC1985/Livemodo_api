using System;
using System.Collections.Generic;
using Livemodo_db.Data;
using Livemodo_db.Models;
using Microsoft.AspNetCore.Mvc;
using Livemodo_db;
using Livemodo_db.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace Livemodo_db.Controllers
{

    // Get api/reviews
    [Route("api/reviews")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {      
        private readonly ReviewService _reviewService;

        public ReviewsController(ReviewService reviewService)
        {
            _reviewService = reviewService;
        }
        //get all reviews
        [HttpGet]
        [EnableCors("AllowOrigin")]

        public ActionResult<List<Review>> Get() =>
            _reviewService.GetAllReviews();


        // Get api/reviews/{id}
        [HttpGet("{id:length(24)}",Name ="GetReview")]
        public ActionResult<Review> GetReviewById(string id)
        {
            var review = _reviewService.GetReviewById(id);
            if(review == null)
            {
                return NotFound();
            }
            return review;
            //var commandItem = _repo.GetReviewById(id);
            //return Ok(commandItem);
        }
        [Authorize]
        [HttpPost("post_review")]
        [EnableCors("AllowAllHeaders")]

        public ActionResult<Review> PostReview(Review review)
        {
            _reviewService.PostReview(review);
            return CreatedAtRoute("GetReview", new { id = review.Id.ToString() }, review);
        }
        //PUT api/reviews/{id}

        [HttpPut("{id}")]
        public IActionResult UpdateReview(string id, Review reviewInDB)
        {
            var review = _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            _reviewService.UpdateReview(id, reviewInDB);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public IActionResult DeleteReview(string id)
        {
            var review = _reviewService.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            _reviewService.DeleteReview(review.Id);
            return NoContent();
        }
    }

}
