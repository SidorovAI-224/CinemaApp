using CinemaApp.BL.AI;


namespace CinemaApp.BL.Interfaces.ServiceInterfaces
{
    public interface IAiService
    {
        //Task<List<VectorizedMovie>> GetVectorizedMovies();
        Task<List<VectorizedMovie>> GetRecommendedMovies(string query, uint maxResults);
        Task<List<VectorizedMovie>> GetSimilarMovies(int movieId, uint maxResults);
    }
}
