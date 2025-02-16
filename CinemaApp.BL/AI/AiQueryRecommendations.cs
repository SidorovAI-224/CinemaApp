using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;

namespace CinemaApp.BL.AI;

public class AiQueryRecommendations : AiBase
{
    
    public AiQueryRecommendations(List<VectorizedMovie> itemList, Uri uri, string model)
        : base(itemList, uri, model)
    {
        
    }

    public async Task<List<VectorizedMovie>> GetRecommendationsByQuery(string query, uint maxResults)
    {
        await GenerateEmbeddings(new List<Func<VectorizedMovie, string>>
        {
            movie => movie.Title,
        });

        ReadOnlyMemory<float> queryEmbedding = await Generator.GenerateEmbeddingVectorAsync(query);

        VectorSearchOptions searchOptions = new VectorSearchOptions()
        {
            Top = Convert.ToInt32(maxResults),
            VectorPropertyName = "Vector"
        };
        
        VectorSearchResults<VectorizedMovie> results = await Items.VectorizedSearchAsync(queryEmbedding, searchOptions);

        List<VectorizedMovie> recommendations = new();

        await foreach (VectorSearchResult<VectorizedMovie> result in results.Results)
        {
            recommendations.Add(result.Record);
        }
        
        return recommendations;
    }
    
}