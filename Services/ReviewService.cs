using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using Livemodo_db.Models;

namespace Livemodo_db.Services
{
    public class ReviewService
    {
        private readonly IMongoCollection<Review> _reviews;

        public ReviewService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _reviews = database.GetCollection<Review>(settings.ReviewsCollectionName);
        }
        public List<Review> GetAllReviews()
        {
            return _reviews.Find(review => true).ToList();
        }

        public Review GetReviewById(string id)
        {
            //_reviews.Find<Review>(book => review.id == id).FirstOrDefault();
            return _reviews.Find(review => review.Id == id).FirstOrDefault();
        }

        public Review PostReview(Review review)
        {
            _reviews.InsertOne(review);
            return review;
        }
        public void UpdateReview(string id, Review reviewInDB)
        {
            _reviews.ReplaceOne(review => review.Id == id, reviewInDB);
        }

        public void DeleteReview(Review reviewIndDB)
        {
            _reviews.DeleteOne(book => book.Id == reviewIndDB.Id);
        }

        public void DeleteReview(string id)
        {
            _reviews.DeleteOne(review => review.Id == id);
        }
    }
}
