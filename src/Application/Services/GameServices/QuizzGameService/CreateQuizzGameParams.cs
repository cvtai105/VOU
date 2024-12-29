using Application.Services.GameServices.Contract;

namespace Application.Services.GameServices.QuizzGameService
{
    public class CreateQuizzGameParams : CreateGameParamsBase
    {
        public Guid QuestionSetId { get; set; }
        public int WiningScore { get; set; }
    }
}