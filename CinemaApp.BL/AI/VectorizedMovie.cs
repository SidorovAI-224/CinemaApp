using CinemaApp.BL.DTOs.MovieDTOs.Movie;
using Microsoft.Extensions.VectorData;

namespace CinemaApp.BL.AI;

public class VectorizedMovie
{
    [VectorStoreRecordData]
    public string? Title { get; set; }

    [VectorStoreRecordData]
    public string? Genre { get; set; }

    [VectorStoreRecordData]
    public string? Description { get; set; }
    
    [VectorStoreRecordVector(4096, DistanceFunction.CosineSimilarity)]
    public ReadOnlyMemory<float> Vector { get; set; }

    public VectorizedMovie(MovieDto movieDto)
    {
        Title = movieDto.Title;
        
        Genre = movieDto.GenreName;

        Description = movieDto.Description;
    }
    
}
