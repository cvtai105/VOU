using Application.DTOs.GameDTOs;

namespace Application.Services.GameServices.ShakeGameServices
{
    public class CreateShakeGameParams : CreateGameParamsBase
    {
        public int? VoucherPieceCount { get; set; } 
    }
}