#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Dockerfile

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["CandidateTestService.Api/CandidateTestService.Api.csproj", "CandidateTestService.Api/"]
COPY ["CandidateTestService.Core/CandidateTestService.Core.csproj", "CandidateTestService.Core/"]
COPY ["CandidateTestService.Repository/CandidateTestService.Repository.csproj", "CandidateTestService.Repository/"]
COPY ["CandidateTestService.Service/CandidateTestService.Service.csproj", "CandidateTestService.Service/"]
RUN dotnet restore "CandidateTestService.Api/CandidateTestService.Api.csproj"
COPY . .
WORKDIR "/src/CandidateTestService.Api"
RUN dotnet build "CandidateTestService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CandidateTestService.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CandidateTestService.Api.dll"]