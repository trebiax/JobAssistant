#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

ENV DOTNET_URLS=http://+:80

COPY ["JobAssistant/JobAssistant.csproj", "JobAssistant/"]
RUN dotnet restore "JobAssistant/JobAssistant.csproj"
COPY . .

WORKDIR "/src/JobAssistant"
RUN dotnet build "JobAssistant.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "JobAssistant.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "JobAssistant.dll"]