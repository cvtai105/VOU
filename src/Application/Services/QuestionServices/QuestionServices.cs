using Application.DTOs.QuestionDTOs;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.QuestionServices;

public class QuestionServices : IQuestionServices
{
    private readonly IApplicationDbContext _context;

    public QuestionServices(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<QuestionSetDTO> CreateQuestionSetAsync(QuestionSetDTO questionSetDTO, Guid userId)
    {
        var brand = _context.Brands
            .Where(x => x.UserId == userId)
            .Select(x => new { x.UserId, x.Id })
            .FirstOrDefault();
            
        if (brand == null)
        {
            throw new Exception("Brand not found");
        }
        var questionSet = new QuestionSet
        {
            Name = questionSetDTO.Name,
            BrandId = brand.Id
        };
        _context.QuestionSets.Add(questionSet);

        var questions = questionSetDTO.Questions.Select(x => new Question
        {
            Content = x.Content,
            CorrectAnswer = x.CorrectAnswer,
            QuestionSetId = questionSet.Id
        }).ToList();

        _context.Questions.AddRange(questions);

        await _context.SaveChangesAsync();

        questionSetDTO.QuestionSetId = questionSet.Id;
        questionSetDTO.BrandId = brand.Id;
        questionSetDTO.Questions = questions.Select(x => new QuestionDTO
        {
            QuestionId = x.Id,
            QuestionSetId = x.QuestionSetId,
            Content = x.Content,
            CorrectAnswer = x.CorrectAnswer
        }).ToList();

        return questionSetDTO;
    }

    public Task<List<QuestionSetDTO>> GetQuestionSets(Guid userId)
    {
        var brand = _context.Brands.Include(x => x.QuestionSets).ThenInclude(x => x.Questions).FirstOrDefault(x => x.UserId == userId);
        if (brand == null)
        {
            throw new Exception("Brand not found");
        }
        var questionSets = brand.QuestionSets;
        var questionSetDTOs = questionSets.Select(x => new QuestionSetDTO
        {
            QuestionSetId = x.Id,
            Name = x.Name,
            BrandId = x.BrandId,
            Questions = x.Questions.Select(q => new QuestionDTO
            {
                QuestionId = q.Id,
                QuestionSetId = q.QuestionSetId,
                Content = q.Content,
                CorrectAnswer = q.CorrectAnswer                
            }).ToList()
        }).ToList();
        return Task.FromResult(questionSetDTOs);
    }
}