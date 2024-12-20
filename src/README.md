# How to run UI
1. install node (if not)
2. `cd UI`
3. copy .env.template to .env
4. install package: `npm i`
5. run: `npm run dev`

# How to run Backend
1. install dotnet (if not)
2. `dotnet restore`
3. copy appsettings.template.json to appsettings.json
3. `dotnet run --project Api` <br>
**_NOTE:_** _run backend will automatically init database in sqlserver_

# Docker
0. Copy .env.dev.template to .env

1. To run entire app with docker
```bash
docker compose -f docker-compose.dev.yml up -d
```
**_NOTE:_** The first time should take few minus to pull or build image base on your network

2. To run api only <br> 
```bash
docker compose -f docker-compose.dev.yml up api database -d
```

3. Reset db <br>
```bash
docker compose -f docker-compose.dev.yml down -v
docker compose -f docker-compose.dev.yml up -d
```