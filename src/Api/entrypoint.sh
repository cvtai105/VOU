set -e

dotnet ef database update --no-build --project /src/Infrastructure --startup-project /src/Api

exec dotnet Api.dll