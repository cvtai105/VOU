using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Helpers;

namespace Application.DTOs.QuestionDTOs;

public class QuestionSetDTO
{
    [JsonConverter(typeof(IgnoreIdOnDeserializeConverter))]
    public Guid QuestionSetId { get; set; }
    public string Name { get; set; } = null!;
    public Guid BrandId { get; set; }
    public List<QuestionDTO> Questions { get; set; } = [];
}
