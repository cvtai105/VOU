1. create game : no api, new game -> dev new data table, new domain. 

2. after dev/test new game, admin can see game info ativate the game or disable game (update game.status): <br>
- api: get all games, activate game, disable game

3. brand can get list of active game for their event
- api: get active games
4. brand, user can get list of games that event registered
- api: get event games (eventId)
- data: list of eventgames{}
5. brand can remove game from an event
- api: end game (gameId)
6. brand can add games to an event
- api: add game (eventId, gameBaseId)

7. player can get reward after finish game (just for game that does not need server like shake game)
- api: get reward (gameId, playerId)


## User:
1. block/unlock user.
2. create user (register)
3. activate brand.??

## Question (for quizz game: use websocket --> không có api)
1. create question set 
2. delete question set
3. create questions (questionSetId)
4. update questions (questionId)

### websocket
5. server push question
6. server listen for answers, update user point in redis
7. push answer for question, push number of player choose A, B, C, D
8. utilize: if there are a large number of players, frontend will not push answer to server if player cannot get reward, and server just need to estimate number of people choose answers <br>
9. after game finish: close socket, server update reward for winners, after that, publish event to thirdparty (firebase), frontend listen for that event, then call api to get the reward and notice player
10. Cache the reward in backend some minus after update in database, for frontend call which get the reward.