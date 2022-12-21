#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
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

FROM build AS publish
RUN dotnet publish "Gesc.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gesc.Api.dll"]