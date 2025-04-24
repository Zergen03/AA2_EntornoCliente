FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY RefuApi/*.csproj ./RefuApi/
COPY Data/*.csproj ./Data/
COPY DTOs/*.csproj ./DTOs/
COPY Models/*.csproj ./Models/
COPY Services/*.csproj ./Services/
RUN dotnet restore RefuApi/RefuApi.csproj

COPY . .
RUN dotnet publish RefuApi/RefuApi.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "RefuApi.dll"]
