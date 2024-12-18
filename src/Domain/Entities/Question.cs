using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid QuestionSetId { get; set; }
        public string Content { get; set; } = null!;
        public string AnswerList { get; set; } = null!;
        public int CorrectAnswer { get; set; } 

        // Navigation Property
        public QuestionSet QuestionSet { get; set; } = null!;
    }
}