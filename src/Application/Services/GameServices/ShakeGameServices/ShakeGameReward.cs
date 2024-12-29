using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.GameDTOs;
using Domain.Entities;

namespace Application.Services.GameServices.ShakeGameServices
{
    public class ShakeGameReward : GameRewardBase
    {
        public string RewardType { get; set; } = Domain.Constants.RewardType.VoucherPiece;
        public int Amount { get; set; } = 1;
        public VoucherPiece VoucherPiece { get; set; } = null!;
    }
}