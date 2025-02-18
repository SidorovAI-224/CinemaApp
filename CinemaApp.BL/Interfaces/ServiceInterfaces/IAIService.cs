using CinemaApp.BL.AI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IAIService
    {
        //Task<List<VectorizedMovie>> GetVectorizedMovies();
        Task<List<VectorizedMovie>> GetRecommendedMovies(string query, uint maxResults);
        Task<List<VectorizedMovie>> GetSimilarMovies(int movieId, uint maxResults);
    }
}
