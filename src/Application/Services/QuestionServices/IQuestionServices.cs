using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.QuestionDTOs;
using Domain.Entities;

namespace Application.Services.QuestionServices
{
    public interface IQuestionServices
    {
        Task<QuestionSetDTO> CreateQuestionSetAsync(QuestionSetDTO questionSetDTO , Guid userId);
        Task<List<QuestionSetDTO>> GetQuestionSets(Guid userId);
    }
}