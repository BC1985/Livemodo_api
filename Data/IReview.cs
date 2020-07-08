using System.Collections.Generic;
using Livemodo_db.Models;

namespace Livemodo_db.Data
{
    public interface ILivemodoCommands
    {
        IEnumerable<Review> GetCommands();
        Review GetReviewById(int id);

       
    }
    


}
