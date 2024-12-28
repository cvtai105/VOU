using Application.Services.GameServices.Contract;

namespace Application.Services.GameServices.ShakeGame
{
    public class CreateShakeGameParams : CreateGameParamsAbstract
    {
        public int VoucherPieceCount { get; set; }
    }
}