using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.GameDTOs;
using Domain.Entities;


namespace Application.Services.GameServices.QuizGameServices
{
    public class QuizzGameReward : GameRewardBase
    {
        public string RewardType { get; set; } = Domain.Constants.RewardType.Voucher;
        public int Amount { get; set; } = 1;
        public Voucher Voucher { get; set; } = null!;
    }
}