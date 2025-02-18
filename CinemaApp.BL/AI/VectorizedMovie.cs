using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using Microsoft.Extensions.VectorData;

namespace CinemaApp.BL.AI;

public class VectorizedMovie
{
    [VectorStoreRecordData]
    public string Title { get; set; }

    [VectorStoreRecordData]
    public string Genre { get; set; }

    [VectorStoreRecordData]
    public string Description { get; set; }

    [VectorStoreRecordVector(4096, DistanceFunction.CosineSimilarity)]
    public ReadOnlyMemory<float> Vector { get; set; }

    [VectorStoreRecordKey]
    public int MovieId { get; set; } // Додайте MovieId для посилань
    public string PosterUrl { get; set; } // Додайте PosterUrl для відображення постерів

    public VectorizedMovie(MovieDTO movieDto)
    {
        Title = movieDto.Title;
        Genre = movieDto.GenreName;
        Description = movieDto.Description;
        MovieId = movieDto.MovieID;
        PosterUrl = movieDto.PosterURL;
    }
}
