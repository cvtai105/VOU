using Application.Services.GameServices.Contract;

namespace Application.Services.GameServices.ShakeGameServices
{
    public class CreateShakeGameParams : CreateGameParamsBase
    {
        public int VoucherPieceCount { get; set; }
    }
}