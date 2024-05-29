using Lab6_DB.Migrations;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Lab6_DB.Contracts;

public class UpdateResponse
{
    public string Hash { get; set; } = null!;

    public DateTime UpdatetAt { get; set; }

    public string Message { get; set; } = null!;

    public Dictionary<string, object>? Difference { get; set; } = null!;

    public int UserId { get; set; }

    public static UpdateResponse ToResponse(Update update, Dictionary<string, object> diff)
    {
        return new UpdateResponse
        {
            Hash = update.Hash,
            UpdatetAt = update.UpdatedAt,
            Message = update.Message ,
            Difference = diff,
            UserId = update.UserId
        };
    }
    
    public static List<UpdateResponse> ToList(List<Update> updates)
    {
        var result = new List<UpdateResponse>();
        foreach (var update in updates)
        {
            Dictionary<string, object>? diff = JsonSerializer.Deserialize<Dictionary<string, object>>(update.Difference,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                });

            if (diff != null)
            {
                var updateResponse = new UpdateResponse()
                {
                    Hash = update.Hash,
                    UpdatetAt = update.UpdatedAt,
                    Message = update.Message,
                    Difference = diff,
                    UserId = update.UserId
                };
                result.Add(updateResponse);
            }
        }

        return result;
    }
}