using Application.DTOs.GameDTOs;

namespace Application.Services.GameServices.QuizzGameServices
{
    public class CreateQuizzGameParams : CreateGameParamsBase
    {
        public Guid QuestionSetId { get; set; }
        public int WiningScore { get; set; }
    }
}