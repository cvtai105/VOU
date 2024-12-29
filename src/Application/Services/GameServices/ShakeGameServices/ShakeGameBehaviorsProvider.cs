using Application.DTOs.GameDTOs;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.GameBehaviors;
using Application.Services.GameServices.ShakeGameServices;
using AutoMapper.Configuration.Annotations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.GameServicesShakeGameServices;

public class ShakeGameBehaviorsProvider : IGameBehaviorsProvider
{
    public Task<bool> CreateGameAsync(CreateGameParamsBase createGameParams, IApplicationDbContext _context)
    {
        if (createGameParams is CreateShakeGameParams shakeGameParams)
        {
            var newGame = new Game{
                EventId = shakeGameParams.EventId,
                GamePrototypeId = shakeGameParams.GamePrototypeId,
                StartTime = shakeGameParams.StartTime,
                EndTime = shakeGameParams.EndTime,
                Status = "Active"
            };

            _context.Games.Add(newGame);

            _context.ShakeGames.Add(new ShakeGame
            {
                EventGameId = newGame.Id,
                VoucherPieceCount = shakeGameParams.VoucherPieceCount?? 0,
            });

            return Task.FromResult(true);
        }
        else
        {
            throw new ArgumentException("Invalid createGameParams type");
        }
    }

    public Task<List<GameRewardBase>> GetPlayerRewardByGame(Guid gameId, Guid playerId, IApplicationDbContext context)
    {
        var userPieces = context.UserPieces
            .Where(x => x.UserId == playerId && x.GameId == gameId).ToList();

        var result = new List<GameRewardBase>();
        foreach (var piece in userPieces)
        {
            piece.VoucherPiece = context.VoucherPieces.Include(x => x.Voucher).First(x => x.Id == piece.VoucherPieceId);
            var reward = new ShakeGameReward
            {
                PlayerId = piece.UserId,
                GameId = piece.GameId,
                Amount = piece.Quantity,
                VoucherPiece = piece.VoucherPiece
            };
            result.Add(reward);
        }
        return Task.FromResult(result);

    }

    public async Task<GameRewardBase> RewardPrizesAsync(Guid playerId, Guid gameId, IApplicationDbContext context)
    {
        var game = context.Games
                        .Include(x => x.Event)
                        .ThenInclude(x => x.EventVouchers)
                        .FirstOrDefault(x => x.Id == gameId);
        if (game == null) {
            throw new NotFoundException("Game not found");
        }
        var eventEntity = game.Event;
        if (eventEntity == null) {
            throw new NotFoundException("Event not found");
        }
        var vouchers = game.Event.EventVouchers.Select(x => x.Voucher).ToList();
        if (vouchers == null || vouchers.Count == 0) {
            throw new NotFoundException("Event Vouchers not found");
        }

        var result = new ShakeGameReward
        {
            PlayerId = playerId,
            GameId = gameId
        };

        //Random a voucher in voucher
        var random = new Random();
        var randomVoucher = vouchers[random.Next(vouchers.Count)];

        //Random a piece of voucher
        var voucherPieces = context.VoucherPieces.Where(x => x.VoucherId == randomVoucher.Id).ToList();
        var randomPiece = voucherPieces[random.Next(voucherPieces.Count)];

        //find user piece 
        var userPiece = context.UserPieces.FirstOrDefault(x => x.UserId == playerId && x.VoucherPieceId == randomPiece.Id);
        if (userPiece == null)
        {
            context.UserPieces.Add(new UserPiece
            {
                UserId = playerId,
                VoucherPieceId = eventEntity.Id,
                Quantity = 1
            });
        }
        else
        {
            userPiece.Quantity++;
        }

        var userEvent = context.UserEvents.FirstOrDefault(x => x.UserId == playerId && x.EventId == eventEntity.Id);
        if (userEvent == null)
        {
            context.UserEvents.Add(new UserEvent
            {
                UserId = playerId,
                EventId = eventEntity.Id,
                TurnsLeft = 2
            });
        } else {
            userEvent.TurnsLeft++;
        }
        
        await context.SaveChangesAsync(); 

        randomPiece.Voucher = context.Vouchers.First(x => x.Id == randomPiece.VoucherId);

        result.VoucherPiece = randomPiece;

        return result;

    }
}