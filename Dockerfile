FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY ["Gesc.Api/Gesc.Api.csproj", "Gesc.Api/"]
COPY ["Gesc.Domain/Gesc.Domain.csproj", "Gesc.Domain/"]
COPY ["Gesc.InjectionDeDependance/Gesc.InjectionDeDependance.csproj", "Gesc.InjectionDeDependance/"]
COPY ["Gesc.Application/Gesc.Application.csproj", "Gesc.Application/"]
COPY ["Gesc.Features/Gesc.Features.csproj", "Gesc.Features/"]
COPY ["Gesc.Data/Gesc.Data.csproj", "Gesc.Data/"]

RUN dotnet restore "Gesc.Api/Gesc.Api.csproj"

COPY . .
WORKDIR "/src/Gesc.Api"

RUN dotnet build "Gesc.Api.csproj" -c Release -o /app/build

FROM build-env AS publish
RUN dotnet publish "Gesc.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false


FROM mcr.microsoft.com/dotnet/aspnet:6.0 
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gesc.Api.dll"]
