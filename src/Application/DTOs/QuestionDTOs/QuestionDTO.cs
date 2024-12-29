using System.Text.Json.Serialization;
using Application.Helpers;

namespace Application.DTOs.QuestionDTOs;

public class QuestionDTO
{
    [JsonConverter(typeof(IgnoreIdOnDeserializeConverter))]
    public Guid QuestionId { get; set; }
    public Guid QuestionSetId { get; set; }
    public string Content { get; set; } = null!;
    public int CorrectAnswer { get; set; }
}
