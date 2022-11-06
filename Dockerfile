FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Gesc.Api/Gesc.Api.csproj", "Gesc.Api/"]
RUN dotnet restore "Gesc.Api/Gesc.Api.csproj"
COPY . .
WORKDIR "/src/Gesc.Api"
RUN dotnet build "Gesc.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gesc.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gesc.Api.dll"]