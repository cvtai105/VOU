1. lấy danh sách các tựa game để thêm vào event: GET /api/games/prototypes
2. lấy danh sách eventgame trong 1 event: GET /api/games/games-by-event
3. lấy danh sách eventgame dựa trên 1 tựa game (game prototype): GET /api/games/games-by-prototype
4. Brand Thêm nhiều game vào event: POST api/brand/games/create <br>

Body: 
{
  "eventId": "9E4F49FE-0783-44C6-9061-53D2ED84FAB9",
  "createEventGameParams": [
    {
      "gamePrototypeId": "9e4f49fe-0786-44c6-9061-1232aa84fab3",
      "type": "Shake",
      "startTime": "2024-12-29T01:06:20.687Z",
      "endTime": "2024-12-29T01:06:20.687Z",
      "voucherPieceCount": 2  // muốn tạo shake game, có thể cần dòng này, dùng để tạo voucherpieces nếu chưa có
    },
    {
      "gamePrototypeId": "9e4f49fe-0786-44c6-9061-1232aa84fab3",
      "type": "Quiz",
      "startTime": "2024-12-29T01:06:20.687Z",
      "endTime": "2024-12-29T01:06:20.687Z",
      "questionSetId": xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx // muốn tạo quiz game cần có field này
      "winningScore": 6                                     // và field này nữa
    }
  ]
}